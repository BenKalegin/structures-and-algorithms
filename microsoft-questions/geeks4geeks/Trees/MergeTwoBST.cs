using System;
using System.Collections.Generic;

namespace microsoft_questions.geeks4geeks.Trees
{
    class MergeTwoBST
    {
        public static void Test()
        {
            AssertResult("5 3 6 2 4", "2 1 3 N N N 7 6", "1 2 2 3 3 4 5 6 6 7");
            //  3 2 6 1 2 4 6 N N N 3 N 5 N 7

            //          3
            //       2     6
            //      1 2   4  6
            //         3   5   7  
        }

        private static void AssertResult(string tree1, string tree2, string expected)
        {
            var root1 = TreeReader.ReadTree(tree1);
            var root2 = TreeReader.ReadTree(tree2);
            var actual = Merge(root1, root2);
            if (actual != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static string Merge(Node root1, Node root2)
        {
            // convert to sorted array, merge sort, convert back to tree
            var array1 = FlattenTree(root1);
            var array2 = FlattenTree(root2);
            var mergedArray = MergeArrays(array1, array2);
            var root = BuildTreeFromArray(mergedArray);
            return TreeReader.WriteTree(root);
        }

        private static Node BuildTreeFromArray(int[] mergedArray)
        {
            return BuildTreeFromArrayRecurse(mergedArray, 0, mergedArray.Length - 1);
        }

        private static Node BuildTreeFromArrayRecurse(int[] array, int start, int end)
        {
            if (start > end)
                return null;
            if (start == end)
                return new Node(array[start]);
            int mid = (start + end) / 2;
            var node = new Node(array[mid])
            {
                Left = BuildTreeFromArrayRecurse(array, start, mid - 1),
                Right = BuildTreeFromArrayRecurse(array, mid + 1, end)
            };
            return node;
        }

        private static int[] MergeArrays(List<int> array1, List<int> array2)
        {
            var result = new int[array1.Count + array2.Count];
            int i1 = 0, i2 = 0;
            int r = 0;

            while (i1 < array1.Count && i2 < array2.Count)
            {
                if (array1[i1] <= array2[i2])
                    result[r++] = array1[i1++];
                else
                    result[r++] = array2[i2++];
            }

            while (i1 < array1.Count)
            {
                result[r++] = array1[i1++];
            }
            while (i2 < array2.Count)
            {
                result[r++] = array2[i2++];
            }

            return result;
        }

        private static List<int> FlattenTree(Node root)
        {
            var result = new List<int>();
            FlattenTreeRecurse(root, result);
            return result;
        }

        private static void FlattenTreeRecurse(Node root, List<int> result)
        {
            if (root == null)
                return;
            FlattenTreeRecurse(root.Left, result);
            result.Add(root.Data);
            FlattenTreeRecurse(root.Right, result);
        }
    }
}
