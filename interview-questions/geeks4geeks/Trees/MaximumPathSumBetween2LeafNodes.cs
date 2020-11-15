using System;
using System.Linq;

namespace interview_questions.geeks4geeks.Trees
{
    class MaximumPathSumBetween2LeafNodes
    {
        public static void Test()
        {
            AssertResult("-15 5 6 -8 1 3 9 2 6 N N N N N 0 N N N N 4 -1 N N 10 N", 27);
            //AssertResult("3 4 5 -10 4", 16);
        }

        private static void AssertResult(string tree, int expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = FindMaxSum(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindMaxSum(Node root)
        {
            return Traverse(root).maxPath;
        }

        private static (int maxDepth, int maxPath) Traverse(Node tree)
        {
            if (tree == null)
                return (int.MinValue, int.MinValue);

            if (tree.Left == null && tree.Right == null)
                return (tree.Data, int.MinValue);

            var left = Traverse(tree.Left); 
            var right = Traverse(tree.Right);

            var bestChild = left.maxDepth > right.maxDepth ? left : right;

            var maxDepth = tree.Data + bestChild.maxDepth;
            var maxPath = new[] {left.maxPath, right.maxPath, left.maxDepth + right.maxDepth + tree.Data}.Max();

            return (maxDepth, maxPath);
        }
    }
}
