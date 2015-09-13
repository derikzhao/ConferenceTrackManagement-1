using System;
using System.Collections.Generic;
using ConferenceTrackManagement.Domain.Interfaces;

namespace ConferenceTrackManagement.Domain
{
     public class TalkLoader : ITalkLoader
    {
        private List<string> TalkList { get; set; }

        public TalkLoader(List<string> talkList)
        {
            TalkList = new List<string>();
            TalkList = talkList;
        }

         public IEnumerable<Talk> Load()
         {
             var talks = new List<Talk>();

             foreach (var item in TalkList)
             {
                 var talkLength = 0;
                 var talkTitle = string.Empty;

                 if (item.Contains("lightning"))
                 {
                     talkTitle = item.Substring(0, (item.IndexOf("lightning"))).Trim();
                     talkLength = 5;
                 }
                 else
                 {
                     var firstNumberIndex = item.IndexOfAny("0123456789".ToCharArray());
                     if (firstNumberIndex < 2)
                     {
                         throw new ArgumentException(string.Format("Talk name is not valid - {0}", item));
                     }
                     talkTitle = item.Substring(0, firstNumberIndex).Trim();
                     var lengthInMinutes = item.Substring(firstNumberIndex);
                     var minutesIndex = lengthInMinutes.IndexOf("min");
                     var lengthMinutes = lengthInMinutes.Substring(0, minutesIndex);
                     talkLength = Convert.ToInt32(lengthMinutes);
                 }

                 var talk = new Talk(talkTitle, talkLength);
                 talks.Add(talk);
             }

             return talks;
         } 
    }
}
