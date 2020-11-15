using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.DP
{
    class OptimalStrategyForAGame
    {
        public static void Test()
        {
            AssertResult(new []{ 5, 3, 7, 10}, 15);
            AssertResult(new[]{8, 15, 3, 7}, 22);
        }

        private static void AssertResult(int[] game, int expected)
        {
            var cache = new Dictionary<(int start, int end), int>();
            var actual = FindStrategyRecurse(game, 0, game.Length-1, cache);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        static int Max(params int[] ints)
        {
            return ints.Max();
        }
        
        static int Min(params int[] ints)
        {
            return ints.Min();
        }

        private static int FindStrategyRecurse(int[] game, int start, int end,
            Dictionary<(int start, int end), int> cache)
        {
            if (cache.TryGetValue((start, end), out var result))
                return result;
            if (start > end || start >= game.Length || end < 0)
                result = 0;
            else if (start == end)
                result = game[start];
            else if (start + 1 == end)
                result = Max(game[start], game[end]);
            else
                result = Max(
                    // me took left 
                    game[start] + Min(
                        FindStrategyRecurse(game, start + 2, end, cache),
                        FindStrategyRecurse(game, start + 1, end - 1, cache)),
                    // me took right
                    game[end] + Min(
                        FindStrategyRecurse(game, start + 1, end - 1, cache),
                        FindStrategyRecurse(game, start, end - 2, cache)));
                
            cache[(start, end)] = result;
            return result;
        }

        private static int FindStrategy(int[] game)
        {
            var dp = new int[game.Length, game.Length];

            // we can select left or right 
            // [5], 3, 7, 10   or 5, 3, 7, [10]
            // and then opponent can select l or r
            // [5], 3, 7, (10)   or (5), 3, 7, [10]
            // [5], (3), 7, 10   or 5, 3, (7), [10]
            // and we have sub-problems of n-2

            // dp[i, j] = Max(
            //     dp[i + 1, j - 1] + game[i] - game[j],
            //     dp[i + 2, j] + game[i] - game[i - 1],
            //     dp[i + 1, j - 1] - game[i] + game[j],
            //     dp[i, j - 2] + game[j] - game[j - 1]);
            return 0;
        }
    }
}
