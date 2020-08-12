using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.DP
{
    class MinimumNumberOfCoins
    {
        // Given a value N, total sum you have. You have to make change for Rs. N, and there is infinite supply of each of the denominations in Indian currency,
        // i.e., you have infinite supply of { 1, 2, 5, 10, 20, 50, 100, 200, 500, 2000} valued coins/notes,
        // Find the minimum number of coins and/or notes needed to make the change for Rs N.
        public static void Test()
        {
            AssertResult(3, new[]{2, 1});
            AssertResult(43, new[]{20, 20, 2, 1});

        }
        private static void AssertResult(int amount, int[] expected)
        {
            var actual = FindMinimum(amount).OrderByDescending(c => c).ToArray();
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s,i) => s + " " + i)} actual: {actual.Aggregate("", (s, i) => s + " " + i)}");

                Console.ResetColor();
            }
        }


        static readonly int[] nominals = { 1, 2, 5, 10, 20, 50, 100, 200, 500, 2000 };


        private static List<int> FindMinimum(int amount)
        {
            // guess
            // at amount, we added on of the coins
            // bottom up easier
            // dp - number of coins to make 
            
            // i - number of coins included to make amount i

            var cache = new Dictionary<int, List<int>>();
            FindMinimumRecursive(amount, cache);
            return cache[amount];

            /*
            for (int i = 1; i < amount; i++)
            {
                foreach (var nominal in nominals)
                    if (i + nominal < dp.Length)
                        dp[i + nominal] = Math.Min(dp[i + nominal], dp[i] + 1);
            }
            */

            
        }

        static List<int> FindMinimumRecursive(int amount, Dictionary<int, List<int>> cache)
        {
            if (amount == 0)
                return new List<int>();
            if (cache.TryGetValue(amount, out var result))
                return result;

            var best = nominals.Where(n => n < amount).Select(n => new { nominal = n, coins = FindMinimumRecursive(amount - n, cache)}).OrderBy(arg => arg.coins.Count).FirstOrDefault();

            result = best != null ? new List<int>(best.coins) : new List<int>();
            
            result.Add(best == null ? amount: (amount - best.coins.Sum()));

            cache[amount] = result;
            return result;
        }
    }
}
