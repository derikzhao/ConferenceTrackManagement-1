using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceTrackManagement.Domain;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class ConferenceTests
    {
        [TestMethod]
        public void MustBeAbleToCreateConference()
        {
            var conference = new Conference();

            Assert.IsNotNull(conference);
        }
    }
}
