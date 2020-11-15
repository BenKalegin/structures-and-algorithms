using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.InterviewCake
{
    class CheckIfPermutationPalindrome
    {
        public static void Test()
        {
            Action<bool, string> check = (expected, input) =>
            {
                if (expected != IsPalindrome(input)) throw new Exception();
            };

            check(true, "civic");
            check(true, "ivicc");
            check(false, "civil");
            check(false, "livci");

        }

        private static bool IsOdd(int i) => i % 2 == 1;

        private static bool IsPalindrome(string input)
        {
            var histogram = new Dictionary<char, int>();
            foreach (var c in input)
            {
                if (histogram.TryGetValue(c, out var count))
                    histogram[c] = count + 1;
                else
                    histogram[c] = 1;
            }

            var oddCount = histogram.Values.Count(IsOdd);

            return !IsOdd(input.Length) ? oddCount == 0 : oddCount == 1;
        }
    }
}
