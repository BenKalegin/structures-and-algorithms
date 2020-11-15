using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.DP
{
    class LongestIncreasingSubsequence
    {
        public static void Test()
        {
            AssertResult(new[] {10, 22, 9, 33, 21, 50, 41, 60, 80}, new[]{ 10, 22, 33, 50, 60, 80 });
        }

        private static void AssertResult(int[] sequence, int[] expected)
        {
            var actual1 = FindMemoized(sequence);
            var actual2 = FindTabularWay(sequence);
            if (!actual1.SequenceEqual(expected) || !actual2.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + i + ' ')} actual mem: {actual1.Aggregate("", (s, i) => s + i + ' ')} actual tab {actual2.Aggregate("", (s, i) => s + i + ' ')}");

                Console.ResetColor();
            }
        }

        private static int[] FindMemoized(int[] sequence)
        {
            var cache = new Dictionary<int, IList<int>>();
            return FindRecurse(sequence, sequence.Length-1, cache).ToArray();
        }

        private static IList<int> FindRecurse(int[] sequence, int maxPosition, Dictionary<int, IList<int>> cache)
        {
            if (cache.TryGetValue(maxPosition, out var result))
                return result;

            // 10, 22, 9, 33, 21, 50, 41, 60, 80
            // lets i is last index of optimal solution
            result = new List<int>();

            if (maxPosition == 0)
                result.Add(sequence[0]);
            else
            {
                for (int i = 0; i < maxPosition; i++)
                {
                    var subResult = FindRecurse(sequence, i, cache);
                    if (sequence[i] < sequence[maxPosition])
                        subResult = new List<int>(subResult.Append(sequence[maxPosition]));

                    if (subResult.Count > result.Count)
                    {
                        result = subResult;
                    }
                }
            }

            cache[maxPosition] = result;
            return result;
        }

        private static int[] FindTabularWay(int[] sequence)
        {
            var maxLengths = new int[sequence.Length];
            var priorValues = new int[sequence.Length];

            maxLengths[0] = 1;
            for (int i = 1; i < maxLengths.Length; i++)
            {
                maxLengths[i] = maxLengths[i - 1];
                for (int j = 0; j < i; j++)
                {
                    if (maxLengths[j] + 1 > maxLengths[i] && sequence[i] > sequence[j])
                    {
                        maxLengths[i] = maxLengths[j] + 1;
                        priorValues[i] = sequence[j];
                    }
                }
            }

            var steps = priorValues.Where(i => i > 0).ToArray();
            if (steps.Last() < sequence.Last())
                return steps.Append(sequence.Last()).ToArray();
            return steps;
        }
    }
}
