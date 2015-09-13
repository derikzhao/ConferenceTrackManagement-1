using System;

namespace ConferenceTrackManagement.Domain
{
    public class TimeSlot
    {
        #region Fields

        public string Description { get; private set; }
        public TimeSpan StartTime { get; private set; }

        #endregion

        #region Constructors

        public TimeSlot(string description, TimeSpan startTime)
	    {
            if (startTime.TotalDays >= 1)
            {
                throw new ArgumentException("Start Time must be in hours and minutes");
            }

            Description = description;
            StartTime = startTime;
        }

        #endregion

        #region Methods

        public void UpdateStartTime(TimeSpan startTime)
        {
            StartTime = startTime;
        }

        #endregion
    }
}
