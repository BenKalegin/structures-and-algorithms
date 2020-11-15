using System;

namespace interview_questions.geeks4geeks.Heaps
{
    class KLargestElementFromLargeArray
    {
    }


    public class MaxHeap<T>
    {
        private readonly uint depth;
        private readonly Func<T, T, bool?> comparator;
        private readonly T[] heap;
        private int size = 0;

        public MaxHeap(uint depth, Func<T, T, bool?> comparator)
        {
            this.depth = depth;
            this.comparator = comparator;
            var capacity = 1;
            while (depth > capacity)
            {
                capacity *= 2;
            }

            heap = new T[capacity];
        }

        void Add(T value)
        {
            //    9
            //  5    6
            var insertAt = size++;
            heap[insertAt] = value;
            HeapifyUp(insertAt);
        }

        void Build(T[] initial)
        {
            size = (int) Math.Min(initial.Length, depth);
            Array.Copy(initial, heap, size);
            HeapifyDown(0);
        }

        private void HeapifyDown(int i)
        {
            if (LeftChild(i) < size && comparator(heap[LeftChild(i)], heap[i]) == true)
            {
                // Swap(i, LeftChild(w));
            }
        }


        int Parent(int index) => (index - 1) / 2; 
        int LeftChild(int index) => index * 2 + 1; 
        int RightChild(int index) => index * 2 + 2; 

        private void HeapifyUp(int i)
        {
            if (i == 0)
                return;

            if (comparator(heap[Parent(i)], heap[i]) == true)
            {
                Swap(Parent(i), i);
                HeapifyUp(Parent(i));
            }
        }

        private void Swap(int i1, int i2)
        {
            var swap = heap[i1];
            heap[i1] = heap[i2];
            heap[i2] = swap;
        }
    }
}
