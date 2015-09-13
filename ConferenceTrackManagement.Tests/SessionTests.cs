using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceTrackManagement.Domain;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class SessionTests
    {
        
        [TestMethod]
        public void WhenAddingTalk_AddedToListOfTalks()
        {
            var session = new Session("Morning", DateTime.Now.TimeOfDay, new TimeSpan(0, 60, 0));
            session.AddTalk(new Talk("Talk Name", 30));
            var talk = session.GetTalks().SingleOrDefault(x => x.Title == "Talk Name");
            Assert.IsNotNull(talk);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenAddingTalkLongerThanAvailableDuration_ThrowsException()
        {
            var session = new Session("Morning", DateTime.Now.TimeOfDay, new TimeSpan(0, 60, 0));
            session.AddTalk(new Talk("Talk Name", 70));
        }

    }
}
