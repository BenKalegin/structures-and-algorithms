using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{

	class CheckIfABinaryTreeIsBstOrNot
	{

		public static void Test()
		{
            AssertResult("3 2 5 1 4", false);
            AssertResult("15 7 16 1 12 N N N 2 10 14", true);
        }

        private static void AssertResult(string tree, bool expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = IsBst(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        static bool IsBst(Node node, int lessThan = int.MaxValue, int moreThan = int.MinValue)
        {
            if (node == null)
                return true;
            if (node.Data <= moreThan || node.Data >= lessThan)
                return false;
            return IsBst(node.Left, node.Data, moreThan) && IsBst(node.Right, lessThan, node.Data);
        }
	}
}
