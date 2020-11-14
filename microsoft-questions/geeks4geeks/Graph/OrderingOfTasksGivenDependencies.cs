using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Graph
{
    class OrderingOfTasksGivenDependencies
    {
        public static void Test()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push("2");
            foreach (var o in stack) 
                Console.WriteLine(o);


            AssertResult(new (int v1, int v2)[] { (1, 0), (2, 0), (3, 1), (3, 2) }, new[] { 0, 1, 2, 3 });
        }
        private static void AssertResult((int v1, int v2)[] values, int[] expected)
        {
            var graph = new DirectionalGraph();
            foreach (var (v1, v2) in values)
                graph.AddEdge(v1, v2);

            var actual = new List<int>();
            graph.TraverseAllDeepFirst(i => actual.Add(i));

            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + " " + i)} actual: {actual.Aggregate("", (s, i) => s + " " + i)}");

                Console.ResetColor();
            }
        }
    }
}
