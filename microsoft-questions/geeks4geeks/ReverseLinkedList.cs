using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
	[DebuggerDisplay("{" + nameof(Payload) + "}")]
	class LinkedListNode
	{
		public LinkedListNode Next;
		public int Payload;

		public LinkedListNode(int payload)
		{
			Payload = payload;
		}

		public IEnumerable<LinkedListNode> Enumerate()
		{
			LinkedListNode head = this;
			while (head != null)
			{
				yield return head;
				head = head.Next;
			}
		}

	}

	class ReverseLinkedList
	{
		public static void Test()
		{
			var nodes = Enumerable.Range(1, 10).Select(i => new LinkedListNode(i)).ToArray();

			nodes.Aggregate((LinkedListNode)null, (a, c) => {
				if (a != null)
					a.Next = c;
				return c;
			});

			Console.WriteLine(Enumerate(nodes.First()).Aggregate("", (s, n) => s + (s == "" ? "" : "-> ") + n.Payload));
			var result = Reverse(nodes.First());
			Console.WriteLine(Enumerate(result).Aggregate("", (s, n) => s + (s == "" ? "" : "-> ") + n.Payload));
		}

		private static IEnumerable<LinkedListNode> Enumerate(LinkedListNode head)
		{
			while (head != null)
			{
				yield return head;
				head = head.Next;
			}
		}

		private static LinkedListNode Reverse(LinkedListNode head)
		{
			// 1->2->3->4->5
			// 1<-2 3->4->5
			// 1<-2<-3 4->5

            var current = head;
            LinkedListNode reversedHead = null;

            while (current != null)
            {
                var wasHead = reversedHead;
				reversedHead = current;
                current = current.Next;
                reversedHead.Next = wasHead;
            }

            return reversedHead;
        }



		private static LinkedListNode Reverse2(LinkedListNode head)
		{
			// 1->2->3->4
			// 1<-2 3->4 
			// 1<-2<-3 4->

            LinkedListNode current = head;
            LinkedListNode reversedHead = null;

            while (current != null)
            {
                var next = current.Next;
                current.Next = reversedHead;
				reversedHead = current;
                current = next;

            }

			return reversedHead;
        }
	}
}
