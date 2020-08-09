using System;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
    class PythagoreanTriplet
    {
        // Given an array of integers, write a function that returns true if there is a triplet (a, b, c) that satisfies a2 + b2 = c2.
        public static void Test()
        {
            AssertResult(new[] {3, 2, 4, 6, 5}, true);
        }
        private static void AssertResult(int[] numbers, bool expected)
        {
            var actual = FindTriplet(numbers);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static bool FindTriplet(int[] numbers)
        {
            var squares = numbers.Select(n => n * n).ToArray();
            return false;
        }
    }
}
