using System;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    internal class SortArrayOf0s1s2s
    {
        // Given an array A of size N containing 0s, 1s, and 2s; you need to sort the array in ascending order.
        public static void Test()
        {
            AssertResult(new[] { 2, 1, 0, 2, 1 }, new[]{0, 1, 1, 2, 2});

        }
        private static void AssertResult(int[] values, int[] expected)
        {
            Sort(values);
            if (!values.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {values}");

                Console.ResetColor();
            }
        }

        private static void Sort(int[] values)
        {
            var histogram = new[] {0, 0, 0};
            foreach (var value in values)
            {
                if(value > 2 || value < 0)
                    throw new Exception($"incorrect input number {value}");
                histogram[value]++;
            }

            int writePos = 0;

            for (int i = 0; i <= 2; i++)
            for (int j = 0; j < histogram[i]; j++)
                values[writePos++] = i;


        }
    }
}
