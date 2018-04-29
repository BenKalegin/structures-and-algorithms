using System;
using System.Linq;

namespace microsoft_questions.geeks4geeks
{
	class DeleteAGivenNodeFromASortedSinglyLinkedList
	{
		public static void Test()
		{
			var nodes = Enumerable.Range(1, 10).Select(i => new LinkedListNode(i)).ToArray();

			nodes.Aggregate((LinkedListNode)null, (a, c) => {
				if (a != null)
					a.Next = c;
				return c;
			});

			Console.WriteLine(nodes.First().Enumerate().Aggregate("", (s, n) => s + (s == "" ? "" : "-> ") + n.Payload));

			RemoveNode(nodes.First(), nodes[3]);

			Console.WriteLine(nodes.First().Enumerate().Aggregate("", (s, n) => s + (s == "" ? "" : "-> ") + n.Payload));

		}

		private static void RemoveNode(LinkedListNode head, LinkedListNode toRemove)
		{
			while (head != null && head.Next != toRemove)
				head = head.Next;
			if (head != null)
				head.Next = toRemove.Next;

		}
	}
}
