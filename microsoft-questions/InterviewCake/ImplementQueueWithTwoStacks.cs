using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.InterviewCake
{
    class ImplementQueueWithTwoStacks
    {
        class QueueMadeOfStacks<T>
        {
            private readonly Stack<T> stack1 = new Stack<T>();
            private readonly Stack<T> stack2 = new Stack<T>();



            public void Enqueue(T item)
            {
                stack1.Push(item);
            }

            public T Dequeue()
            {
                if (stack2.Any())
                    return stack2.Pop();

                // empty case
                // s1: (3 2 1) -> ()
                // s2: () -> (1 2 3) -> [1] (2 3)

                while (stack1.Any())
                    stack2.Push(stack1.Pop());

                if (!stack2.Any())
                    throw new Exception("empty");
                return stack2.Pop();
            }

        }

        public static void Test()
        {
            var queue = new QueueMadeOfStacks<int>();

            var results = new List<int>();
            queue.Enqueue(1);
            results.Add(queue.Dequeue()); 
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            results.Add(queue.Dequeue());
            queue.Enqueue(5);
            results.Add(queue.Dequeue());
            results.Add(queue.Dequeue());
            queue.Enqueue(6);
            results.Add(queue.Dequeue());
            results.Add(queue.Dequeue());

            if (!results.SequenceEqual(Enumerable.Range(1, 6)))
                throw new Exception($"wrong");
        }
    }
}
