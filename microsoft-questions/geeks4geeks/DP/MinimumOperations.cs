using System;

namespace microsoft_questions.geeks4geeks.DP
{
    class MinimumOperations
    {
        // You are given a number N. You have to find the number of operations required to reach N from 0. You have 2 operations available:
        // 1. Double the number 2. Add one to the number
        public static void Test()
        {
            AssertResult(8, 4);
            AssertResult(7, 5);

        }
        private static void AssertResult(int target, int expected)
        {
            var actual = FindMinimum(target);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindMinimum(int target)
        {
            // guess
            // at the end. we either added or doubled
            // dp[i] = Min(dp[i/2], dp[i-1])


            // bottomup
            // dp[0, 0] = 0
            // dp[0, 1] = 1
            // dp[0, 2] = dp[0, 1] + 1

            int[] dp = new int[target+1];

            dp[0] = 0;
            for (int i = 1; i <= target; i++)
            {
                if (i % 2 == 0 && i >= 2)
                    dp[i] = Math.Min(dp[i-1], dp[i/2]) + 1;
                else
                    dp[i] = dp[i-1] + 1;
            }

            return dp[target];

        }
    }
}
