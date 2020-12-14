using System;
using System.Collections.Generic;
using System.Linq;
using Index = System.Int32;
using Value = System.Int32;

namespace interview_questions.geeks4geeks.Arrays
{
    class PairSums
    {
        // Given a list of n integers arr[0..(n-1)], determine the number of different pairs of elements within it which sum to k.
        // If an integer appears in the list multiple times, each copy is considered to be different; that is,
        // two pairs are considered different if one pair includes at least one array index which the other doesn't, even if they include the same values.

        public static void Test()
        {
            AssertResult(new[] {2, 1, 0, 2, 1}, 3, 4);
            AssertResult(new[] {1, 1, 1}, 2, 3);

        }

        private static void AssertResult(Value[] values, Value sum, int expected)
        {
            var actual = FindPairSums(values, sum);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }


        private static int FindPairSums(int[] values, int sum)
        {
            var complements = new Dictionary<Value, List<Index>>();

            for (var index = 0; index < values.Length; index++)
            {
                var value = values[index];
                if (!complements.ContainsKey(value))
                    complements[value] = new List<Index>();

                var indexesHavingSameValue = complements[value];
                indexesHavingSameValue.Add(index);
            }

            int result = 0;

            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (complements.TryGetValue(sum - value, out var pairs))
                {
                    result += pairs.Count(i1 => i1 != i);
                }
            }

            return result / 2;
        }
    }
}
