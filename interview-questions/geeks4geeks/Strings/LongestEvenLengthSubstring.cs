using System;

namespace interview_questions.geeks4geeks.Strings
{
    class LongestEvenLengthSubstring
    {
        // For given string ‘str’ of digits, find length of the longest substring of ‘str’,
        // such that the length of the substring is 2k digits and sum of left k digits is equal to the sum of right k digits.

        public static void Test()
        {
            AssertResult("1234123", 4);
            AssertResult("123123", 6);
            AssertResult("1538023", 4);
        }

        private static void AssertResult(string s, int expected)
        {
            var naive = FindNaive(s);
            var recursive = FindRecursive(s);
            if (naive != expected || recursive != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {naive} recursive {recursive}");

                Console.ResetColor();
            }
        }

        private static int FindRecursive(string s)
        {
            var maxLength = 0;

            int n = s.Length;
            // offset is left center of radial expansion
            for (int offset = 0; offset < n - 1; offset++)
            {
                var leftSum = 0;
                var rightSum = 0;

                for (int radius = 0; radius <= n / 2; radius++) // TODO < or <=
                {
                    if (offset - radius < 0)
                        break;
                    if (offset + 1 + radius >= n)
                        break;

                    leftSum += s[offset - radius] - '0';
                    rightSum += s[offset + 1 + radius] - '0';
                    if (maxLength < radius+1 && leftSum == rightSum)
                    {
                        maxLength = radius+1;
                    }
                }
            }

            return maxLength * 2;
        }

        private static int FindNaive(string s)
        {
            // try max length, then smaller
            int n = s.Length;
            for (int k = n / 2; k >= 1; k--)  
            {
                for (int offset = 0; offset <= n - k * 2; offset++)  // 2 4 6 O(N**2)
                {
                    int sum = 0;
                    for (int i = 0; i < k; i++)
                        sum += s[offset+i] - '0';
                    for (int i = k; i < k * 2; i++)
                        sum -= s[offset+i] - '0';
                    if (sum == 0)
                        return k*2;
                }
            }
            return 0;
        }
    }
}
