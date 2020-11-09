using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Trees
{
    [DebuggerDisplay("{" + nameof(x) + "}")]
    class Tree
    {
        internal int x;
        internal Tree l, r;

        internal Tree(int item)
        {
            x = item;
            l = r = null;
        }
    }
    class TreeReader
    {
        internal static string WriteTree(Tree n)
        {
            Queue<Tree> nodes = new Queue<Tree>();
            nodes.Enqueue(n);
            var sb = new List<string>();

            while (nodes.Any())
            {
                var node = nodes.Dequeue();
                sb.Add(node != null ? node.x.ToString() : "N");
                if (node != null)
                {
                    nodes.Enqueue(node.l);
                    nodes.Enqueue(node.r);
                }
            }

            while (sb.Any() && sb.Last() == "N")
                sb.RemoveAt(sb.Count - 1);
            return string.Join(" ", sb);
        }

        private static NumberFormatInfo format = new NumberFormatInfo() { NegativeSign = "-" };


        internal static Tree ReadTree(string s)
        {
            var data = new Queue<int?>(s.Split().Select(s1 => s1 == "N" ? (int?)null : int.Parse(s1, format)));

            if (!data.Any())
                return null;

            Tree NextNode()
            {
                var value = data.Dequeue();
                if (value == null) return null;
                return new Tree(value.Value);
            }

            Queue<Tree> currentLevel = new Queue<Tree>();
            Queue<Tree> nextLevel = new Queue<Tree>();
            Tree root = NextNode();

            if (root == null)
                return null;

            currentLevel.Enqueue(root);

            while (data.Any())
            {
                while (currentLevel.Any() && data.Any())
                {
                    var node = currentLevel.Dequeue()!;
                    node.l = NextNode();
                    if (node.l != null)
                        nextLevel.Enqueue(node.l);
                    if (data.Any())
                    {
                        node.r = NextNode();
                        if (node.r != null)
                            nextLevel.Enqueue(node.r);
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
            var root = TreeReader.ReadTree(tree);
            var actual = FindBiggestSubtree(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }


        private static int FindBiggestSubtree(Tree root)
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

        private static TreeInfo Traverse(Tree node)
        {
            if (node.l == null && node.r == null)
                return new TreeInfo(1, 0);

            if (node.l == null)
            {
                var orphan = Traverse(node.r);
                return new TreeInfo(1, Math.Max(orphan.perfectDeeper, orphan.perfectSoFar));
            }
            else if (node.r == null)
            {
                var orphan = Traverse(node.l);
                return new TreeInfo(1, Math.Max(orphan.perfectDeeper, orphan.perfectSoFar));
            }
            else
            {
                var left = Traverse(node.l);
                var right = Traverse(node.r);

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
