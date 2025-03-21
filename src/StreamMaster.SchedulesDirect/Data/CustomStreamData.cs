﻿using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace StreamMaster.SchedulesDirect.Data;

public class CustomStreamData(int EPGNumber) : ICustomStreamData
{
    public int EPGNumber { get; set; } = EPGNumber;

    public ConcurrentDictionary<string, MxfService> Services { get; set; } = [];
    [XmlIgnore] public List<MxfProgram> ProgramsToProcess { get; set; } = [];

    public MxfService FindOrCreateService(string stationId)
    {
        (MxfService service, bool created) = Services.FindOrCreateWithStatus(stationId, _ => new MxfService(Services.Count + 1, stationId)
        {
            EPGNumber = EPGNumber
        });
        return created ? service : service;
    }

    public MxfService? GetService(string stationId)
    {
        return Services.TryGetValue(stationId, out MxfService? service) ? service : null;
    }
    public void RemoveService(string stationId)
    {
        _ = Services.TryRemove(stationId, out _);
    }

    public void ResetLists()
    {
        ProgramsToProcess.Clear();
        Services.Clear();
    }
}
