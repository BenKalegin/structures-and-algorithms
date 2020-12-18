using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_questions.geeks4geeks.Trees
{
    class LevelOrderTraversalOfBinaryTree
    {
        public static void Test()
        {
            AssertResult("20 8 22 5 3 N 25 N N 10 14", new[] {"20", "8, 22", "5, 3, 25", "10, 14"});
        }

        private static void AssertResult(string tree, string[] expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = LevelOrder(root);
            if (actual.Length != expected.Length || !actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string[] LevelOrder(Node root)
        {
            Queue<Node> nextLayer = new Queue<Node>();
            var result = new List<string>();

            nextLayer.Enqueue(root);

            while (nextLayer.Any())
            {
                var thisLayer = nextLayer;
                nextLayer = new Queue<Node>();

                result.Add(string.Join(", ", thisLayer.Select(x => x.Data)));

                while (thisLayer.Any())
                {
                    var node = thisLayer.Dequeue();
                    if (node.Left != null)
                        nextLayer.Enqueue(node.Left);
                    if (node.Right != null)
                        nextLayer.Enqueue(node.Right);
                }
            }

            return result.ToArray();
        }

        private static void Traverse(Node root)
        {
            
        }
    }
}
