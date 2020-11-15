using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace interview_questions.geeks4geeks.Trees
{
    class TreeReader
    {
        internal static string WriteTree(Node n)
        {
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(n);
            var sb = new List<string>();

            while (nodes.Any())
            {
                var node = nodes.Dequeue();
                sb.Add(node != null ? node.Data.ToString() : "N");
                if (node != null)
                {
                    nodes.Enqueue(node.Left);
                    nodes.Enqueue(node.Right);
                }
            }

            while (sb.Any() && sb.Last() == "N")
                sb.RemoveAt(sb.Count-1);
            return string.Join(" ", sb);
        }

        static NumberFormatInfo format = new NumberFormatInfo(){NegativeSign = "-"};


        internal static Node ReadTree(string s)
        {
            var data = new Queue<int?>(s.Split().Select(s1 => s1 == "N" ? (int?) null : int.Parse(s1, format)));

            if (!data.Any())
                return null;

            Node NextNode()
            {
                var value = data.Dequeue();
                if (value == null) return null;
                return new Node(value.Value);
            }

            Queue<Node> currentLevel = new Queue<Node>();
            Queue<Node> nextLevel = new Queue<Node>();
            Node root = NextNode();

            if (root == null)
                return null;

            currentLevel.Enqueue(root);

            while (data.Any())
            {
                while (currentLevel.Any() && data.Any())
                {
                    var node = currentLevel.Dequeue()!;
                    node.Left = NextNode();
                    if (node.Left != null)
                        nextLevel.Enqueue(node.Left);
                    if (data.Any())
                    {
                        node.Right = NextNode();
                        if (node.Right != null)
                            nextLevel.Enqueue(node.Right);
                    }
                }

                var tmp = nextLevel;
                nextLevel = currentLevel;
                currentLevel = tmp;
                if (data.Any() && !currentLevel.Any())
                    throw new Exception("wrong node data");
            }

            return root;
        }
    }

    class LeftViewOfBinaryTree
    {
        // Given a Binary Tree, print Left view of it. Left view of a Binary Tree is set of nodes visible when tree is visited from Left side.
        // The task is to complete the function leftView(), which accepts root of the tree as argument.
        // Left view of following tree is 1 2 4 8.
        public static void Test()
        {
            AssertResult("1 2 3 4 5 6 7 8", "1 2 4 8");
            AssertResult("7 5 3 6 2 N 1 11 11 6 13 N 6 6 12", "7 5 6 11 6");
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
            if (root == null)
                return "";
            string result = root.Data.ToString();
            if (root.Left != null)
                result += " " + LeftView(root.Left);
            else if (root.Right != null)
                result += " " + LeftView(root.Right);
            return result;
        }
    }
}
