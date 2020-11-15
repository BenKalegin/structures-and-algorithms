using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Hashing
{
    class SortElementsOfAnArrayByFrequency
    {
        // Given an array A[] of integers, sort the array according to frequency of elements.
        // That is elements that have higher frequency come first. If frequencies of two elements are same, then smaller number comes first.
        public static void Test()
        {
            AssertResult(new[] { 5, 5, 4, 6, 4 }, new[] { 4, 4, 5, 5, 6 });
            AssertResult(new[] { 9, 9, 9, 2, 5 }, new[] { 9, 9, 9, 2, 5 });

        }
        private static void AssertResult(int[] values, int[] expected)
        {
            Sort(values);
            if (!values.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + " " + i)} actual: {values.Aggregate("", (s, i) => s + " " + i)}");

                Console.ResetColor();
            }
        }

        private static void Sort(int[] values)
        {
            var histogram = new Dictionary<int, int>();
            foreach (var value in values)
            {
                if (histogram.TryGetValue(value, out int count))
                    histogram[value] = count + 1;
                else
                    histogram[value] = 1;
            }

            Array.Sort(values, (i1, i2) =>
            {
                var countDelta = histogram[i2] - histogram[i1];
                if (countDelta == 0)
                    return i1 - i2;
                return countDelta;
            });

        }
    }
}
