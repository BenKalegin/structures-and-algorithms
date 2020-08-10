using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{

	class TreeNode
	{
		public TreeNode[] Children;
		public int Payload;

		public TreeNode(int payload)
		{
			Payload = payload;
		}
	}

	class FindTheClosestCommonAncestorsTo2NodesInA_N_ary_tree
	{
		public static void Test()
		{
			//      1
			//    2   3
			//  4
			TreeNode root = new TreeNode(1)
			{
				Children = new[]
				{
					new TreeNode(2){Children = new []{new TreeNode(4)}},
					new TreeNode(3),
				}
			};

			Debug.Assert(FindAncestor(root, 4, 3) == 1);
		}

		private static int FindAncestor(TreeNode root, int p1, int p2)
		{
			List<TreeNode> path1 = FindPath(root, p1);
            return 0;
        }

		private static List<TreeNode> FindPath(TreeNode node, int p1)
        {
            return null;
        }
	}
}
