using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Heaps
{
    class RearrangeCharacters
    {
        // Given a string S with repeated characters (only lowercase). The task is to rearrange characters in a string such that no two adjacent characters are same.

        public static void Test()
        {
            AssertResult("geeksforgeeks", true);
        }

        private static void AssertResult(string input, bool expected)
        {
            var actual = Rearrange(input);
            Console.WriteLine($"{input} -> {actual}");
            if ((actual != null) != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string Rearrange(string input)
        {
            var histogram = new Dictionary<char, int>();
            foreach (var c in input)
            {
                histogram[c] = histogram.TryGetValue(c, out var count) ? count + 1 : 1;
            }


            var maxheap = new Heap<(char c, int frequency)>(
                (t1, t2) => t1.frequency >= t2.frequency, 
                histogram.Select(h => (h.Key, h.Value)).ToArray(), 
                histogram.Count);

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                var first = maxheap.Extract();
                if (first == null)
                    break;
                sb.Append(first.Value.c);
                first = (first.Value.c, first.Value.frequency-1);
                var second = maxheap.Extract();
                if (second == null)
                {
                    if (first.Value.frequency == 0)
                        break;
                    return null;
                }

                sb.Append(second.Value.c);
                second = (second.Value.c, second.Value.frequency - 1);
                if (first.Value.frequency > 0)
                    maxheap.Insert(first.Value);
                if (second.Value.frequency > 0)
                    maxheap.Insert(second.Value);
            }

            return sb.ToString();
        }
    }
}
