using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace interview_questions.geeks4geeks.Trees
{
    [DebuggerDisplay("{" + nameof(X) + "}")]
    class Tree1
    {
        internal int X;
        internal Tree1 L, R;

        internal Tree1(int item)
        {
            X = item;
            L = R = null;
        }
    }
    class TreeReader1
    {
        internal static string WriteTree(Tree1 n)
        {
            Queue<Tree1> nodes = new Queue<Tree1>();
            nodes.Enqueue(n);
            var sb = new List<string>();

            while (nodes.Any())
            {
                var node = nodes.Dequeue();
                sb.Add(node != null ? node.X.ToString() : "N");
                if (node != null)
                {
                    nodes.Enqueue(node.L);
                    nodes.Enqueue(node.R);
                }
            }

            while (sb.Any() && sb.Last() == "N")
                sb.RemoveAt(sb.Count - 1);
            return string.Join(" ", sb);
        }

        private static NumberFormatInfo format = new NumberFormatInfo() { NegativeSign = "-" };


        internal static Tree1 ReadTree(string s)
        {
            var data = new Queue<int?>(s.Split().Select(s1 => s1 == "N" ? (int?)null : int.Parse(s1, format)));

            if (!data.Any())
                return null;

            Tree1 NextNode()
            {
                var value = data.Dequeue();
                if (value == null) return null;
                return new Tree1(value.Value);
            }

            Queue<Tree1> currentLevel = new Queue<Tree1>();
            Queue<Tree1> nextLevel = new Queue<Tree1>();
            Tree1 root = NextNode();

            if (root == null)
                return null;

            currentLevel.Enqueue(root);

            while (data.Any())
            {
                while (currentLevel.Any() && data.Any())
                {
                    var node = currentLevel.Dequeue()!;
                    node.L = NextNode();
                    if (node.L != null)
                        nextLevel.Enqueue(node.L);
                    if (data.Any())
                    {
                        node.R = NextNode();
                        if (node.R != null)
                            nextLevel.Enqueue(node.R);
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

    class BiggestPerfectSubtree
    {
        public static void Test()
        {
            AssertResult("1 2 3 N 4 5 6 N N 7 8 9 10 N N N N N N 11 N N N", 7);
        }

        private static void AssertResult(string tree, int expected)
        {
            var root = TreeReader1.ReadTree(tree);
            var actual = FindBiggestSubtree(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }


        private static int FindBiggestSubtree(Tree1 root)
        {
            var best = Traverse(root);
            return (1 << Math.Max(best.perfectSoFar, best.perfectDeeper)) - 1;
        }

        [DebuggerDisplay("{" + nameof(perfectSoFar) + ", " + nameof(perfectSoFar) + "}")]
        class TreeInfo
        {
            public int perfectSoFar;
            public int perfectDeeper;

            public TreeInfo(int perfectSoFar, int perfectDeeper)
            {
                this.perfectSoFar = perfectSoFar;
                this.perfectDeeper = perfectDeeper;
            }
        }

        private static TreeInfo Traverse(Tree1 node)
        {
            if (node.L == null && node.R == null)
                return new TreeInfo(1, 0);

            if (node.L == null)
            {
                var orphan = Traverse(node.R);
                return new TreeInfo(1, Math.Max(orphan.perfectDeeper, orphan.perfectSoFar));
            }
            else if (node.R == null)
            {
                var orphan = Traverse(node.L);
                return new TreeInfo(1, Math.Max(orphan.perfectDeeper, orphan.perfectSoFar));
            }
            else
            {
                var left = Traverse(node.L);
                var right = Traverse(node.R);

                var deeperBelow = new []{left.perfectDeeper, right.perfectDeeper, left.perfectSoFar, right.perfectSoFar}.Max();

                if (left.perfectSoFar != right.perfectSoFar)
                {
                    // when anything non-perfect, return deeper one
                    return new TreeInfo(0, deeperBelow);
                }
                else
                {
                    // both subtrees have perfect node head

                    var perfectOnLevel = left.perfectSoFar <= right.perfectSoFar 
                        ? new TreeInfo(left.perfectSoFar+1, deeperBelow) 
                        : new TreeInfo(right.perfectSoFar+1, deeperBelow);

                    return perfectOnLevel;
                }

            }
        }
    }
}
