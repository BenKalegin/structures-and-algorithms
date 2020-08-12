using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.DP
{
    class LongestCommonSubstring
    {
        // Given two strings X and Y. The task is to find the length of the longest common substring.
        public static void Test()
        {
            AssertResult("ABCDGHQ", "ACDGHR", 4);
        }
        private static void AssertResult(string s1, string s2, int expected)
        {
            var actual1 = FindMemoized(s1, s2);
            var actual2 = FindTabularWay(s1, s2);
            if (actual1 != expected || actual2 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual mem: {actual1} actual tab {actual2}");

                Console.ResetColor();
            }
        }

        private static int FindMemoized(string s1, string s2)
        {
            var cache = new Dictionary<(int i1, int i2), int>();
            FindMemoizedRecursive(cache, s1, s2, s1.Length-1, s2.Length-1);
            return cache.Max(c => c.Value);
        }

        // return max length ending at point i1 i2
        private static int FindMemoizedRecursive(Dictionary<(int i1, int i2), int> cache, string s1, string s2, int i1,
            int i2)
        {
            if (i1 < 0 || i2 < 0)
                return 0;

            if (cache.TryGetValue((i1, i2), out var result))
                return result;
            // guess. lets imagine we have common substring
            // state: i1, i2, length
            // conditions: s1[i1-1] != s2[i2-1] and s1[i1+length] != s2[i2+length]

            // ABCDG H
            // ACDG  HR

            if (s1[i1] == s2[i2])
            {
                result = 1 + FindMemoizedRecursive(cache, s1, s2, i1 - 1, i2 - 1);
            }
            else
            {
                result = 0;
                FindMemoizedRecursive(cache, s1, s2, i1 - 1, i2);
                FindMemoizedRecursive(cache, s1, s2, i1, i2 - 1);
            }

            cache[(i1, i2)] = result;
            return result;
        }

        private static int FindTabularWay(string s1, string s2)
        {
            // dp contains length of continuous string end at i1 for s1 and i2 for s2
            var dp = new int[s1.Length+1, s2.Length+1];
            int max = 0;
            (int i1, int i2) maxPos = (-1, -1);

            for (var i1 = 0; i1 <= s1.Length; i1++)
            {
                for (var i2 = 0; i2 <= s2.Length; i2++)
                {
                    if (i1 == 0 || i2 == 0)
                    {
                        dp[i1, i2] = 0;
                        continue;
                    }

                    if (s1[i1-1] != s2[i2-1])
                    {
                        dp[i1, i2] = 0;
                    }
                    else
                    {
                        dp[i1, i2] = dp[i1-1, i2-1] + 1;
                    }

                    if (dp[i1, i2] > max)
                    {
                        max = dp[i1, i2];
                        maxPos = (i1, i2);
                    }
                }
            }

            return max;
        }
    }
}
