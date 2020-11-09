using System;

namespace microsoft_questions.geeks4geeks.Trees
{
    class CountNumberOfSubTreesHavingGivenSum
    {
        public static void Test()
        {
            AssertResult("5 -10 3 9 8 -4 7", 7, 2);
        }

        private static void AssertResult(string input, int sum, int expected)
        {
            var root = TreeReader.ReadTree(input);
            var actual = FindSubtrees(root, sum);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindSubtrees(Tree root, int sum)
        {
            // go deep first

            int count = 0;

            SummarizeNode(root, ref count, sum);
            return count;
        }

        private static int SummarizeNode(Tree root, ref int count, int sum)
        {
            if (root == null)
                return 0;

            var result = SummarizeNode(root.l, ref count, sum) + SummarizeNode(root.r, ref count, sum) + root.x;
            if (result == sum)
                count++;
            return result;
        }
    }
}
