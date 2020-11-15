using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Strings
{
    class PermutationsOfAGivenString
    {
        public static void Test()
        {
            AssertResult("ABC", new[] { "ABC", "ACB", "BAC", "BCA", "CAB", "CBA" });
            AssertResult("ABA", new[] { "ABA", "BAA", "AAB" });
            AssertResult("ABAA", new[] { "ABAA", "BAAA", "AAAB" });
        }

        private static void AssertResult(string s, string[] expected)
        {
            var actual = FindPermutations(s);
            if (!actual.OrderBy(a => a).SequenceEqual(expected.OrderBy(e => e)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {string.Join(", ", expected)} actual {string.Join(", ", actual)}");

                Console.ResetColor();
            }
        }

        private static string[] FindPermutations(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new Exception("Should not be empty");

            var result = new List<string>();
            FindPermutationsRecursive(s, 0, s.Length-1, result);
            return result.ToArray();
        }

        private static void FindPermutationsRecursive(string s, int left, int right, ICollection<string> result)
        {
            if (left == right)
            {
                result.Add(s);
            }
            // ABC
            // A BC
            // A CB
            // B AC
            // B CA
            for (var i = left; i <= right; i++)
            {
                if (s[i] == s[left] && i != left)
                    continue;
                s = Swap(s, i, left);
                FindPermutationsRecursive(s, left + 1, right, result);
                s = Swap(s, i, left);
            }
        }

        private static string Swap(string s, int i, int j)
        {
            var buf = s.ToCharArray();
            var temp = buf[i];
            buf[i] = buf[j];
            buf[j] = temp;
            return new string(buf);
        }
    }
}
