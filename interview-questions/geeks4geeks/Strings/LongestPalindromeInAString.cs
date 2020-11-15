using System;
using System.Collections.Generic;

namespace interview_questions.geeks4geeks.Strings
{
    class LongestPalindromeInAString
    {
        // Given a string S, find the longest palindromic substring in S. Substring of string S: S[ i . . . . j ] where 0 ≤ i ≤ j < len(S).
        // Palindrome string: A string which reads the same backwards. More formally, S is palindrome if reverse(S) = S.
        // Incase of conflict, return the substring which occurs first ( with the least starting index ).

        public static void Test()
        {
            AssertResult("aaaabbaa", "aabbaa");
        }

        private static void AssertResult(string s, string expected)
        {
            var actual1 = FindLongestNaive(s);
            var actual2 = FindLongestRecursive(s);
            var actual3 = FindLongestTabular(s);
            if (actual1 != expected || actual2 != expected || actual3 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} naive: {actual1} recursive: {actual2} tabular: {actual3}");

                Console.ResetColor();
            }
        }

        private static string FindLongestNaive(string s)
        {
            int maxLength = 1;
            int maxPos = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // i is starting pos of palindrome to check
                for (int j = i + 1; j < s.Length; j++)
                {
                    // j is ending pos of palindrome 
                    bool isPalindrome = true;
                    for (var k = 0; k < (j-i)/2; k++ )
                    {
                        // k index inside palindrome candidate to check
                        if (s[i + k] != s[j - k])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }

                    if (isPalindrome && (j - i + 1) > maxLength)
                    {
                        maxLength = j - i + 1;
                        maxPos = i;
                    }
                }
            }

            return s.Substring(maxPos, maxLength);
        }

        private static string FindLongestRecursive(string s)
        {
            var cache = new Dictionary<(int start, int end), (int start, int end)>();
            var (start, end) = FindLongestRecursiveHelper(s, 0, s.Length - 1, cache);
            return s.Substring(start, end - start + 1);
        }

        private static (int start, int end) FindLongestRecursiveHelper(string s, int start, int end,
            Dictionary<(int start, int end), (int start, int end)> cache)
        {
            if (cache.TryGetValue((start, end), out var result))
                return result;


            (int start, int end) DoSearch()
            {
                if (start == end)
                    return (start, start);

                if (start + 1 == end)
                    if (s[start] == s[end])
                        return (start, start + 1);
                    else
                        return (start, 0);

                if (s[start] == s[end])
                {
                    var (start1, end1) = FindLongestRecursiveHelper(s, start + 1, end - 1, cache);
                    if (start1 == start + 1 && end1 == end - 1)
                        return (start, end);
                }

                var left = FindLongestRecursiveHelper(s, start, end - 1, cache);
                if (s[start] == s[end - 1])
                {
                    if (left.start == start && left.end == end - 1)
                        return (start, end - 1);
                }

                var right = FindLongestRecursiveHelper(s, start + 1, end, cache);
                if (s[start + 1] == s[end])
                {
                    if (right.start == start + 1 && right.end == end)
                        return (start + 1, end);
                }

                return left.end - left.start > right.end - right.start ? left : right;
            }

            result = DoSearch();
            cache.Add((start, end), result);
            return result;
        }

        private static string FindLongestTabular(string s)
        {
            var n = s.Length;
            bool[,] dp = new bool[n, n];
            int maxIndex = 0;
            int maxlength = 1;

            for (int i = 0; i < n; i++)
                dp[i, i] = true;

            for (int i = 0; i < n-1; i++) 
                    dp[i, i+1] = s[i] == s[i+1];


            //   a a a a b b a a
            // a 1 1 1 1 0 0 0 0
            // a 0 1 1 1 0 0 0 0
            // a 0 0 1 1 0 0 0 1
            // a 0 0 0 1 1 0 1 0
            // b 0 0 0 0 1 1 0 0
            // b 0 0 0 0 0 1 1 0
            // a 0 0 0 0 0 0 1 1
            // a 0 0 0 0 0 0 0 1




            for (int k = 2; k < n; k++)
                for (int i = 0; i < n - k; i++)
                {
                    int j = i + k;
                    var palindrome = s[i] == s[j] && dp[i + 1, j - 1];
                    dp[i, j] = palindrome;
                    
                    if (palindrome && k + 1 > maxlength)
                    {
                        maxlength = k + 1;
                        maxIndex = i;
                    }
                }

            return s.Substring(maxIndex, maxlength);
        }

    }
}
