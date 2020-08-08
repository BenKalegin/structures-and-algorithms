using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{
    class KthSmallestElement
    {
        // Given an array arr[] and a number K where K is smaller than size of array, the task is to find the Kth smallest element in the given array.
        // It is given that all array elements are distinct.
        public static void Test()
        {

            //AssertResult(new[] {3, 2, 1, 4, 5}, 3, 3);

            var random = new Random(1);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"test #{i + 1}");
                int count = random.Next(100) + 1;
                int k = random.Next(count) + 1;
                var values = Enumerable.Range(0, count).Select(_ => random.Next(100)).ToArray();
                var sortResult = FindUsingSort(values, k);
                var actual1 = FindUsingMinHeap(values, k);
                var actual2 = FindUsingMaxHeap(values, k);
                if (sortResult != actual1)
                    Console.WriteLine($"expected: {sortResult} actual: {actual1}");
                if (sortResult != actual2)
                    Console.WriteLine($"expected: {sortResult} actual: {actual2}");
            }

        }

        private static int FindUsingSort(IEnumerable<int> values, int k) => values.OrderBy(i => i).ToArray()[k-1];


        private static void AssertResult(int[] values, int k, int expected)
        {
            var actual = FindUsingMinHeap(values, k);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int? FindUsingMinHeap(int[] values, int k)
        {
            int? result = 0;
            var heap = new Heap((i1, i2) => i1 < i2, values, values.Length);

            for (int j = 0; j < k; j++)
            {
                result = heap.Extract();
            }

            return result;
        }
        private static int? FindUsingMaxHeap(int[] values, int k)
        {
            // max-heap
            var heap = new Heap((i1, i2) => i1 > i2, values, k);
            for (int i = k; i < values.Length; i++)
            {
                if (!(heap.Peek() > values[i])) 
                    continue;
                heap.Extract();
                heap.Insert(values[i]);
            }

            return heap.Extract();
        }
    }

    class Heap
    {
        private readonly Func<int, int, bool> comparator;
        int[] heap;
        private int count;

        public Heap(Func<int, int, bool> comparator, int[] initialPopulation, int notMoreThan)
        {
            this.comparator = comparator;
            var initialSize = Math.Min(notMoreThan, initialPopulation.Length);
            uint binaryCapacity = 1;
            while (binaryCapacity <= initialSize)
            {
                binaryCapacity <<= 1;
            }

            heap = new int[binaryCapacity-1];
            Array.Copy(initialPopulation, heap, initialSize);
            count = initialSize;
            for (int i = heap.Length / 2 -1; i >= 0; i--)
                Percolate(i);

        }

        public void Insert(int element)
        {
            EnsureHeapSize();
            heap[count] = element;
            Sift(count);
            count++;
        }

        public int? Peek()
        {
            return heap?.Any() == true ? heap.FirstOrDefault(): (int?) null;
        }
        public int? Extract()
        {
            if (heap?.Any() != true)
            {
                return null;
            }

            if (count == 1)
            {
                return heap[--count];
            }

            int result = heap[0];
            heap[0] = heap[--count];
            Percolate(0);
            return result;
        }

        private void Percolate(int i)
        {
            var left = Left(i);
            var right = Right(i);

            var smallest = i;

            if (left.HasValue && comparator(heap[left.Value], heap[smallest]))
                smallest = left.Value;

            if (right.HasValue && comparator(heap[right.Value], heap[smallest]))
                smallest = right.Value;

            if (smallest != i)
            {
                Swap(i, smallest);
                Percolate(smallest);
            }
        }

        private void Sift(int i)
        {
            while (i > 0 && comparator(heap[i], heap[Parent(i)]))
            {
                Swap(Parent(i), i);
                i = Parent(i);
            } 
        }

        private void Swap(int parent, int i)
        {
            var temp = heap[parent];
            heap[parent] = heap[i];
            heap[i] = temp;
        }

        private int Parent(int i) => (i - 1) / 2;
        private int? Valid(int i) => (i >= 0 && i < count )? i : (int?) null;
        private int? Left(int i) => Valid(i * 2 + 1);
        private int? Right(int i) => Valid(i * 2 + 2);

        private void EnsureHeapSize()
        {
            if (count >= heap.Length)
                Array.Resize(ref heap, (heap.Length+1) * 2 - 1);
        }
    }
}
