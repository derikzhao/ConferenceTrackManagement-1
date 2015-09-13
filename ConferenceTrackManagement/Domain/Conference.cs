using System;
using System.Collections.Generic;
using System.Linq;
using ConferenceTrackManagement.Domain.Interfaces;

namespace ConferenceTrackManagement.Domain
{
    public class Conference
    {
        #region Fields

        private readonly List<Track> _tracks;

        #endregion

        #region Constructors

        public Conference()
        {
            _tracks = new List<Track>
            {
                new Track("Track1"),
                new Track("Track2")
            };
        }

        #endregion

        #region Methods

        public void CreateSchedule(ITalkLoader talksLoader)
        {
            var talksToSchedule = talksLoader.Load().OrderByDescending(x => x.Duration).ToList();

            foreach (var talk in talksToSchedule)
            {
                var talkScheduled = false;
                foreach (var track in _tracks)
                {
                    if (talk.Duration <= track.MorningSession.TimeAvailable())
                    {
                        track.MorningSession.AddTalk(talk);
                        talkScheduled = true;
                        break;
                    }
                    if (talk.Duration <= track.AfternoonSession.TimeAvailable())
                    {
                        track.AfternoonSession.AddTalk(talk);
                        talkScheduled = true;
                        break;
                    }
                }
                if (!talkScheduled)
                {
                    throw new ArgumentException("Unable to create schedule: Talks could not fit into available sessions");
                }
            }

            foreach (var track in _tracks)
            {
                track.RescheduleNetworkingEvent();
            }
        }

        public List<string> ListSchedule(IScheduleFormatter scheduleFormatter)
        {
            var schedule = new List<string>();

            foreach (var track in _tracks)
            {
                schedule.Add(scheduleFormatter.FormatTrack(track.GetName()));
                
                var currentTime = track.MorningSession.StartTime;
                
                foreach (var talk in track.MorningSession.GetTalks())
	            {
		            schedule.Add(scheduleFormatter.FormatTalk(talk.Title, talk.Duration, currentTime));
                    currentTime = currentTime.Add(new TimeSpan(0, (int)talk.Duration.TotalMinutes, 0));
                }

                schedule.Add(scheduleFormatter.FormatLunch(track.Lunch.Description, track.Lunch.StartTime));

                currentTime = track.AfternoonSession.StartTime;

                foreach (var talk in track.AfternoonSession.GetTalks())
                {
                    schedule.Add(scheduleFormatter.FormatTalk(talk.Title, talk.Duration, currentTime));
                    currentTime = currentTime.Add(new TimeSpan(0, (int)talk.Duration.TotalMinutes, 0));
                }

                schedule.Add(scheduleFormatter.FormatNetworking(track.Networking.Description, track.Networking.StartTime));
            }

            return schedule;
        }

        #endregion
    }

}
