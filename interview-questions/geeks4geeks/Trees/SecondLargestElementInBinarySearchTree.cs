using System;

namespace interview_questions.geeks4geeks.Trees
{
    class SecondLargestElementInBinarySearchTree
    {
        public static void Test()
        {
            Assert("2 1 N 0", 1);
            Assert("0 N 1 N 2", 1);
            Assert("0 N 2 1 N", 1);
        }


        private static void Assert(string tree, int expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = FindSecond(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static int FindSecond(Node root)
        {
            if (root == null || (root.Right == null && root.Left == null))
                throw new ArgumentException("should be at least 2");

            if (root.Right == null) 
                return MaxElement(root.Left);

            if (root.Right.Right == null)
                if (root.Right.Left != null)
                    return MaxElement(root.Right.Left);
                else
                    return root.Data;

            // 0 1 2 
            while (root.Right.Right != null)
                root = root.Right;
            return root.Data;
        }

        //       0               0              2
        //         1                2         1
        //           2            1         0
        //
        //

        private static int TraverseRightCenterLeft(Node node, Node parent)
        {
            if (node.Right != null)
                return TraverseRightCenterLeft(node.Right, node);

            if (node.Left != null)
                return MaxElement(node.Left);

            if (parent != null)
                return parent.Data;

            throw new Exception("not enough elements");
        }

        private static int MaxElement(Node node)
        {
            while(node.Right?.Right != null)
                node = node.Right;
            return node.Data;
        }
    }
}
