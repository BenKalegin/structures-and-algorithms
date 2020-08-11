using System;

namespace microsoft_questions.geeks4geeks
{
    class FindMedianInAStream
    {
        public static void Test()
        {
            // Given an input stream of N integers.
            // The task is to insert these numbers into a new stream and find the median of the stream formed by each insertion of X to the new stream.

            AssertResult(new[] { 5 }, 5);
            AssertResult(new[] { 5, 15 }, 10);
            AssertResult(new[] { 5, 15, 1 }, 5);
            AssertResult(new[] { 5, 15, 1, 3 }, 4);
            AssertResult(new[] { 5, 15, 1, 3, 8 }, 5);

        }
        private static void AssertResult(int[] values, int expected)
        {
            var actual = FindMedian(values);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindMedian(int[] values)
        {
            var smallHalf = new Heap<int>((i1, i2) => i1 >= i2, new int[0], 0);
            var largeHalf = new Heap<int>((i1, i2) => i1 < i2, new int[0], 0);

            foreach(int value in values)
            {
                AddToHeaps(value, smallHalf, largeHalf);
            }

            if (smallHalf.Count > largeHalf.Count)
                return smallHalf.Peek().Value;
            
            else if(smallHalf.Count < largeHalf.Count)
                return largeHalf.Peek().Value;
            
            else if (smallHalf.Count == 0)
                throw new Exception("Stream is empty");
            else
                return (smallHalf.Peek().Value + largeHalf.Peek().Value) / 2;

        }

        private static void AddToHeaps(int value, Heap<int> smallHalf, Heap<int> largeHalf)
        {
            if (value < smallHalf.Peek().GetValueOrDefault(int.MaxValue))
                smallHalf.Insert(value);
            else
                largeHalf.Insert(value);
            if (smallHalf.Count - largeHalf.Count > 1)
                largeHalf.Insert(smallHalf.Extract().Value);
            else if (largeHalf.Count - smallHalf.Count > 1)
                smallHalf.Insert(largeHalf.Extract().Value);
        }
    }
}
