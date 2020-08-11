using System;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
    internal class Heap<T> where T: struct
    {
        private readonly Func<T, T, bool> comparator;
        T[] heap;
        private int count;
        public int Count => count;

        public Heap(Func<T, T, bool> comparator, T[] initialPopulation, int notMoreThan)
        {
            this.comparator = comparator;
            var initialSize = Math.Min(notMoreThan, initialPopulation.Length);
            uint binaryCapacity = 1;
            while (binaryCapacity <= initialSize)
            {
                binaryCapacity <<= 1;
            }

            heap = new T[binaryCapacity-1];
            Array.Copy(initialPopulation, heap, initialSize);
            count = initialSize;
            for (int i = heap.Length / 2 -1; i >= 0; i--)
                Percolate(i);

        }

        public void Insert(T element)
        {
            EnsureHeapSize();
            heap[count] = element;
            Sift(count);
            count++;
        }

        public T? Peek()
        {
            return heap?.Any() == true ? heap.FirstOrDefault(): (T?) null;
        }
        public T? Extract()
        {
            if (heap?.Any() != true || count == 0)
            {
                return null;
            }

            if (count == 1)
            {
                return heap[--count];
            }

            T result = heap[0];
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