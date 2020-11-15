using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    /// <summary>
    /// Given an array A of N elements. Find the majority element in the array.
    /// A majority element in an array A of size N is an element that appears more than N/2 times in the array.
    /// </summary>
    class MajorityElement
    {
        public static void Test()
        {
            AssertResult(new[] { 3, 1, 3, 3, 2 }, 3);
            AssertResult(new[] { 1, 2, 3 }, -1);
        }

        private static void AssertResult(int[] array, int expected)
        {
            var actual1 = FindMajorityUsingHashMap(array);
            var actual2 = FindMajorityUsingMoore(array);
            if (actual1 != expected || actual2 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual hashmap: {actual1} actual Moore {actual2}");

                Console.ResetColor();
            }
        }

        private static int FindMajorityUsingMoore(int[] array)
        {
            int value = 0;
            int count = 0;
            foreach (var i in array)
            {
                if (count == 0)
                {
                    value = i;
                    count = 1;
                }else if (value == i)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            if (array.Count(i => i == value) > array.Length / 2)
                return value;
            return -1;
        }

        private static int FindMajorityUsingHashMap(int[] array)
        {
            var histogram = new Dictionary<int, int>();
            foreach (var i in array)
                if (histogram.TryGetValue(i, out int count))
                    histogram[i] = count + 1;
                else
                    histogram[i] = 1;
            foreach (var pair in histogram)
            {
                if (pair.Value > array.Length / 2)
                    return pair.Key;
            }

            return -1;
        }
    }
}
