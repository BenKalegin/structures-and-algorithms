using System;

namespace microsoft_questions.geeks4geeks.DivideAndConquer
{
    class SearchInARotatedArray
    {
        // Given a sorted and rotated array A of N distinct elements which is rotated at some point, and given an element K.
        // The task is to find the index of the given element K in the array A.
        public static void Test()
        {
            AssertResult(new[]{ 5, 6, 7, 8, 9, 10, 1, 2, 3}, 10, 5);
        }
        private static void AssertResult(int[] values, int searchFor, int expected)
        {
            var actual = FindIndex(values, searchFor);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual {actual} ");

                Console.ResetColor();
            }
        }

        private static int FindIndex(int[] values, int searchFor)
        {
            return FindRecurse(values, 0, values.Length-1, searchFor);
        }

        private static int FindRecurse(int[] values, int start, int end, int searchFor)
        {
            if (start == end)
                return start;

            var middle = (start + end) / 2;

            if (values[start] < values[middle])
            {
                // no shift point on the left
                if (values[middle] >= searchFor && searchFor >= values[start])
                    return FindBinary(values, start, middle, searchFor);
                else
                    return FindRecurse(values, middle, end, searchFor);
            }
            else
            {
                // shift point on the left
                if (searchFor >= values[middle] && searchFor <= values[end])
                    return FindBinary(values, middle, end, searchFor);
                else
                    return FindRecurse(values, start, middle, searchFor);
            }
        }

        private static int FindBinary(int[] values, int start, int end, int searchFor)
        {
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (values[mid] == searchFor)
                    return mid;

                if (searchFor < values[mid])
                {
                    end = mid-1;
                }
                else
                {
                    start = mid+1;
                }
            }

            return -1;
        }
    }
}
