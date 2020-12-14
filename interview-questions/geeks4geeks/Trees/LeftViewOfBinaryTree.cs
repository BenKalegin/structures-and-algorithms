using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Trees
{
    class LeftViewOfBinaryTree
    {
        // Given a Binary Tree, print Left view of it. Left view of a Binary Tree is set of nodes visible when tree is visited from Left side.
        // The task is to complete the function leftView(), which accepts root of the tree as argument.
        // Left view of following tree is 1 2 4 8.
        public static void Test()
        {
            AssertResult("1 2 3 4 5 6 7 8", "1 2 4 8");
            AssertResult("7 5 3 6 2 N 1 11 11 6 13 N 6 6 12", "7 5 6 11 6");
            AssertResult("1 2 3 4 N 6 N N 5 N 7 N 8", "1 2 4 5 8");
        }

        private static void AssertResult(string tree, string expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = LeftView(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string LeftView(Node root)
        {
            var result = new List<int?>();
            LeftViewRecursive(root, result, 0);
            return string.Join(' ', result.Select(r => r.ToString()));
        }

        private static void LeftViewRecursive(Node node, List<int?> result, int depth)
        {
            if (result.Count <= depth)
                result.Add(node.Data);

            if (node.Left != null)            
                LeftViewRecursive(node.Left, result, depth+1);
            if (node.Right != null)            
                LeftViewRecursive(node.Right, result, depth+1);
        }
    }
}
