﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace StreamMaster.API.Controllers;

[V1ApiController("v")]
public class VsController(ILogger<VsController> logger, IVideoService videoService, IStreamGroupService streamGroupService, IChannelManager channelManager) : Controller
{
    [Authorize(Policy = "SGLinks")]
    [HttpGet]
    [HttpHead]
    [Route("{encodedIds}")]
    [Route("{encodedIds}.ts")]
    [Route("{streamGroupProfileId}/{smChannelId}")]
    [Route("{streamGroupProfileId}/{smChannelId}.ts")]
    public async Task<ActionResult> HandleStreamRequest(
    string? encodedIds = null,
    int? smChannelId = null,
    int? streamGroupProfileId = null,
    CancellationToken cancellationToken = default)
    {
        int? streamGroupId = null;

        try
        {
            if (!string.IsNullOrEmpty(encodedIds))
            {
                (streamGroupId, streamGroupProfileId, smChannelId) = await streamGroupService.DecodeProfileIdSMChannelIdFromEncodedAsync(encodedIds);
            }
            else if (smChannelId.HasValue && streamGroupProfileId.HasValue)
            {
                streamGroupId = await streamGroupService.GetStreamGroupIdFromSGProfileIdAsync(streamGroupProfileId).ConfigureAwait(false);
            }
            else
            {
                logger.LogWarning("Invalid request: Missing required parameters.");
                return NotFound();
            }

            // Prepare response headers
            HttpContext.Response.ContentType = "video/mp2t";
            HttpContext.Response.Headers.CacheControl = "no-cache";
            HttpContext.Response.Headers.Pragma = "no-cache";
            HttpContext.Response.Headers.Expires = "0";
            // Set the Content-Disposition header to specify the filename
            string fileName = $"{encodedIds ?? "stream"}.ts";
            HttpContext.Response.Headers.ContentDisposition = $"inline; filename=\"{fileName}\"";

            StreamResult streamResult = await videoService.AddClientToChannelAsync(HttpContext, streamGroupId, streamGroupProfileId, smChannelId, cancellationToken);

            if (streamResult.ClientConfiguration == null)
            {
                logger.LogWarning("Channel with ChannelId {channelId} not found or failed. Name: {name}", smChannelId, streamResult.ClientConfiguration?.SMChannel.Name ?? "Unknown");
                return NotFound();
            }

            if (!string.IsNullOrEmpty(streamResult.RedirectUrl))
            {
                logger.LogInformation("Channel with ChannelId {channelId} is redirecting to {redirectUrl}", smChannelId, streamResult.RedirectUrl);
                return Redirect(streamResult.RedirectUrl);
            }

            // Register client stopped event
            streamResult.ClientConfiguration.ClientStopped += (sender, args) =>
            {
                logger.LogInformation("Client {UniqueRequestId} stopped. Name: {name}", streamResult.ClientConfiguration.UniqueRequestId, streamResult.ClientConfiguration.SMChannel.Name);
                _ = channelManager.RemoveClientAsync(streamResult.ClientConfiguration);
            };

            // Register for dispose to ensure cleanup
            HttpContext.Response.RegisterForDispose(new UnregisterClientOnDispose(channelManager, streamResult.ClientConfiguration, logger));
            await streamResult.ClientConfiguration.CompletionSource.Task.ConfigureAwait(false);

            return new EmptyResult();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error processing stream request. Parameters: encodedIds={encodedIds}, smChannelId={smChannelId}, streamGroupProfileId={streamGroupProfileId}");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
        }
    }
    private class UnregisterClientOnDispose(IChannelManager channelManager, IClientConfiguration config, ILogger logger) : IDisposable
    {
        private readonly IChannelManager _channelManager = channelManager;
        private readonly IClientConfiguration _config = config;

        public void Dispose()
        {
            DisposeAsync().GetAwaiter().GetResult();
        }

        private async Task DisposeAsync()
        {
            try
            {
                logger.LogInformation("Client {UniqueRequestId} {name} disposing", _config.UniqueRequestId, _config.SMChannel.Name);

                // Complete the HTTP response
                if (!_config.Response.HasStarted)
                {
                    await _config.Response.CompleteAsync().ConfigureAwait(false);
                }

                // Remove the client from the channel manager
                await _channelManager.RemoveClientAsync(_config).ConfigureAwait(false);

                logger.LogInformation("Client {UniqueRequestId} {name} successfully disposed", _config.UniqueRequestId, _config.SMChannel.Name);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during disposal of client {UniqueRequestId} {name}", _config.UniqueRequestId, _config.SMChannel.Name);
            }
        }
    }
}