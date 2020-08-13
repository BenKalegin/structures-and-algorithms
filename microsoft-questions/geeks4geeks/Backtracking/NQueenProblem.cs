using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Backtracking
{
    class NQueenProblem
    {
        // The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
        // Given an integer n, print all distinct solutions to the n-queens puzzle.
        // Each solution contains distinct board configurations of the n-queens’ placement,
        // where the solutions are a permutation of [1,2,3..n] in increasing order,
        // here the number in the ith place denotes that the ith-column queen is placed in the row with that number.
        // For eg below figure represents a chessboard [3 1 4 2].
        public static void Test()
        {
            AssertResult(4, new[] {new[]{2, 4, 1, 3}, new[]{3, 1, 4, 2}});
        }

        private static void AssertResult(int dimension, int[][] expected)
        {
            var actual = FindQueenPlacements(dimension);
            if (!actual.SelectMany(a => a).SequenceEqual(expected.SelectMany(e => e)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {PrintSolution(expected)} actual {PrintSolution(actual)}");

                Console.ResetColor();
            }
        }

        static string PrintSolution(int[][] solutions)
        {
            return string.Join(", ", solutions.Select(a => a.Aggregate("", (s, i) => s + " " + i)));
        }

        private static int[][] FindQueenPlacements(int dimension)
        {
            //  plus diagonals
            //  3 4 5 6
            //  2 3 4 5 
            //  1 2 3 4
            //  0 1 2 3

            //  minus diagonals
            //  -3 -2 -1  0
            //  -2 -1  0  1
            //  -1  0  1  2
            //   0  1  2  3

            // x-y = -3, -2, 1, 0, 1, 2, 3
            // x+y =  0, 1, 2, 3, 4, 5, 6
            (bool[] rows, bool[] columns, bool[] plusDiagonals, bool[] minusDiagonal) underAttack = 
                (new bool[dimension], new bool[dimension], new bool[dimension*2-1], new bool[dimension*2-1]);

            var solutions = new List<int[]>();

            // x, y 0-based
            bool PlacementAllowed(int x, int y) => !underAttack.rows[y] && !underAttack.columns[x] && !underAttack.plusDiagonals[x+y] && !underAttack.minusDiagonal[x - y + dimension-1];

            // x, y 0-based
            void IncludeAttacker(int x, int y, bool value)
            {
                underAttack.rows[y] = value;
                underAttack.columns[x] = value;
                underAttack.plusDiagonals[x + y] = value;
                underAttack.minusDiagonal[x - y + dimension - 1] = value;
            }

            void DeepFirstSearch(List<int> state)
            {
                int y = state.Count;
                for (var x = 0; x < dimension; x++)
                {
                    if (PlacementAllowed(x, y))
                    {
                        if (y == dimension-1)
                            solutions.Add(state.ToArray().Select(i => i+1).Concat(new []{x+1}).ToArray());
                        else
                        {
                            IncludeAttacker(x, y, true);
                            DeepFirstSearch(new List<int>(state) {x});
                            IncludeAttacker(x, y, false);
                        }
                    }
                }
            }

            // 1-4 assigned x positions 
            DeepFirstSearch(new List<int>());
            return solutions.ToArray();
        }
    }
}