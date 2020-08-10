using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{
    class LargestNumberFormedFromAnArray
    {
        public static void Test()
        {
            // Given a list of non negative integers, arrange them in such a manner that they form the largest number possible.The result is going to be very large,
            // hence return the result in the form of a string.
            AssertResult(new[] { 3, 30, 34, 5, 9 }, "9534330");
        }
        private static void AssertResult(int[] numbers, string expected)
        {
            var actual = Arrange(numbers);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string Arrange(int[] numbers)
        {
            var strings = new List<string>(numbers.Select(n => n.ToString()));
            strings.Sort((s1, s2) => string.Compare(s2+s1, s1+s2, StringComparison.Ordinal) );
            return string.Join("", strings);
        }
    }
}
