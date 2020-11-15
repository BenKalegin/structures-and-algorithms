using System;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class InversionOfTheArray
    {
        //Given an array of positive integers. The task is to find inversion count of array.
        // Inversion Count : For an array, inversion count indicates how far (or close) the array is from being sorted.
        // If array is already sorted then inversion count is 0. If array is sorted in reverse order that inversion count is the maximum. 
        // Formally, two elements a[i] and a[j] form an inversion if a[i] > a[j] and i < j. 


        // 3 2 1 4 5  = 3
        public static void Test()
        {
            AssertResult(new[] {5, 4, 3, 2, 1},  10);
            AssertResult(new[] { 1, 2, 3, 4, 5 }, 0);
            AssertResult(new[] { 3, 2, 1, 4, 5 }, 3);
        }




        private static void AssertResult(int[] values, int expectedInversions)
        {
            var actual = NumberOfInversions(values);
            if (actual != expectedInversions)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expectedInversions} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int NumberOfInversions(int[] values)
        {
            if (values == null)
                return 0; // or throw exception depending on requirements

            if (!values.Any())
                return 0;

            int[] sorted = new int[values.Length];

            return MergeSort(values, sorted, 0, values.Length-1);
        }

        private static int MergeSort(int[] values, int[] sorted, int left, int right)
        {
            if (left >= right)
                return 0;

            var midpoint = (left + right) / 2;
            var prefix = MergeSort(values, sorted, left, midpoint);
            var suffix = MergeSort(values, sorted, midpoint+1, right);

            var result = Merge(values, sorted, left, midpoint+1, right);

            return prefix + suffix + result;
        }

        private static int Merge(int[] values, int[] sorted, int left, int mid, int right)
        {
            int inversionCount = 0;


            int i1 = left;
            int i2 = mid;
            int o = left;

            while (i1 < mid && i2 <= right)
            {
                if (values[i1] < values[i2] )
                    sorted[o++] = values[i1++];
                else
                {
                    sorted[o++] = values[i2++];
                    inversionCount += mid - i1;
                }
            }

            while (i1 < mid)
                sorted[o++] = values[i1++];

            while (i2 <= right)
                sorted[o++] = values[i2++];

            // copy sorted values back
            Array.Copy(sorted, left, values, left, right - left + 1);

            return inversionCount;
        }
    }
}
