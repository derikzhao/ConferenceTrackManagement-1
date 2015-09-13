using System;
using ConferenceTrackManagement.Domain;
using System.Linq;

namespace ConferenceTrackManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello. Please enter the path of the text file to read the talks from");
            
            var filePathValid = false;
            var filePath = string.Empty;
            while (!filePathValid)
            {
                var input = Console.ReadLine();
                if (System.IO.File.Exists(input))
                {
                    filePath = input;
                    filePathValid = true;
                }
                else
                {
                    Console.WriteLine("The file path entered was invalid. Please try again");
                }
           }

            Console.WriteLine("Creating conference schedule, please wait...");
            string[] lines = System.IO.File.ReadAllLines(filePath);

            ProcessConference(lines);

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }

        private static void ProcessConference(string[] input)
        {
            var conference = new Conference();

            try
            {
                conference.CreateSchedule(new TalkLoader(input.ToList()));

                var output = conference.ListSchedule(new TextFileOutputFormatter());

                foreach (var item in output)
                {
                    Console.WriteLine(item);
                }
                Console.Read(); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Sorry there has been a problem... {0}", ex.Message);
            }
        }

        private static void PromptForInput()
        {
            Console.WriteLine("Please input a comma-separated list of talks you want to schedule");
        }
    }
}
