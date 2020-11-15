using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.StacksQueues
{
    class StackUsing2Queues<T>
    {
        private Queue<T> queue1 = new Queue<T>();
        private Queue<T> queue2 = new Queue<T>();


        public void Push(T elem)
        {
            //  input 1 2 3 4 
            //  output 1 2 3 4

            // push 1
            // put 1 in q1
            // q1: 1 
            // q2: 

            // push 2
            // put 2 in q2
            // q1: 1 
            // q2: 2

            // put everything from q1 to q2
            // q1:
            // q2: 1 2 

            // swap q1 and q2
            // q1: 1 2 
            // q2: 

            // pop  2
            // dequeue from q1
            // q1: 1 -> (2) 
            // q2: 

            queue2.Enqueue(elem);    
            while (queue1.Any())
                queue2.Enqueue(queue1.Dequeue());

            var swap = queue1;
            queue1 = queue2;
            queue2 = swap;
        }

        public T Pop()
        {
            return queue1.Dequeue();
        }
    }


    internal class StackUsing2QueuesTest
    {
        public static void Test()
        {
            var stack = new StackUsing2Queues<int>();

            stack.Push(1);
            Assert(1, stack.Pop());

            stack.Push(1);
            stack.Push(2);
            Assert(2, stack.Pop());
            Assert(1, stack.Pop());

            stack.Push(1);
            stack.Push(2);
            Assert(2, stack.Pop());
            stack.Push(3);
            stack.Push(4);
            Assert(4, stack.Pop());
            Assert(3, stack.Pop());
            Assert(1, stack.Pop());

        }

        private static void Assert(int expected, int actual)
        {
            if (expected != actual)
                Console.WriteLine($"Error! expected {expected} actual {actual}");
        }
    }
}
