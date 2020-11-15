using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class LeadersInTheArray
    {
        // An element of array is leader if it is greater than or equal to all the elements to its right side. Also, the rightmost element is always a leader. 
        // Given an array of positive integers.Your task is to find the leaders in the array.

        public static void Test()
        {
            AssertResult(new[] { 16, 17, 4, 3, 5, 2 }, new[] { 17, 5, 2 });
            AssertResult(new[] { 1, 2, 3, 4, 0 }, new[] { 4, 0 });
            AssertResult(new[] { 16, 17, 4, 3, 5, 2 }, new[] { 17, 5, 2 });

        }
        private static void AssertResult(int[] values, int[] expected)
        {
            var actual = FindLeaders(values);
            if (actual.SequenceEqual( expected))
            {           
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }                               

        private static int[] FindLeaders(int[] values)
        {
            if (values == null)
                return null;

            if (!values.Any())
                return new int[0];

            var result = new List<int>();
            int max = values.Last();
            int i = values.Length - 2;
            result.Add(values.Last());
            while (i >= 0)
            {
                if (values[i] >= max)
                {
                    result.Add(values[i]);
                    max = values[i];
                }
                i--;
            }

            return result.ToArray();
        }
    }
}
