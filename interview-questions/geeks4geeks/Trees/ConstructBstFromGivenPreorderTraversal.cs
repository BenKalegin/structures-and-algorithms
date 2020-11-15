using System.Linq;

namespace interview_questions.geeks4geeks.Trees
{
    class ConstructBstFromGivenPreorderTraversal
    {
        class TreeNode
        {
            private readonly int Payload;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int payload)
            {
                Payload = payload;
            }
        }


        public static void Test()
        {
            Test(10, 5, 1, 7, 40, 50);
        }

        public static void Test(params int[] values)
        {
            var root = ConstructTree1(values);
        }

        private static TreeNode ConstructTree1(int[] values)
        {
            if (values?.Any() != true)
                return null;

            var root = new TreeNode(values.First());

            return null;
        }
    }
}
