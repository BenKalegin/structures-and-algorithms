using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
    class BottomViewOfBinaryTree
    {
        public static void Test()
        {
            AssertResult("20 8 22 5 3 N 25 N N 10 14", "5 10 3 14 25");
            AssertResult("20 8 22 5 3 4 25 N N 10 14", "5 10 4 14 25");
        }

        private static void AssertResult(string tree, string expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = BottomView(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string BottomView(Node root)
        {
            var bottomByPos = new Dictionary<int, int>();
            Queue<(Node node, int x)> current = new Queue<(Node node, int x)>();
            current.Enqueue((root, 0));
            Queue<(Node node, int x)> children = new Queue<(Node node, int x)>();

            while (current.Any())
            {
                while (current.Any()) {
                    var entry = current.Dequeue();
                
                    if (entry.node.Left != null)
                        children.Enqueue((entry.node.Left, entry.x-1));
                    if (entry.node.Right != null)
                        children.Enqueue((entry.node.Right, entry.x+1));
                    bottomByPos[entry.x] = entry.node.Data;
                }
                var temp = current;
                current = children;
                children = temp;
            }

            return string.Join(" ", bottomByPos.OrderBy(e => e.Key).Select(e => e.Value));
        }
    }
}
