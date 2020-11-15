using System;
using interview_questions.geeks4geeks.Heaps;

namespace interview_questions.geeks4geeks.Greedy
{
    class ActivitySelection
    {
        public static void Test()
        {
            AssertResult(new (int start, int end)[] { (1, 2), (3,4), (2,6), (5, 7), (8, 9), (5, 9) }, 4);
            AssertResult(new (int start, int end)[] { (1, 2), (3,4), (2,3), (5, 6) }, 4);

        }
        private static void AssertResult((int start, int end)[] values, int expected)
        {
            var actual = GreedySelect(values);
            if (!actual.Equals(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int GreedySelect((int start, int end)[] activities)
        {
            var minHeap = new Heap<(int start, int end)>((a1, a2) => a1.end < a2.end, activities, activities.Length);

            var endTime = 0;
            int result = 0;

            while (true)
            {
                var activity = minHeap.Extract();
                if (activity == null)
                    break;

                if (activity.Value.start < endTime)
                    continue;

                endTime = activity.Value.end;
                result++;


            }

            return result;
        }
    }
}
