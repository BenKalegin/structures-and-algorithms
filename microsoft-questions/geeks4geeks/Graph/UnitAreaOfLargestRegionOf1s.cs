using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace microsoft_questions.geeks4geeks.Graph
{
    class UnitAreaOfLargestRegionOf1s
    {
        public static void Test()
        {
            AssertResult(new[,]
            {
                {1, 1, 0},
                {0, 0, 1},
                {1, 0, 1}
            }, 4);
        }
        private static void AssertResult(int[,] values, int expected)
        {
            var actual = FindLargest(values);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindLargest(int[,] values)
        {
            var nx = values.GetLength(0);
            var ny = values.GetLength(1);
            var visited = new HashSet<(int x, int y)>();
            var maxArea = 0;

            for (int x = 0; x < nx; x++)
                for (int y = 0; y < ny; y++)
                {
                    if (values[x, y] != 0)
                    {
                        int area = Traverse(values, visited, x, y);
                        if (area > maxArea)
                            maxArea = area;
                    }

                }

            return maxArea;
        }

        private static int Traverse(int[,] values, HashSet<(int x, int y)> visited, int x, int y)
        {
            var nx = values.GetLength(0);
            var ny = values.GetLength(1);
            // DFS


            IEnumerable<(int x, int y)> FindNeighbors(int x, int y)
            {

                for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                    if (!(dx == 0 && dy == 0))
                    {
                        (int x, int y) p = (x + dx, y + dy);
                        if (p.x >= 0 && p.x < nx && p.y >= 0 && p.y < ny && values[p.x, p.y] == 1 && !visited.Contains(p))
                            yield return p;
                    }
            }


            var points = new Queue<(int x, int y)>();
            int result = 0;

            points.Enqueue((x, y));
            
            while (points.Any())
            {
                var p = points.Dequeue();
                if (!visited.Contains(p))
                {
                    visited.Add(p);
                    result++;
                    foreach (var neighbor in FindNeighbors(p.x, p.y))
                        points.Enqueue(neighbor);
                }
            }

            return result;
        }
    }
}
