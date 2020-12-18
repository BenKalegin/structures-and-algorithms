using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using interview_questions.geeks4geeks.Trees;

namespace interview_questions.geeks4geeks.Strings
{
    class ReverseWordInASentence
    {
        // Reverse the order of words in a given sentence (an array of characters). 
        public static void Test()
        {
            Assert("Hello world", "world Hello");
            Assert(" Hello world", "world Hello ");
            Assert("Helloworld", "Helloworld");
            Assert("Hello world ", " world Hello");
            Assert("Hello   world", "world   Hello");
        }

        private static void Assert(string input, string expected)
        {
            var actual = Reverse(input);
            if (expected != actual)
            {
                Console.WriteLine($"Expected: {expected} Actual: {actual}");
            }
        }


        private static void ReverseInPlace(char[] s, int @from, int to)
        {
            // 0..1: 1
            // 0..2: 1
            // 7..9:  1
            
            for (int i = 0; i < (to - from + 1) / 2; i++)
                (s[from + i], s[to - i]) = (s[to - i], s[from + i]);
        }

        private static string Reverse(string input)
        {
            var chars = input.ToCharArray();
            ReverseInPlace(chars, 0, chars.Length - 1);
            
            // search for word boundaries 
            bool? outsideWord = null;
            int lastWordStart = 0;
            
            for (int i = 0; i < chars.Length; i++)
            {
                bool isSpace = chars[i] == ' '; // or tab?
                if (isSpace)
                {
                    if (outsideWord == null)
                        outsideWord = true;
                    else if (outsideWord == false)
                    {
                        ReverseInPlace(chars, lastWordStart, i-1);
                        outsideWord = true;
                    }
                }
                else
                {
                    if (outsideWord != false)
                    {
                        outsideWord = false;
                        lastWordStart = i;
                    }
                }
            }

            if (outsideWord == false)
            {
                ReverseInPlace(chars, lastWordStart, chars.Length-1);
            }

            return new string(chars);
        }
    }
}
