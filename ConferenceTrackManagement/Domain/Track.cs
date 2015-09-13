using System;

namespace ConferenceTrackManagement.Domain
{
    public class Track
    {
        #region Fields

        private readonly string _name;
        public Session MorningSession { get; private set; }
        public TimeSlot Lunch { get; private set; }
        public Session AfternoonSession { get; private set; }
        public TimeSlot Networking { get; private set; }

        #endregion

        #region Constructors

        public Track(string name)
        {
            _name = name;
            MorningSession = new Session("Morning Session", new TimeSpan(9, 0, 0), new TimeSpan(3, 0, 0));
            Lunch = new TimeSlot("Lunch", new TimeSpan(12, 0, 0));
            AfternoonSession = new Session("Afternoon Session", new TimeSpan(13, 0, 0), new TimeSpan(4, 0, 0));
            Networking = new TimeSlot("Networking Event", new TimeSpan(17, 0, 0));
        }

        #endregion

        #region Methods

        public string GetName()
        {
            return string.IsNullOrEmpty(_name) ? "Unnamed Track" : _name;
        }

        public void RescheduleNetworkingEvent()
        {
            if (AfternoonSession.TimeAvailable().TotalMinutes > 60)
            {
                Networking.UpdateStartTime(new TimeSpan(16, 0, 0));
            }
            else
            {
                Networking.UpdateStartTime(new TimeSpan(17, 0, 0).Subtract(AfternoonSession.TimeAvailable()));
            }
        }

        #endregion
    }
}