using System;
using ConferenceTrackManagement.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class TimeSlotTests
    {
        [TestMethod]
        public void CanCreateTimeSlot()
        {
            var timeSlot = new TimeSlot("Description", new TimeSpan(23, 59, 59));
            Assert.IsNotNull(timeSlot);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidStartTime_ThrowsException()
        {
            var timeSlot = new TimeSlot("Description", new TimeSpan(24,0,0));
        }
    }
}
