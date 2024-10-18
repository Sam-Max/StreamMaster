import store from '@lib/redux/store';
import { setIsForced as GetAvailableCountriesSetIsForced } from '@lib/smAPI/SchedulesDirect/GetAvailableCountriesSlice';
import { setIsForced as GetChannelGroupsSetIsForced } from '@lib/smAPI/ChannelGroups/GetChannelGroupsSlice';
import { setIsForced as GetChannelGroupsFromSMChannelsSetIsForced } from '@lib/smAPI/ChannelGroups/GetChannelGroupsFromSMChannelsSlice';
import { setIsForced as GetChannelMetricsSetIsForced } from '@lib/smAPI/Statistics/GetChannelMetricsSlice';
import { setIsForced as GetCommandProfilesSetIsForced } from '@lib/smAPI/Profiles/GetCommandProfilesSlice';
import { setIsForced as GetCustomPlayListsSetIsForced } from '@lib/smAPI/Custom/GetCustomPlayListsSlice';
import { setIsForced as GetDownloadServiceStatusSetIsForced } from '@lib/smAPI/General/GetDownloadServiceStatusSlice';
import { setIsForced as GetEPGColorsSetIsForced } from '@lib/smAPI/EPG/GetEPGColorsSlice';
import { setIsForced as GetEPGFileNamesSetIsForced } from '@lib/smAPI/EPGFiles/GetEPGFileNamesSlice';
import { setIsForced as GetEPGFilesSetIsForced } from '@lib/smAPI/EPGFiles/GetEPGFilesSlice';
import { setIsForced as GetEPGNextEPGNumberSetIsForced } from '@lib/smAPI/EPGFiles/GetEPGNextEPGNumberSlice';
import { setIsForced as GetHeadendsToViewSetIsForced } from '@lib/smAPI/SchedulesDirect/GetHeadendsToViewSlice';
import { setIsForced as GetIntroPlayListsSetIsForced } from '@lib/smAPI/Custom/GetIntroPlayListsSlice';
import { setIsForced as GetIsSystemReadySetIsForced } from '@lib/smAPI/General/GetIsSystemReadySlice';
import { setIsForced as GetLogNamesSetIsForced } from '@lib/smAPI/Logs/GetLogNamesSlice';
import { setIsForced as GetLogosSetIsForced } from '@lib/smAPI/Logos/GetLogosSlice';
import { setIsForced as GetM3UFileNamesSetIsForced } from '@lib/smAPI/M3UFiles/GetM3UFileNamesSlice';
import { setIsForced as GetM3UFilesSetIsForced } from '@lib/smAPI/M3UFiles/GetM3UFilesSlice';
import { setIsForced as GetOutputProfilesSetIsForced } from '@lib/smAPI/Profiles/GetOutputProfilesSlice';
import { setIsForced as GetSelectedStationIdsSetIsForced } from '@lib/smAPI/SchedulesDirect/GetSelectedStationIdsSlice';
import { setIsForced as GetSettingsSetIsForced } from '@lib/smAPI/Settings/GetSettingsSlice';
import { setIsForced as GetSMChannelNameLogosSetIsForced } from '@lib/smAPI/SMChannels/GetSMChannelNameLogosSlice';
import { setIsForced as GetSMChannelNamesSetIsForced } from '@lib/smAPI/SMChannels/GetSMChannelNamesSlice';
import { setIsForced as GetSMTasksSetIsForced } from '@lib/smAPI/SMTasks/GetSMTasksSlice';
import { setIsForced as GetStationChannelNamesSetIsForced } from '@lib/smAPI/SchedulesDirect/GetStationChannelNamesSlice';
import { setIsForced as GetStationPreviewsSetIsForced } from '@lib/smAPI/SchedulesDirect/GetStationPreviewsSlice';
import { setIsForced as GetStreamGroupProfilesSetIsForced } from '@lib/smAPI/StreamGroups/GetStreamGroupProfilesSlice';
import { setIsForced as GetStreamGroupsSetIsForced } from '@lib/smAPI/StreamGroups/GetStreamGroupsSlice';
import { setIsForced as GetSubScribedHeadendsSetIsForced } from '@lib/smAPI/SchedulesDirect/GetSubScribedHeadendsSlice';
import { setIsForced as GetSubscribedLineupsSetIsForced } from '@lib/smAPI/SchedulesDirect/GetSubscribedLineupsSlice';
import { setIsForced as GetSystemStatusSetIsForced } from '@lib/smAPI/General/GetSystemStatusSlice';
import { setIsForced as GetTaskIsRunningSetIsForced } from '@lib/smAPI/General/GetTaskIsRunningSlice';
import { setIsForced as GetVideoInfosSetIsForced } from '@lib/smAPI/Statistics/GetVideoInfosSlice';
import { setIsForced as GetVideoStreamNamesAndUrlsSetIsForced } from '@lib/smAPI/SMChannels/GetVideoStreamNamesAndUrlsSlice';

export const DataRefreshAll = () => {
  store.dispatch(GetAvailableCountriesSetIsForced({ force: true }));
  store.dispatch(GetChannelGroupsSetIsForced({ force: true }));
  store.dispatch(GetChannelGroupsFromSMChannelsSetIsForced({ force: true }));
  store.dispatch(GetChannelMetricsSetIsForced({ force: true }));
  store.dispatch(GetCommandProfilesSetIsForced({ force: true }));
  store.dispatch(GetCustomPlayListsSetIsForced({ force: true }));
  store.dispatch(GetDownloadServiceStatusSetIsForced({ force: true }));
  store.dispatch(GetEPGColorsSetIsForced({ force: true }));
  store.dispatch(GetEPGFileNamesSetIsForced({ force: true }));
  store.dispatch(GetEPGFilesSetIsForced({ force: true }));
  store.dispatch(GetEPGNextEPGNumberSetIsForced({ force: true }));
  store.dispatch(GetHeadendsToViewSetIsForced({ force: true }));
  store.dispatch(GetIntroPlayListsSetIsForced({ force: true }));
  store.dispatch(GetIsSystemReadySetIsForced({ force: true }));
  store.dispatch(GetLogNamesSetIsForced({ force: true }));
  store.dispatch(GetLogosSetIsForced({ force: true }));
  store.dispatch(GetM3UFileNamesSetIsForced({ force: true }));
  store.dispatch(GetM3UFilesSetIsForced({ force: true }));
  store.dispatch(GetOutputProfilesSetIsForced({ force: true }));
  store.dispatch(GetSelectedStationIdsSetIsForced({ force: true }));
  store.dispatch(GetSettingsSetIsForced({ force: true }));
  store.dispatch(GetSMChannelNameLogosSetIsForced({ force: true }));
  store.dispatch(GetSMChannelNamesSetIsForced({ force: true }));
  store.dispatch(GetSMTasksSetIsForced({ force: true }));
  store.dispatch(GetStationChannelNamesSetIsForced({ force: true }));
  store.dispatch(GetStationPreviewsSetIsForced({ force: true }));
  store.dispatch(GetStreamGroupProfilesSetIsForced({ force: true }));
  store.dispatch(GetStreamGroupsSetIsForced({ force: true }));
  store.dispatch(GetSubScribedHeadendsSetIsForced({ force: true }));
  store.dispatch(GetSubscribedLineupsSetIsForced({ force: true }));
  store.dispatch(GetSystemStatusSetIsForced({ force: true }));
  store.dispatch(GetTaskIsRunningSetIsForced({ force: true }));
  store.dispatch(GetVideoInfosSetIsForced({ force: true }));
  store.dispatch(GetVideoStreamNamesAndUrlsSetIsForced({ force: true }));
};
