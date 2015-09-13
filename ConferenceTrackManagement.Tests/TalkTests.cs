using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConferenceTrackManagement.Domain;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class TalkTests
    {
        [TestMethod]
        public void CanCreateTalk()
        {
            var talk = new Talk("A title of a talk", 2);
            Assert.IsNotNull(talk);
        }

        [TestMethod]
        public void CanCreateLighteningTalk()
        {
            var talk = new Talk("A title of a talk");
            Assert.IsNotNull(talk);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenTitleContainsNumbers_ThrowsException()
        {
            var talk = new Talk("A title with numb3rs", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenLighteneingTitleContainsNumbers_ThrowsException()
        {
            var talk = new Talk("A title with numb3rs");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenDurationIsLessThan1_ThrowsException()
        {
            var talk = new Talk("A title of a talk", 0);
        }
    }
}
