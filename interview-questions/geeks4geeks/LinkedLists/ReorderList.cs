using System;
using System.Linq;

namespace interview_questions.geeks4geeks.LinkedLists
{
    class ReorderList
    {
        public static void Test()
        {
            AssertResult(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 5, 2, 4, 3 });
        }

        private static void AssertResult(int[] input, int[] expected)
        {
            Node root = Node.ConvertArrayToList(input);
            var actual = Node.ConvertListToArray(Reorder(root));
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected.Aggregate("", (s, i) => s + ", " + i)} actual: {actual.Aggregate("", (s, i) => s + ", " + i)}");

                Console.ResetColor();
            }
        }

        private static Node Reorder(Node root)
        {
            var (n1, n2) = SplitInHalves(root);
            n2 = Reverse(n2);
            return Merge(n1, n2);
        }

        private static Node Merge(Node n1, Node n2)
        {
            // n1 1 -> 2 -> 3
            // n2 4 -> 5 -> 6

            var p1 = n1;
            var p2 = n2;

            while (p1 != null && p2 != null)
            {
                var nextp1 = p1.Next; // np1 = 2                        // = 3                    // np1: null
                p1.Next = p2; // 1 -> 4                                 // 2 -> 5                 // 3 -> 6
                p2 = p2.Next; // p2 = 5                                 // p2: 6                  // p2: null
                if (p1.Next != null)
                    p1.Next.Next = nextp1; // p1: 2, p2: 5-> 6           // 2 -> 5 -> 3            // 
                p1 = nextp1;           // 2                             // p1: 3                   // p1: null
            }

            return n1;
        }

        private static Node Reverse(Node n)
        {
            Node newRoot = null;
            Node oldRoot = n;

            while (oldRoot != null)
            {
                // 1 -> 2 -> 3
                var nextOldRoot = oldRoot.Next;      // 2                 3 
                oldRoot.Next = newRoot;              // 1 -> null         2->1
                newRoot = oldRoot;                   // 1                 2 
                oldRoot = nextOldRoot;               // 2                 3  
            }

            return newRoot;
        }

        private static (Node mid, Node beforeMid) SplitInHalves(Node root)
        {
            var fast = root;
            var slow = root;
            var but1 = slow;

            // 1 2 3 4 
            while (fast?.Next != null)
            {
                fast = fast.Next.Next;   // f = 3    null    
                but1 = slow;             // b = 1    b = 2 
                slow = slow.Next;        // s = 2    s = 3
            }

            but1.Next = null;            // 2 -> next replace 3 with null 
            return (root, slow);         // (1, 3)
        }
    }
}
