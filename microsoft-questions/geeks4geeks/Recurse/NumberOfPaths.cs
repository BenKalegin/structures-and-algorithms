using System;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Recurse
{
    class NumberOfPaths
    {
        // The problem is to count all the possible paths from top left to bottom right of a MxN matrix with the constraints
        // that from each cell you can either move to right or down.
        public static void Test()
        {
            AssertResult(new int[,]{
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}

            }, 6);

        }
        private static void AssertResult(int[,] values, int expected)
        {
            var actual1 = CountPathsRecursive(values);
            var actual2 = CountPathsDp2D(values);
            var actual3 = CountPathsDp1D(values);
            if (actual1 != expected || actual2 != expected|| actual3 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual1: {actual1}   actual2: {actual2}  actual3: {actual3} ");

                Console.ResetColor();
            }
        }

        private static int CountPathsRecursive(int[,] values)
        {
            return CountPathsFromRecursive(values, 0, 0);
        }

        private static int CountPathsFromRecursive(int[,] values, int x, int y)
        {
            if (y == values.GetLength(0)-1 && x == values.GetLength(1)-1)
                return 1;
            
            if (y > values.GetLength(0)-1 || x > values.GetLength(1)-1)
                return 0;

            return CountPathsFromRecursive(values, x + 1, y) + CountPathsFromRecursive(values, x, y + 1);
        }

        private static int CountPathsDp2D(int[,] values)
        {
            var count = new int[values.GetLength(0), values.GetLength(1)];

            for (int x = 0; x < values.GetLength(0); x++)
                count[x, 0] = 1;

            for (int y = 0; y < values.GetLength(1); y++)
                count[0, y] = 1;

            for (int x = 1; x < values.GetLength(0); x++)
            {
                for (int y = 1; y < values.GetLength(1); y++)
                {
                    count[x, y] = count[x, y - 1] + count[x - 1, y];
                }
            }

            return count[values.GetLength(0) - 1, values.GetLength(1) - 1];
        }

        private static int CountPathsDp1D(int[,] values)
        {
            var count = new int[values.GetLength(1)];
            count[0] = 1;

            for (int x = 0; x < values.GetLength(0); x++)
                for (int y = 1; y < values.GetLength(1); y++)
                    count[y] = count[y] + count[y-1];

            return count.Last();
        }
    }
}
