using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{
    class ReverseWordsInString
    {
        // Given a String of length S, reverse the whole string without reversing the individual words in it. Words are separated by dots.
        public static void Test()
        {
            AssertResult("i.like.this.program.very.much", "much.very.program.this.like.i");
        }
        private static void AssertResult(string input, string expected)
        {
            var actual = ReverseWords(input);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string ReverseWords(string input) => string.Join(".", input.Split('.').Reverse());
    }
}
