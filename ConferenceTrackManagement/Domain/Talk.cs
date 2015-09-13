using System;
using System.Text.RegularExpressions;

namespace ConferenceTrackManagement.Domain
{
    public class Talk
    {
        #region Fields

        public string Title { get; private set; }
        public TimeSpan Duration { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a Talk of a fixed length in Minutes
        /// </summary>
        public Talk(string title, int durationInMinutes)
        {
            if (TitleIsInvalid(title))
            {
                throw new ArgumentException("Talk title cannot contain numbers");
            }
            if (durationInMinutes < 1)
            {
                throw new ArgumentException("Talk duration must be at least 1 minute long");
            }

            Title = title;
            Duration = new TimeSpan(0, durationInMinutes, 0);
        }

        /// <summary>
        /// Creates a Lightning Talk of 5 minutes in length
        /// </summary>
        public Talk(string title)
        {
            if (TitleIsInvalid(title))
            {
                throw new ArgumentException("Talk title cannot contain numbers");
            }

            Title = title;
            Duration = new TimeSpan(0, 5, 0);
        }

        #endregion

        #region Methods

        private bool TitleIsInvalid(string title)
        {
            return Regex.IsMatch(title, @"\d");
        }

        #endregion
    }
}
