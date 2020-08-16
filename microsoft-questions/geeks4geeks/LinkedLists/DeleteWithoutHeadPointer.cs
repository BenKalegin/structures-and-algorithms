using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.LinkedLists
{
    class DeleteWithoutHeadPointer
    {
        public static void Test()
        {
            // You are given a pointer/ reference to the node which is to be deleted from the linked list of N nodes.
            // The task is to delete the node. Pointer/ reference to head node is not given. 
            // Note: No head reference is given to you.
            AssertResult(new[] {1, 2, 3}, 2, new[] {1, 3});
        }

        private static void AssertResult(int[] input, int k, int[] expected)
        {
            Node root = Node.ConvertArrayToList(input);
            var node = root;
            while (node != null && node.Value != k)
                node = node.Next;

            RemoveNode(node);
            var actual = Node.ConvertListToArray(root);
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"expected: {expected.Aggregate("", (s, i) => s + ", " + i)} actual: {actual.Aggregate("", (s, i) => s + ", " + i)}");

                Console.ResetColor();
            }
        }

        private static void RemoveNode(Node node)
        {
            // 1 -> (2) -> 3
            // 1 -> 3 -> ?
            while (node != null)
            {
                if (node.Next != null) {
                    node.Value = node.Next.Value;  // 1 -> (3) -> 3
                    if (node.Next.Next == null)
                        node.Next = null;          // 1 -> (3)  
                }
                node = node.Next;                  // 1 -> 3 -> (4)
            }

        }
    }
}