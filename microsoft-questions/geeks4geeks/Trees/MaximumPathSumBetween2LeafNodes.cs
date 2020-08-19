using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Trees
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

        private static (int maxDepth, int maxPath) Traverse(Node node)
        {
            if (node == null)
                return (int.MinValue, int.MinValue);

            if (node.Left == null && node.Right == null)
                return (node.Data, int.MinValue);

            var left = Traverse(node.Left); 
            var right = Traverse(node.Right);

            var bestChild = left.maxDepth > right.maxDepth ? left : right;

            var maxDepth = node.Data + bestChild.maxDepth;
            var maxPath = new[] {left.maxPath, right.maxPath, left.maxDepth + right.maxDepth + node.Data}.Max();

            return (maxDepth, maxPath);
        }
    }
}
