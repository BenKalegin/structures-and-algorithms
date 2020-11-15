using System;

namespace interview_questions.geeks4geeks.Trees
{
    class MirrorTree
    {
        // Given a Binary Tree, convert it into its mirror.
        public static void Test()
        {
            AssertResult("1 3 2 N N 5 4", "1 2 3 4 5");
        }

        private static void AssertResult(string tree, string expected)
        {
            var root = TreeReader.ReadTree(tree);
            Mirror(root);
            var actual = TreeReader.WriteTree(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static void Mirror(Node tree)
        {
            if (tree == null)
                return;
            var swap = tree.Left;
            tree.Left = tree.Right;
            tree.Right = swap;
            Mirror(tree.Left);
            Mirror(tree.Right);
        }
    }
}
