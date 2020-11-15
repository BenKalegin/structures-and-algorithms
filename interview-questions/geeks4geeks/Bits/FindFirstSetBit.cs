using System;

namespace interview_questions.geeks4geeks.Bits
{
    class FindFirstSetBit
    {
        // Given an integer an N. The task is to print the position of first set bit found from right side in the binary representation of the number.
        public static void Test()
        {
            AssertResult(18, 2);
            AssertResult(12, 3);
        }

        private static void AssertResult(int number, int expected)
        {
            var actual = FindSetBit(number);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual {actual}");

                Console.ResetColor();
            }
        }

        private static int FindSetBit(int number)
        {
            if (number == 0)
                return -1;
            uint unsigned = (uint) number;
            int result = 0;
            while ((unsigned & 1) == 0)
            {
                unsigned >>= 1;
                result++;
            }

            return result + 1;
        }
    }
}
