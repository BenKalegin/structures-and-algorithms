using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks.LinkedLists
{
    class Node
    {
        internal int Value;
        internal Node Next;

        public Node(int value)
        {
            this.Value = value;
        }
    }

    class ReverseALinkedListInGroupsOfGivenSize
    {
        // Given a linked list of size N. The task is to reverse every k nodes (where k is an input to the function) in the linked list.
        public static void Test()
        {
            AssertResult(new[]{ 1, 2, 2, 4, 5, 6, 7, 8 },4, new[]{ 4, 2, 2, 1, 8, 7, 6, 5 });
        }

        private static void AssertResult(int[] input, int k, int[] expected)
        {
            Node root = ConvertArrayToList(input);
            var actual = ConvertListToArray(Reverse(root, k));
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s,i) => s + ", " + i)} actual: {actual.Aggregate("", (s, i) => s + ", " + i)}");

                Console.ResetColor();
            }
        }

        private static int[] ConvertListToArray(Node root)
        {
            var result = new List<int>();
            while (root != null)
            {
                result.Add(root.Value);
                root = root.Next;
            }

            return result.ToArray();
        }




        private static (Node groupStart, Node groupEnd, Node nextGroup) ReverseGroup(Node root, int k)
        {
            Stack<int> group = new Stack<int>();

            Node nextGroup = root;

            for (int i = 0; i < k; i++)
            {
                group.Push(nextGroup.Value);
                nextGroup = nextGroup.Next;

                if (nextGroup == null)
                    break;
            }

            if (!group.Any())
                // root is null
                return (null, null, null);

            var groupStart = new Node(group.Pop());
            var nextInGroup = groupStart;
            while (group.Any())
            {
                var n = new Node(group.Pop());
                nextInGroup.Next = n;
                nextInGroup = n;
            }

            return (groupStart, nextInGroup, nextGroup);
        }

        private static Node Reverse(Node root, int k)
        {

            var (groupStart, groupEnd, nextGroup) = ReverseGroup(root, k);
            var result = groupStart;
            var tail = groupEnd;
            while (nextGroup != null)
            {
                (groupStart, groupEnd, nextGroup) = ReverseGroup(nextGroup, k);
                tail.Next = groupStart;
                tail = groupEnd;
            }

            return result;
            // k = 3

            // A -> B -> C -> D -> E -> F
            // stack A, B. Make C root. Pop and assign stack


            // now n points to next group or null


            // here we have C -> B -> A  LAST=D -> E -> F


            // C -> B -> A -> F -> E -> D
        }

        private static Node ConvertArrayToList(int[] input)
        {
            Node root = null;
            Node last = null;
            foreach (var i in input)
            {
                var node = new Node(i);
                if (root == null)
                {
                    root = node;
                    last = node;
                }
                else
                {
                    last.Next = node;
                    last = node;
                }
            }

            return root;
        }
    }
}
