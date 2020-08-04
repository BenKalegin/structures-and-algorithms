using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace microsoft_questions.geeks4geeks
{
    internal class EquilibriumPoint
    {
        // Given an array A of N positive numbers. The task is to find the position where equilibrium first occurs in the array.
        // Equilibrium position in an array is a position such that the sum of elements before it is equal to the sum of elements after it.
        public static void Test()
        {
            AssertResult(new[] { 2, 1, 0, 2, 1 }, 2);
            AssertResult(new[] { 1, 3, 0, 2, 2 }, 2);
            AssertResult(new[] { 9, 0, 0, 0, 0 }, 0);
            AssertResult(new[] { 1 }, -1);
            AssertResult(new[] { 1, 2 }, -1);
            AssertResult(new[] { 1, 2, 3 }, -1);

        }
        private static void AssertResult(int[] values, int expected)
        {
            var actual = FindEquilibriumPoint(values);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindEquilibriumPoint(int[] values)
        {
            if (values == null || values.Length < 3)
                return -1;

            // find sum in center
            int center = values.Length / 2;
            int leftSum = values.Take(center).Sum();
            int rightSum = values.Skip(center+1).Sum();

            if (leftSum == rightSum)
                return center;

            if (leftSum < rightSum)
            {
                while (center < values.Length-1 && leftSum < rightSum)
                {
                    leftSum += values[center];
                    rightSum -= values[center+1];
                    center++;
                    if (leftSum == rightSum)
                        return center;
                }

                return -1;
            }
            else
            {
                while (center > 0 && leftSum > rightSum)
                {
                    leftSum -= values[center-1];
                    rightSum += values[center];
                    center--;
                    if (leftSum == rightSum)
                        return center;
                }
                return -1;
            }
        }
    }
}
