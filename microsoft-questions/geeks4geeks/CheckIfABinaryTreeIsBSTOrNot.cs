using System;
using System.Diagnostics;

namespace microsoft_questions.geeks4geeks
{

	class BinaryIntTreeNode
	{
		public BinaryIntTreeNode Left;
		public BinaryIntTreeNode Right;
		public int Key;

		public BinaryIntTreeNode(BinaryIntTreeNode left, BinaryIntTreeNode right, int key)
		{
			Left = left;
			Right = right;
			Key = key;
		}
	}

	class CheckIfABinaryTreeIsBSTOrNot
	{

		public static void Test()
		{
			//    4
			//  2   5 
			// 1 3 
			// 
			var n31 = new BinaryIntTreeNode(null, null, 1);
			var n32 = new BinaryIntTreeNode(null, null, 3);
			var n21 = new BinaryIntTreeNode(n31, n32, 2);
			var n22 = new BinaryIntTreeNode(null, null, 5);
			var n11 = new BinaryIntTreeNode(n21, n22, 4);

			var result = new CheckIfABinaryTreeIsBSTOrNot().Check(n11);
			Debug.Assert(result);

			//    3
			//  2   5 
			// 1 4 
			// 
			n31 = new BinaryIntTreeNode(null, null, 1);
			n32 = new BinaryIntTreeNode(null, null, 4);
			n21 = new BinaryIntTreeNode(n31, n32, 2);
			n22 = new BinaryIntTreeNode(null, null, 5);
			n11 = new BinaryIntTreeNode(n21, n22, 3);

			result = new CheckIfABinaryTreeIsBSTOrNot().Check(n11);
			Debug.Assert(!result);

		}



		private bool Check(BinaryIntTreeNode root)
		{
			return IsBST(root, int.MinValue, int.MaxValue);

		}

		private bool IsBST(BinaryIntTreeNode node, int minKey, int maxKey)
		{
			if (node == null)
				return true;

			if (node.Key <= minKey || node.Key >= maxKey)
				return false;

			return IsBST(node.Left, minKey, node.Key) && IsBST(node.Right, node.Key, maxKey);
		}
	}
}
