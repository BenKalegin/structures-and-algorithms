using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Strings
{
    class DesignUrlShortener
    {
        public static void Test()
        {
            AssertResult(12345);
        }

        private static void AssertResult(int input)
        {
            var actual = DecodeInt(EncodeInt(input));
            if (input != actual)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {input} actual: {actual}");

                Console.ResetColor();
            }
        }

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static readonly IDictionary<char, int> CharValues;

        static DesignUrlShortener()
        {
            CharValues = Alphabet.Select((c, i) => Tuple.Create(c, i)).ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);

        }

        private static string EncodeInt(int input)
        {
            if (input < 0)
                throw new Exception("Expected positive number");

            var nChars = Alphabet.Length;

            var chars = new char[6];
            int i = 0;
            // 62 ~ 2**6  62**6 ~ 2*36  > 2**32
            while (input > 0)
            {
                chars[i++] = Alphabet[input % nChars];
                input /= nChars;
                    
            }

            while (i < 6)
                chars[i++] = Alphabet[0];

            return new string(chars);
        }


        private static int DecodeInt(string input)
        {

            if (string.IsNullOrEmpty(input) || input.Length != 6)
                    throw new Exception("Expected 6 char long string");

            int result = 0;
            for (int i = input.Length-1; i >=0; i--)
            {
                result = result * Alphabet.Length + CharValues[input[i]];
            }

            return result;
        }
    }
}
