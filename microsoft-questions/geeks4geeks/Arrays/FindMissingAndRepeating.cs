using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Arrays
{
    class FindMissingAndRepeating
    {
        // Given an unsorted array of size N of positive integers. One number 'A' from set {1, 2, …N} is missing and one number 'B' occurs twice in array. Find these two numbers.
        public static void Test()
        {
            AssertResult(new []{2, 2}, (1, 2));
        }

        private static void AssertResult(int[] numbers, (int mssing, int repeating) expected)
        {
            var actual = Find(numbers);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual {actual}");

                Console.ResetColor();
            }
        }

        private static (int missing, int repeating) Find(int[] numbers)
        {
            // if M is missing and D is duplicate, then
            // S1 = Sum(X) - Expected_Sum(X) = D - M
            // S2 = Sum(X*X) - Expected_Sum(X*X) = D*D - M*M
            // S2/S1 = D+M
            // D = (S1 + S2/S1)/ 2
            // M = D - S1

            int s1 = 0;
            long s2 = 0;

            for (var i = 1; i <= numbers.Length; i++)
            {
                s1 += numbers[i-1] - i;
                s2 += numbers[i-1] * numbers[i-1] - i * i;
            }

            var d = (s1 + s2 / s1) / 2;
            var m = d - s1;
            return ((int missing, int repeating)) (m, d);
        }
    }
}
