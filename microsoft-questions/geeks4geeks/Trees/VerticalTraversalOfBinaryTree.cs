using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
    class VerticalTraversalOfBinaryTree
    {
        public static void Test()
        {
            AssertResult("1 2 3 4 5 N 6", "4 2 1 5 3 6");
        }

        private static void AssertResult(string tree, string expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = VerticalTraversal(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string VerticalTraversal(Node root)
        {
            var currentLayer = new Queue<(int x, Node n)>();
            var childrenLayer = new Queue<(int x, Node n)>();
            var result = new List<(int x, int y, int data)>();

            currentLayer.Enqueue((0, root));

            int y = 0;
            while (currentLayer.Any())
            {
                while (currentLayer.Any()) {
                    var node = currentLayer.Dequeue();
               
                    result.Add((node.x, y, node.n.Data));

                    if (node.n.Left != null)
                        childrenLayer.Enqueue((node.x - 1, node.n.Left));
                    if (node.n.Right != null)
                        childrenLayer.Enqueue((node.x + 1, node.n.Right));
                }

                var swap = currentLayer;
                currentLayer = childrenLayer;
                childrenLayer = swap;

                y++;
            }

            result.Sort((r1, r2) => r1.x != r2.x ? (r1.x - r2.x) : (r1.y - r2.y));

            return string.Join(" ", result.Select(r => r.data));
        }
    }
}
