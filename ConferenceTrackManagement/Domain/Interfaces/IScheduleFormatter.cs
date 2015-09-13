using System;

namespace ConferenceTrackManagement.Domain.Interfaces
{
    public interface IScheduleFormatter
    {
        string FormatTrack(string name);
        string FormatTalk(string title, TimeSpan duration, TimeSpan currentTime);
        string FormatLunch(string description, TimeSpan startTime);
        string FormatNetworking(string name, TimeSpan startTime);
    }
}
