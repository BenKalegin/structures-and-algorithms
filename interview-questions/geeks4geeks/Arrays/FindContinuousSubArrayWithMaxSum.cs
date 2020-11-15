using System;

namespace interview_questions.geeks4geeks.Arrays
{
    class FindContinuousSubArrayWithMaxSum
    {
        public static void Test()
        {
            Test(new[] {-1, 4, -3, 5, 1, -1, -2, 6, -3, 11, 8, 0, -5, 4, 2, -3}, 27);
            Test(new[] { 1, -5, 7 }, 7);
        }

        private static void Test(int[] values, int expectedSum)
        {
            var actual = FindMaxContinuousSum(values);
            if (actual != expectedSum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expectedSum} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindMaxContinuousSum(int[] values)
        {
            int globalMaxSum = int.MinValue;
            int localMaxSum = 0;

            foreach (var i in values)
            {
                localMaxSum += i;
                if (localMaxSum > globalMaxSum)
                    globalMaxSum = localMaxSum;

                if (localMaxSum < 0)
                    localMaxSum = 0;
            }

            return globalMaxSum;
        }
    }
}
