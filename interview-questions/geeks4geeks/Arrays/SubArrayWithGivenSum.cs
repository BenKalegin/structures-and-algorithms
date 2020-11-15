using System;

namespace interview_questions.geeks4geeks.Arrays
{
    class SubArrayWithGivenSum
    {
        // Given an unsorted array A of size N of non-negative integers, find a continuous sub-array which adds to a given number S.

        public static void Test()
        {
            var array1 = new[] {1, 2, 3, 7, 5};
            var sum1 = 12;
            if (FindSubArray(array1, sum1) < 0)
                throw new Exception("");

            array1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            sum1 = 15;
            if (FindSubArray(array1, sum1) < 0)
                throw new Exception("");


        }

        private static int FindSubArray(int[] items, int targetSum)
        {
            var floatingSum = 0;
            int windowStart = 0, windowSize = 0;

            foreach (var i in items)
            {
                while (floatingSum + i > targetSum && windowSize > 0)
                {
                    floatingSum -= items[windowStart++];
                    windowSize--;
                }

                if (floatingSum + i == targetSum)
                    return windowStart;

                floatingSum += i;
                windowSize++;
            }

            return -1;
        }
    }
}
