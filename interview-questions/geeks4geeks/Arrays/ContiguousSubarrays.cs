using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    // You are given an array arr of N integers. For each index i, you are required to determine the number of contiguous subarrays that fulfills the following conditions:
    // The value at index i must be the maximum element in the contiguous subarrays, and
    // These contiguous subarrays must either start from or end on index i.

    // arr = [3, 4, 1, 6, 2]
    // output = [1, 3, 1, 5, 1]
    // Explanation:
    // For index 0 - [3] is the only contiguous subarray that starts(or ends) with 3, and the maximum value in this subarray is 3.
    // For index 1 - [4], [3, 4], [4, 1]
    // For index 2 - [1]
    // For index 3 - [6], [6, 2], [1, 6], [4, 1, 6], [3, 4, 1, 6]
    // For index 4 - [2]

    class ContiguousSubArrays
    {
        public static void Test()
        {
            AssertResult(new[] { 3, 4, 1, 6, 2 }, new [] { 1, 3, 1, 5, 1 });
        }
        private static void AssertResult(int[] values, int[] expected)
        {
            var actual = CountSubarrays(values);
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int[] CountSubarrays(int[] arr)
        {
            var stack = new Stack<int>();
            int[] ans = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                while (stack.Any() && arr[stack.Peek()] < arr[i])
                {
                    ans[i] += ans[stack.Pop()];
                }
                stack.Push(i);
                ans[i]++;
            }
            stack.Clear();
            int[] temp = new int[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (stack.Any() && arr[stack.Peek()] < arr[i])
                {
                    int idx = stack.Pop();
                    ans[i] += temp[idx];
                    temp[i] += temp[idx];
                }
                stack.Push(i);
                temp[i]++;
            }
            return ans;
        }
    }
}
