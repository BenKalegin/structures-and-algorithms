using System;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class TrappingRainWater
    {
        // Given an array arr[] of N non-negative integers representing height of blocks at index i as Ai where the width of each block is 1.
        // Compute how much water can be trapped in between blocks after raining.
        public static void Test()
        {
            AssertResult(new[] {3, 0, 0, 2, 0, 4}, 10);
        }

        private static void AssertResult(int[] blocks, int expected)
        {
            var actual = FindWaterVolume(blocks);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindWaterVolume(int[] blocks)
        {
            int left = 1;
            int right = blocks.Length - 2;
            int maxLeft = blocks.First();
            int maxRight = blocks.Last();
            int volumeLeft = 0;
            int volumeRight = 0;

            while (left < right)
            {
                if (blocks[left] < blocks[right])
                {
                    if (blocks[left] > maxLeft)
                        maxLeft = blocks[left];
                    else
                        volumeLeft += maxLeft - blocks[left];
                    left++;
                }
                else
                {
                    if (blocks[right] > maxRight)
                        maxRight = blocks[right];
                    else
                        volumeRight += maxRight - blocks[right];
                    right--;
                }
            }

            return volumeLeft + volumeRight;
        }
    }
}
