﻿using StreamMaster.SchedulesDirectAPI.Domain.JsonClasses;


using StreamMasterDomain.Attributes;

namespace StreamMasterDomain.Dto;

[RequireAll]
public class ProgrammeNameDto : IMapFrom<Programme>
{
    public string Id => Channel;
    public string Channel { get; set; }
    public string ChannelName { get; set; }
    public string DisplayName { get; set; }
}
