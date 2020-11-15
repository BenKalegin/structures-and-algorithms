using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Hashing
{
    class RelativeSorting
    {
        // Given two arrays A1[] and A2[] of size N and M respectively.
        // The task is to sort A1 in such a way that the relative order among the elements will be same as those in A2.
        // For the elements not present in A2, append them at last in sorted order.
        // It is also given that the number of elements in A2[] are smaller than or equal to number of elements in A1[] and A2[] has all distinct elements.
        // Note: Expected time complexity is O(N log(N)).
        public static void Test()
        {
            AssertResult(new []{ 2, 1, 2, 5, 7, 1, 9, 3, 6, 8, 8 }, new[]{2, 1, 8, 3}, new[]{ 2, 2, 1, 1, 8, 8, 3, 5, 6, 7, 9 });
            AssertResult(new []{ 2, 6, 7, 5, 2, 6, 8, 4 }, new[]{ 2, 6, 4, 5 }, new[]{ 2, 2, 6, 6, 4, 5, 7, 8 });

        }
        private static void AssertResult(int[] values, int[] order, int[] expected)
        {
            Sort(values, order);
            if (!values.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + " " + i)} actual: {values.Aggregate("", (s, i) => s + " " + i)}");

                Console.ResetColor();
            }
        }

        private static void Sort(int[] values, int[] order)
        {
            var vocabulary = new Dictionary<int, int>();
            for (var i = 0; i < order.Length; i++)
            {
                vocabulary[order[i]] = i;
            }

            int maxOrder = order.Length+1;

            foreach (var value in values)
            {
                if (!vocabulary.ContainsKey(value))
                    vocabulary[value] = maxOrder + value;
            }

            Array.Sort(values, (i1, i2) => vocabulary[i1] - vocabulary[i2]);
        }
    }
}
