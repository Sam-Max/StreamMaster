﻿using StreamMaster.Application.Services;

namespace StreamMaster.Application.StreamGroupSMChannelLinks.Commands;

[SMAPI]
[TsInterface(AutoI = false, IncludeNamespace = false, FlattenHierarchy = true, AutoExportMethods = false)]
public record AddSMChannelsToStreamGroupByParametersRequest(QueryStringParameters Parameters, int StreamGroupId) : IRequest<APIResponse>;

internal class AddSMChannelsToStreamGroupByParametersRequestHandler(IBackgroundTaskQueue taskQueue,ISMWebSocketManager sMWebSocketManager, IRepositoryWrapper Repository, IDataRefreshService dataRefreshService) : IRequestHandler<AddSMChannelsToStreamGroupByParametersRequest, APIResponse>
{
    public async Task<APIResponse> Handle(AddSMChannelsToStreamGroupByParametersRequest request, CancellationToken cancellationToken)
    {
        List<FieldData> fieldDatas = [];
        IQueryable<SMChannel> smChannels = await Repository.SMChannel.GetPagedSMChannelsQueryableAsync(request.Parameters);
        foreach (SMChannel smChannel in smChannels)
        {
            APIResponse res = await Repository.StreamGroupSMChannelLink.AddSMChannelToStreamGroup(request.StreamGroupId, smChannel.Id).ConfigureAwait(false);
            if (res.IsError)
            {
                return APIResponse.ErrorWithMessage(res.ErrorMessage);
            }

            SMChannel? smChannel2 = Repository.SMChannel.GetSMChannel(smChannel.Id);
            if (smChannel2 is null)
            {
                return APIResponse.ErrorWithMessage("Channel not found");
            }
            List<int> streamGroupIds = [.. smChannel2.StreamGroups.Select(a => a.StreamGroupId)];
            fieldDatas.Add(new(SMChannel.APIName, smChannel2.Id, "StreamGroupIds", streamGroupIds));
        }

        if (fieldDatas.Count > 0)
        {
            await dataRefreshService.SetField(fieldDatas).ConfigureAwait(false);

            await dataRefreshService.ClearByTag(SMChannel.APIName, "notInSG").ConfigureAwait(false);
            await dataRefreshService.ClearByTag(SMChannel.APIName, "inSG").ConfigureAwait(false);
        }
        await dataRefreshService.RefreshStreamGroups();
        await dataRefreshService.RefreshSMChannels();
        await taskQueue.CreateSTRMFiles(cancellationToken);
        await sMWebSocketManager.BroadcastReloadAsync();
        return APIResponse.Success;
    }
}