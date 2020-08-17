using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Arrays
{
    class MergeKSortedArrays
    {
        public static void Test()
        {
            AssertResult(new[,]
            {
                {1, 3, 5, 7},
                {2, 4, 6, 8},
                {0, 9, 10, 11}
            }, new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11});
        }

        private static void AssertResult(int[,] input, int[] expected)
        {
            var actualHeap = SortUsingHeap(input);
            var actualBinary = SortUsingBinaryMerges(input);
            if (!actualHeap.SequenceEqual(expected) || !actualBinary.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"expected: {string.Join(",", expected.Select(e => e.ToString()))} actual heap: {string.Join(",", actualHeap.Select(e => e.ToString()))} actual 2way: {string.Join(",", actualBinary.Select(e => e.ToString()))}");

                Console.ResetColor();
            }
        }

        private static int[] SortUsingHeap(int[,] input)
        {
            // K way merge
            // make min heap (K). keeping row index in value
            // take min value out of heap
            // put it
            // replace with value from the same row
            // it will be K*N operations on heap of size K = K*N * log(K). Extra space O(K)

            var minHeap = new Heap<(int value, int row, int pos)>((i1, i2) => i1.value < i2.value, new (int value, int row, int pos)[] {}, 0);

            for (int i = 0; i < input.GetLength(0); i++)
            {
                minHeap.Insert((input[i, 0], i, 0));
            }

            var result = new int[input.GetLength(0) * input.GetLength(1)];
            
            // writing index to result array
            for (int j = 0; j < result.Length; j++)
            {
                var element = minHeap.Extract()!.Value;

                result[j] = element.value;

                if (element.pos < input.GetLength(1)-1)
                   minHeap.Insert((input[element.row, element.pos+1], element.row, element.pos + 1));
            }

            return result;

        }

        private static int[] SortUsingBinaryMerges(int[,] input)
        {
            // another approach, merge by pairs
            // merge (1,2), (3,4) etc
            // then again
            // first level merges will take 2*N * K/2 = K*N
            // second level merges will take 2 * (2N) * K/4 = K*N
            // ... K*N * logK. No extra space
            // worst case K = 2**X -1 so we hav odd leftover after every merge

            var nArrays = input.GetLength(0);
            var merged = new List<int[]>();
            var leftOvers = new List<int[]>();

            for (int i = 0; i < nArrays / 2; i++)
                merged.Add(Merge2DArray(input, i, i+1));

            if (nArrays % 2 == 1)
                leftOvers.Add(Slice2D(input, nArrays-1));

            while (merged.Count > 1)
            {
                var newMerged = new List<int[]>();
                for (int i = 0; i < merged.Count / 2; i++)
                    newMerged.Add(Merge1DArray(merged[i], merged[i+1]));
                if (merged.Count % 2 == 1)
                    leftOvers.Add(merged.Last());
                merged = newMerged;
            }

            var result = merged.Single();

            foreach (var leftOver in leftOvers) 
                result = Merge1DArray(result, leftOver);

            return result;
        }

        private static int[] Slice2D(int[,] input, int row)
        {
            var result = new int[input.GetLength(1)];

            for (int i = 0; i < input.GetLength(1); i++)
                result[i] = input[row, i];
            return result;
        }

        private static int[] Merge2DArray(int[,] array, int r1, int r2)
        {
            var n = array.GetLength(1);
            var result = new int[n * 2];
            int i1 = 0;
            int i2 = 0;
            int j = 0;

            while (i1 < n && i2 < n)
            {
                if (array[r1, i1] < array[r2, i2])
                    result[j++] = array[r1, i1++];
                else
                    result[j++] = array[r2, i2++];
            }

            while (i1 < n)
                result[j++] = array[r1, i1++];

            while (i2 < n)
                result[j++] = array[r2, i2++];

            return result;
        }
        
        private static int[] Merge1DArray(int[] array1, int[] array2)
        {
            var result = new int[array1.Length + array2.Length];
            int i1 = 0;
            int i2 = 0;
            int j = 0;

            while (i1 < array1.Length && i2 < array2.Length)
            {
                if (array1[i1] < array2[i2])
                    result[j++] = array1[i1++];
                else
                    result[j++] = array2[i2++];
            }

            while (i1 < array1.Length)
                result[j++] = array1[i1++];

            while (i2 < array2.Length)
                result[j++] = array2[i2++];

            return result;
        }
    }
}
