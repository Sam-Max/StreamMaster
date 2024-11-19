using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace StreamMaster.Infrastructure.Services.Frontend.Mappers
{
    public abstract class StaticResourceMapperBase : IMapHttpRequestsToDisk
    {

        private readonly ILogger _logger;
        private readonly IContentTypeProvider _mimeTypeProvider;

        protected StaticResourceMapperBase(ILogger logger)
        {
            _logger = logger;
            _mimeTypeProvider = new FileExtensionContentTypeProvider();
        }

        public abstract bool CanHandle(string resourceUrl);

        public async Task<IActionResult?> GetResponseAsync(string resourceUrl)
        {
            string filePath = await MapAsync(resourceUrl);

            if (File.Exists(filePath))
            {
                if (!_mimeTypeProvider.TryGetContentType(filePath, out string? contentType))
                {
                    contentType = "application/octet-stream";
                }

                Stream stream = await GetContentStreamAsync(filePath);

                return new FileStreamResult(stream, new MediaTypeHeaderValue(contentType)
                {
                    Encoding = contentType == "text/plain" ? Encoding.UTF8 : null
                });
            }

            _logger.LogWarning("File {0} not found", filePath);

            return null;
        }

        public abstract Task<string> MapAsync(string resourceUrl);


        protected virtual Task<Stream> GetContentStreamAsync(string filePath)
        {
            Stream contentStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            return Task.FromResult(contentStream);
        }
    }
}
