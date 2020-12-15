using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interview_questions.geeks4geeks.Trees
{

    class ConvertBinaryTreeToDoublyLinkedList
    {
        public class DoubleLinkedNode
        {
            public DoubleLinkedNode Next;
            public DoubleLinkedNode Prev;
            public int Value;
        }     
        
        public class DoubleLinkedList
        {
            public DoubleLinkedNode Head;
            public DoubleLinkedNode Tail;
        }

        public static void Test()
        {
            //                3
            //            2       5
            //         1         4  6
            //                         7

            AssertResult("3 2 5 1 N 4 6 N N N N N 7", new[]{1, 2, 3, 4, 5, 6, 7});
        }

        private static void AssertResult(string tree, int[] expected)
        {
            var root = TreeReader.ReadTree(tree);
            var actual = TreeToList(root);

            bool match = true;
            foreach (var i in expected)
            {
                if (actual.Value != i)
                {
                    match = false;
                    break;
                }

                actual = actual.Next;
            }

            if (!match)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static DoubleLinkedNode TreeToList(Node root)
        {
            //        5
            //    3       7
            //  2   4  6     8 
            //1                 9

            return Traverse(root).Head;
        }

        private static DoubleLinkedList Traverse(Node tree)
        {
            DoubleLinkedList prefix = null;
            DoubleLinkedList suffix = null;
            if (tree.Left != null) 
                prefix = Traverse(tree.Left);

            if (tree.Right != null)
                suffix = Traverse(tree.Right);

            return Join(prefix, suffix, tree.Data);
        }

        private static DoubleLinkedList Join(DoubleLinkedList prefix, DoubleLinkedList suffix, in int treeData)
        {
            var head = prefix;
            var tail = suffix;

            var middle = new DoubleLinkedNode
            {
                Value = treeData
            };

            if (prefix != null)
            {
                prefix.Tail.Next = middle;
                middle.Prev = prefix.Tail.Next;
            }
            else
            {
                head = new DoubleLinkedList {Head = middle, Tail = middle};
            }

            if (suffix != null)
            {
                middle.Next = suffix.Head;
                suffix.Head.Prev = middle;
            }
            else
            {
                tail = new DoubleLinkedList { Head = middle, Tail = middle };
            }

            return new DoubleLinkedList {Head = head.Head, Tail = tail.Tail};
        }
    }
}
