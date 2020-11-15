using System;
using System.Collections;
using System.Linq;

namespace interview_questions.geeks4geeks.DP
{
    class PerfectSumProblem
    {
        // Given an array of integers and a sum, the task is to count all subsets of given array with sum equal to given sum.
        public static void Test()
        {
            AssertResult(new []{2, 3, 5, 6, 8, 10}, 10, 3);
            AssertResult(new []{1, 2, 3, 4, 5}, 10, 3);
        }

        private static void AssertResult(int[] array, int targetSum, int expected)
        {
            var actual1 = CountNaive(array, targetSum);
            var actual2 = CountRecurse(array, targetSum);
            var actual3 = CountTabular(array, targetSum);
            if (actual1 != expected || actual2 != expected || actual3 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} naive: {actual1} recursive: {actual2} tabular: {actual3}");

                Console.ResetColor();
            }
        }

        private static int CountTabular(int[] array, int targetSum)
        {
            var dp = new int[array.Length, targetSum+1];

            for (int i = 0; i < array.Length; i++)
            {
                for (int s = 0; s <= targetSum; s++)
                {
                    if (s < array[i])
                        dp[i, s] =  i > 0 ? dp[i - 1, s] : 0;
                    else
                    {
                        var exactMatch = array[i] == s ? 1 : 0;
                        var sumWithOthers = i == 0 ? 0 : Enumerable.Range(1, i).Select(j => dp[j - 1, s - array[j]]).Sum();
                        dp[i, s] = exactMatch + sumWithOthers;

                    }
                }
            }

            return dp[array.Length-1, targetSum];
        }

        private static int CountRecurse(int[] array, int targetSum)
        {
            var included = new BitArray(array.Length);
            return CountRecurseHelper(array, included, 0, targetSum);
        }

        private static int CountRecurseHelper(int[] array, BitArray included, int bit, int targetSum)
        {
            if (bit == array.Length)
            {
                int sum = 0;
                for(int i = 0; i < array.Length; i++)
                    if (included[i])
                        sum += array[i];
                return (sum == targetSum) ? 1 : 0;
            }

            var plusOne = (BitArray)included.Clone();
            plusOne.Set(bit, true);
             
            return CountRecurseHelper(array, included, bit + 1, targetSum) + CountRecurseHelper(array, plusOne, bit + 1, targetSum);
        }

        private static int CountNaive(int[] array, int targetSum)
        {
            var n = array.Length;

            int result = 0;

            var nCombinations = 1 << n;

            for (int i = 0; i < nCombinations; i++) //todo int overflow?
            {
                int sum = 0;
                for (int bit = 0; bit < 32; bit++)
                    if (((uint) 1 << bit & i) != 0)
                    {
                        sum += array[bit];
                    }

                if (sum == targetSum)
                    result++;
            }

            return result;
        }
    }
}
