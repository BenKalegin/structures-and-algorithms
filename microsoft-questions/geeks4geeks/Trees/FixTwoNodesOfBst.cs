using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Trees
{
    class FixTwoNodesOfBst
    {
        // Two of the nodes of a Binary Search Tree (BST) are swapped. Fix (or correct) the BST by swapping them back. Do not change the structure of the tree.
        // Note: It is guaranteed than the given input will form BST, except for 2 nodes that will be wrong.

        public static void Test()
        {
            //          10
            //       5     8*
            //     2   20*
            AssertResult("10 5 8 2 20", "10 5 20 2 8");

            //          10
            //        5    4* -> (20 5) 6 (10 4)
            //     20*  6
            // 
            AssertResult("10 5 4 20 6", "10 5 20 4 6");

        }

        private static void AssertResult(string tree, string expected)
        {
            var root = TreeReader.ReadTree(tree);
            Fix(root);
            var actual = TreeReader.WriteTree(root);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static void Fix(Tree root)
        {
            FindViolator(root);
        }

        private static void FindViolator(Tree root)
        {
            // in-order traversal should be sorted array
            (Tree node, Tree parent) priorValue = (null, null);

            var violators = new List<(Tree node, Tree parent)>();

            //          10
            //       5     8* -> 2 5 (20 [10) 8]
            //     2   20*
            // 

            //          10
            //        5    8* -> (20 5) 6 (10 8)
            //     20*  6
            // 

            void Visitor(Tree n, Tree parent)
            {
                if (priorValue.node != null)
                {
                    if (n.x < priorValue.node.x)
                        // first violator should be former in pair, second violator latter in pair
                        violators.Add(violators.Any() ? (n, parent) : priorValue);
                }
                priorValue = (n, parent);
            }

            InorderTraversal(root, null, Visitor);

            if (violators.Count != 2)
                throw new Exception("should be exactly 2 violators");

            var (n1, p1) = violators[0];
            var (n2, p2) = violators[1];


            if (p1.l == n1)
                p1.l = n2;
            else
                p1.r = n2;

            if (p2.l == n2)
                p2.l = n1;
            else
                p2.r = n1;
        }

        private static void InorderTraversal(Tree tree, Tree parent, Action<Tree, Tree> visitor)
        {
            if (tree.l != null)
                InorderTraversal(tree.l, tree, visitor);
            visitor(tree, parent);
            if (tree.r != null)
                InorderTraversal(tree.r, tree, visitor);
        }
    }
}
