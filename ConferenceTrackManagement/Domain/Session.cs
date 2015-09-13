using System;
using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public class Session : TimeSlot
    {
        #region Fields

        private List<Talk> _talks;
        private TimeSpan _maximumDuration;

        #endregion

        #region Constructors

        public Session(string description, TimeSpan startTime, TimeSpan maximumDuration)
            : base(description, startTime)
        {
            _maximumDuration = maximumDuration;
            _talks = new List<Talk>();
        }

        #endregion

        #region Methods

        public TimeSpan TimeAvailable()
        {
            var totalTalkDuration = new TimeSpan();
            foreach (var talk in _talks)
            {
                totalTalkDuration = totalTalkDuration.Add(talk.Duration);
            }
            return _maximumDuration.Subtract(totalTalkDuration);
        }

        public void AddTalk(Talk talk)
        {
            var talkDuration = talk.Duration; 
            var sessionTimeAvailable = TimeAvailable();

            if (talkDuration > sessionTimeAvailable)
            {
                throw new ArgumentException("Talk will not fit into this session");
            }

            _talks.Add(talk);
        }

        public List<Talk> GetTalks()
        {
            return _talks;
        }

        #endregion
    }
}
