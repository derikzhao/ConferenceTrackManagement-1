using ConferenceTrackManagement.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public void WhenCreatingTrack_ReturnsName()
        {
            var trackName = "Test Track";
            var track = new Track(trackName);
            Assert.AreEqual(trackName, track.GetName());
        }

        [TestMethod]
        public void WhenCreatingTrackWithNoName_ReturnsDefaultName()
        {
            var defaultTrackName = "Unnamed Track";
            var track = new Track(string.Empty);
            Assert.AreEqual(defaultTrackName, track.GetName());
        }
    }
}
