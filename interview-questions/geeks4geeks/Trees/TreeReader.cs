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
}