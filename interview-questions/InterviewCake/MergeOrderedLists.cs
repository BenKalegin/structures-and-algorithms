using System;
using System.Linq;

namespace interview_questions.InterviewCake
{
    class MergeOrderedLists
    {
        public static void Test()
        {
            var list1 = new[] {3, 4, 6, 10, 11, 15};
            var list2 = new[] {1, 5, 8, 12, 14, 17, 19};

            var expected = new[] { 1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 17, 19 };
            var actual = Merge(list1, list2);
            if (!expected.SequenceEqual(actual))
                throw new Exception($"Expected {expected} but got {actual}");
            Console.WriteLine("OK");
        }

        private static int[] Merge(int[] list1, int[] list2)
        {
            if(list1 == null)
                throw new ArgumentNullException(nameof(list1));
            if (list2 == null)
                throw new ArgumentNullException(nameof(list2));

            var result = new int[list1.Length + list2.Length];

            for(int writeIndex = 0, readIndex1 = 0, readIndex2 = 0; writeIndex < result.Length; writeIndex++)
            {
                if (readIndex1 >= list1.Length)
                    result[writeIndex] = list2[readIndex2++];
                else if (readIndex2 >= list2.Length)
                    result[writeIndex] = list1[readIndex1++];
                else if(list1[readIndex1] < list2[readIndex2])
                    result[writeIndex] = list1[readIndex1++];
                else
                    result[writeIndex] = list2[readIndex2++];

            }


            return result;
        }
    }
}
