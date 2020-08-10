using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Graph
{
    class DeepFirstSearchGraph
    {
        public static void Test()
        {
            AssertResult(new (int v1, int v2)[]{ (0, 1), (0, 2), (0, 3), (2, 4)}, new[] { 0, 1, 2, 4, 3});
            AssertResult(new (int v1, int v2)[]{ (0, 1), (1, 2), (0, 3)}, new[] { 0, 1, 2, 3});

        }
        private static void AssertResult((int v1, int v2)[] values, int[] expected)
        {
            var graph = new UnDirectionalGraph();
            foreach (var (v1, v2) in values) 
                graph.AddEdge(v1, v2);

            var actual = new List<int>();
            graph.TraverseDeepFirst(0, i => actual.Add(i));

            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + " " + i)} actual: {values.Aggregate("", (s, i) => s + " " + i)}");

                Console.ResetColor();
            }
        }
    }
}
