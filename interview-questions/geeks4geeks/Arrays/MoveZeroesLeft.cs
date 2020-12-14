using System;
using System.Collections.Immutable;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class MoveZeroesLeft
    {
        public static void Test()
        {
            Assert(new[] {0}, new[] { 0 });
            Assert(new int[] {}, new int[] {});
            Assert(new int[] { 1, 0 }, new int[] { 0, 1});
            Assert(new int[] { 0, 1 }, new int[] { 0, 1});
            Assert(new int[] { 1, 2, 0, 3 }, new int[] { 0, 1, 2, 3});
            Assert(new int[] { 1, 0, 2, 3 }, new int[] { 0, 1, 2, 3});
            Assert(new int[] { 0, 0, 1, 0 }, new int[] { 0, 0, 0, 1});
        }

        private static void Assert(int[] values, int[] expected)
        {
            var actual = values.ToImmutableArray().ToArray();
            MoveZeroes(actual);
            if (!expected.SequenceEqual(actual))
            {
                Console.WriteLine($" Expected: {expected.Aggregate("", (s, i) => s + i + ", ")}  Actual: {actual.Aggregate("", (s, i) => s + i + ", ")}");
            }
        }

        private static void MoveZeroes(int[] values)
        {
            //  1 2 0 3 0 4
            //          ^             
            //  1 2 0 0 3 4  (+1)
            //        ^   
            //  1 2 0 0 3 4  
            //      ^
            //  1 0 0 2 3 4  
            //    ^
            //  1 0 0 2 3 4  

            //  0 0 1 2 3 4

            int zerosGap = 0;
            for (int i = values.Length - 1; i >= 0; i--)
            {
                if (values[i] == 0)
                {
                    zerosGap++;
                }
                else if(zerosGap > 0)
                {
                    (values[i], values[i + zerosGap]) = (values[zerosGap + i], values[i]);
                }
            }
        }
    }
}
