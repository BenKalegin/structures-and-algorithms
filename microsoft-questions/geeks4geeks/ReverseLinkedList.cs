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
			LinkedListNode oldHead = head;
			LinkedListNode newHead = null;

			// 1->2->3->4
			// 1<-2 3->4 
			// 1<-2<-3 4->
			// 


			while (oldHead != null)
			{
				var pendingOldHead = oldHead.Next;
   				oldHead.Next = newHead;
				newHead = oldHead;
				oldHead = pendingOldHead;
			}

			return newHead;
		}
	}
}
