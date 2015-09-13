using System;
using ConferenceTrackManagement.Domain.Interfaces;

namespace ConferenceTrackManagement.Domain
{
     public class TextFileOutputFormatter : IScheduleFormatter
    {
        public string FormatTrack(string name)
        {
            return string.Format("{0}:", name);
        }

        public string FormatTalk(string title, TimeSpan duration, TimeSpan currentTime)
        {
            return string.Format("{0}{1} {2} {3}min", currentTime.ToString(@"hh\:mm"), ConvertToPeriod(currentTime), title, duration.TotalMinutes);
                    
        }

        public string FormatLunch(string description, TimeSpan startTime)
        {
            return string.Format("{0}{1} {2}", startTime.ToString(@"hh\:mm"), ConvertToPeriod(startTime), description);
        }

        public string FormatNetworking(string name, TimeSpan startTime)
        {
            return string.Format("{0}{1} {2}", startTime.ToString(@"hh\:mm"), ConvertToPeriod(startTime), name);
        }

        private string ConvertToPeriod(TimeSpan time)
        {
            return time.TotalHours >= 12 ? "PM" : "AM";
        }
    }
}
