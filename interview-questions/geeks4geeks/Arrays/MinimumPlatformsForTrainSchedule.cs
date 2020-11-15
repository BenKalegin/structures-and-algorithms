using System;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class MinimumPlatformsForTrainSchedule
    {
        // Given arrival and departure times of all trains that reach a railway station.
        // Your task is to find the minimum number of platforms required for the railway station so that no train waits.
        // Note: Consider that all the trains arrive on the same day and leave on the same day.
        // Also, arrival and departure times will not be same for a train, but we can have arrival time of one train equal to departure of the other.
        // In such cases, we need different platforms, i.e at any given instance of time, same platform can not be used for both departure of a train and arrival of another.
        public static void Test()
        {
            AssertResult(
                new []{ "0900", "0940", "0950", "1100", "1500", "1800"}, 
                new[] { "0910", "1200", "1120", "1130", "1900", "2000" }, 3);            
        }

        private static void AssertResult(string[] arrivals, string[] departures,  int expected)
        {
            var actual = FindRequiredPlatforms(arrivals.Select(int.Parse).OrderBy(a => a).ToArray(), departures.Select(int.Parse).OrderBy(d => d).ToArray());
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindRequiredPlatforms(int[] arrivals, int[] departures)
        {
            var maxPlatforms = 0;
            var requiredPlatforms = 0;

            var arrivalIndex = -1;
            var departureIndex = -1;


            while (arrivalIndex < arrivals.Length-1 && departureIndex < departures.Length-1)
            {
                if (arrivalIndex >= arrivals.Length - 1)
                {
                    departureIndex++;
                    requiredPlatforms--;
                }
                else if (departureIndex >= departures.Length - 1)
                {
                    arrivalIndex++;
                    requiredPlatforms++;
                }
                else if (arrivals[arrivalIndex + 1] <= departures[departureIndex + 1])
                {
                    arrivalIndex++;
                    requiredPlatforms++;
                }
                else
                {
                    departureIndex++;
                    requiredPlatforms--;
                }

                if (requiredPlatforms > maxPlatforms)
                    maxPlatforms = requiredPlatforms;
            }

            return maxPlatforms;
        }
    }
}
