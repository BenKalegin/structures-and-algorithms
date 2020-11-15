using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.DP
{
    // Given a rod of length n inches and an array of prices that contains prices of all pieces of size smaller than n.
    // Determine the maximum value obtainable by cutting up the rod and selling the pieces. 
    class CuttingARod
    {
        public static void Test()
        {
            AssertResult(8, new[] {0, 1,5,8,9,10,17,17,20}, 22);

        }
        private static void AssertResult(int length, int[] prices, int expected)
        {
            var actual1 = FindMaximumMemoized(length, prices);
            var actual2 = FindMaximumTabularWay(length, prices);
            if (actual1 != expected || actual2 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual mem: {actual1} actual tab {actual2}");

                Console.ResetColor();
            }
        }

        private static int FindMaximumMemoized(int length, int[] prices)
        {
            var bestValueByLengthCache = new Dictionary<int, int>();
            return FindMaximumRecursive(length, prices, bestValueByLengthCache);
        }

        private static int FindMaximumRecursive(int length, int[] prices, Dictionary<int, int> bestValueByLengthCache)
        {
            if (bestValueByLengthCache.TryGetValue(length, out int result))
                return result;
            if (length == 0)
                return 0;

            if (length == 1)
                return prices[1];

            result = Enumerable.Range(1, length-1)
                .Select(i => FindMaximumRecursive(i, prices, bestValueByLengthCache) + FindMaximumRecursive(length - i, prices, bestValueByLengthCache))
                .Max();

            result = Math.Max(result, prices[length]);
            bestValueByLengthCache[length] = result;
            return result;
        }

        private static int FindMaximumTabularWay(int length, int[] prices)
        {
            int[] dp = new int[length+1];
            dp[0] = 0;
            for (int i = 1; i <= length; i++)
            {
                dp[i] = prices[i];
                for (int j = 1; j < i; j++)
                {
                    var brokenValue = dp[j] + dp[i-j];
                    if (brokenValue > dp[i])
                        dp[i] = brokenValue;
                }
            }

            return dp[length];
        }

    }
}
