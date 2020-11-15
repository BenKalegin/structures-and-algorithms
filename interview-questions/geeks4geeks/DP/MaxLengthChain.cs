using System;
using System.Linq;

namespace interview_questions.geeks4geeks.DP
{
    class MaxLengthChain
    {
        // You are given N pairs of numbers. In every pair, the first number is always smaller than the second number. A pair (c, d) can follow another pair (a, b) if b < c.
        // Chain of pairs can be formed in this fashion.
        // Your task is to complete the function maxChainLen which returns an integer denoting the longest chain which can be formed from a given set of pairs. 
        public static void Test()
        {
            AssertResult(3, (5, 24), (39, 60), (15, 28), (27, 40), (50, 90));

        }
        private static void AssertResult(int expected, params (int v1, int v2)[] pairs)
        {
            var actual = FindLongestChain(pairs);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindLongestChain((int v1, int v2)[] pairs)
        {
            // guess
            // if path ends with the element dp[i], then
            // dp[i] = 1 + Max(dp[j]: j < i && v[j].v2 < v[i].v1 )  

            var dp = new int[pairs.Length];

            for (int i = 0; i < pairs.Length; i++)
            {
                dp[i] = Enumerable.Range(0, i)
                    .Where(j => pairs[j].v2 < pairs[i].v1)
                    .Select(j => dp[j])
                    .DefaultIfEmpty(0).Max() + 1;
            }

            return dp.Max();

        }
    }
}
