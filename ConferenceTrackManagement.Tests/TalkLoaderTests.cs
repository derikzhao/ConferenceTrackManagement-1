using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTrackManagement.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConferenceTrackManagement.Tests
{
    [TestClass]
    public class TalkLoaderTests
    {

        [TestMethod]
        public void MustLoadTalk()
        {
            var talk = new List<string>()
            {
                "Ruby vs. Clojure for Back-End Development 30min",
            };
            var loader = new TalkLoader(talk);
            var result = loader.Load();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.First().Title, "Ruby vs. Clojure for Back-End Development");
            Assert.AreEqual(result.First().Duration, new TimeSpan(0, 30, 0));
        }

        [TestMethod]
        public void MustLoadLighteningTalk()
        {
            var talk = new List<string>()
            {
                "Ruby vs. Clojure for Back-End Development lightning",
            };
            var loader = new TalkLoader(talk);
            var result = loader.Load();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
            Assert.AreEqual(result.First().Title, "Ruby vs. Clojure for Back-End Development");
            Assert.AreEqual(result.First().Duration, new TimeSpan(0, 5, 0));
        }

        [TestMethod]
        public void MustLoadMultipleTalks()
        {
            var talk = new List<string>()
            {
                "Ruby vs. Clojure for Back-End Development lightning",
                "Ruby vs. Clojure for Back-End Development 30min"
            };
            var loader = new TalkLoader(talk);
            var result = loader.Load();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
