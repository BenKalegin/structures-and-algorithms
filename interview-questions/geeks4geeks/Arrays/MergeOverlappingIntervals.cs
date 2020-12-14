using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class MergeOverlappingIntervals
    {
        public class Interval
        {
            public int Start;
            public int End;
        }
        public static void Test()
        {
            Assert(new[] {(0, 1), (2, 3)}, new[]{(0,1), (2, 3)});
            Assert(new[] {(0, 1), (1, 5), (2, 3)}, new[]{(0, 5)});
            Assert(new[] {(0, 1), (1, 2), (4, 5)}, new[]{(0, 2), (4,5)});
            Assert(new[] { (1, 5), (3, 7), (4, 6), (6, 8) }, new[] { (1, 8) });
            Assert(new[] { (10, 12), (12, 15) }, new[] { (10, 15) });
            Assert(new[] { (0, 1) }, new[] { (0, 1) });
        }

        private static void Assert((int, int)[] input, (int, int)[] expected)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(expected));

            var actual = Merge(input);
            if (!expected.SequenceEqual(actual))
            {
                Console.WriteLine($"Expected: {expected.Aggregate("", (s,i) => s + i.Item1 + "-" + i.Item2 + ", ")} actual: {actual.Aggregate("", (s, i) => s + i.Item1 + "-" + i.Item2 + ", ")}");
            }



        }

        private static (int, int)[] Merge((int, int)[] input)
        {
            if (input.Length < 2)
                return input;

            var result = new List<(int, int)> {input.First()};


            for (var i = 1; i < input.Length; i++)
            {
                var latest = result[^1];
                if (Intersects(latest, input[i]))
                {
                    if (input[i].Item2 > latest.Item2)
                        result[^1] = (latest.Item1, input[i].Item2);
                }
                else
                {
                    result.Add(input[i]);
                }
            }

            return result.ToArray();
        }

        private static bool Intersects((int, int) i1, (int, int) i2)
        {
            return i2.Item1 <= i1.Item2;
        }
    }
}
