using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{
    class Node
    {
        internal int data;
        internal Node left, right;

        internal Node(int item)
        {
            data = item;
            left = right = null;
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

        static Node ReadTree(string s)
        {
            var data = new Queue<int?>(s.Split().Select(s1 => s1 == "N" ? (int?) null : int.Parse(s1)));

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
                    node.left = NextNode();
                    if (node.left != null)
                        nextLevel.Enqueue(node.left);
                    if (data.Any())
                    {
                        node.right = NextNode();
                        if (node.right != null)
                            nextLevel.Enqueue(node.right);
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

        private static void AssertResult(string tree, string expected)
        {
            var root = ReadTree(tree);
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
            string result = root.data.ToString();
            if (root.left != null)
                result += " " + LeftView(root.left);
            else if (root.right != null)
                result += " " + LeftView(root.right);
            return result;
        }
    }
}
