#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace microsoft_questions.InterviewCake
{
    class FindEitherLinkedListHasCycles
    {
        class Node
        {
            internal int Value;
            internal Node? Next;

        }

        public static void AsertSame( int expected, int actual)
        {
            if (expected != actual)
            {
                Console.WriteLine($"------Expected {expected} actual {actual}");
                throw new Exception();
            }
                
        }

        public static void Test()
        {
            VerifyPreloopLength(0, 0);

            // 01
            // ^|
            VerifyPreloopLength(0, 1);

            // 01
            //  ^
            VerifyPreloopLength(1, 1);


            // 0123456     
            //  ^----|
            // 0 1 2 3 4 5 
            // 1 3 5 1 3 5 
            VerifyPreloopLength(1, 6);


            // 012345     
            //   ^--|
            VerifyPreloopLength(2, 5);
            VerifyPreloopLength(0, 5);
            VerifyPreloopLength(10, 50);
            VerifyPreloopLength(-1, -1);
        }

        private static void VerifyPreloopLength(int mergePos, int loopPos)
        {
            #region COMMENTS



            // 1: 0 +1
            // 2: 0 +1  
            //      +1

            // 0 0
            // A
            // B

            // 1 : 0 0
            // 1 : 0 0



            // 0123     
            // --AB

            // 1: 0 1 2 3 2 3 2 3
            // 2: 0 1 3  
            //      2 2  

            // 0123456     
            // -----AB

            // 1: 0 1 2 3 4 5 6 5 6 5 6
            // 2: 0 1 3 5 5 5  
            //      2 4 6 6
            // D = 4
            // T = 14

            // 0123456     
            // A-----B

            // 1: 0 1 2 3 4 5 6 0 1 2 3 4 5 6   
            // 2: 0 1 3 5 0 2 4 6
            //      2 4 6 1 3 5 0
            // D = 6
            // T = 21

            // 0123456
            //       A 
            // ------B

            // 1: 0 1 2 3 4 5 6 6
            // 2: 0 1 3 5 6 6 6  
            //      2 4 6 6 6
            // D = 5
            // T = 17

            // 0123     
            // -A-B

            // 1: 0 1 2 3 1 2 3 1
            // 2: 0 1 3 2  
            //      2 1 3 

            // 0123     
            // A--B

            // 1: 0 1 2 3 0 1 2 3 1
            // 2: 0 1 3 1 3  
            //      2 0 2 0

            // 012345     
            // --A--B

            // 1: 0 1 2 3 4 5 2 3 4 5
            // 2: 0 1 3 5 3
            //      2 4 2 4 

            // 012345     
            // -A---B

            // 1: 0 1 2 3 4 5 1 2 3 4 5
            // 2: 0 1 3 5 2 4
            //      2 4 1 3 5 

            // 0123456     
            // -A----B

            // 1: 0 1 2 3 4 5 6 1 2 3 4 5
            // 2: 0 1 3 5 1 3 5
            //      2 4 6 2 4 6

            // 01234567     
            // -A-----B

            // 1: 0 1 2 3 4 5 6 7 1 2 3 4 5
            // 2: 0 1 3 5 7 2 4 6 
            //      2 4 6 1 3 5 7

            // 012345678     
            // --A-----B

            // 1: 0 1 2 3 4 5 6 7 8 2 3 4 5
            // 2: 0 1 3 5 7 2 4 6 
            //      2 4 6 8 3 5 7

            // 012345     
            // A----B
            // ^    /

            // 1: 0 1 2 3 4 5 0 1 2 3 4 5
            // 2: 0 1 3 4 0 2 4 0
            //      2 4 5 1 3 5 1

            // 
            #endregion COMMENTS

            var head = TestLoop(mergePos, loopPos);
            var slow = head.Next;
            var fast = head.Next?.Next;
            int attempts = 1000;
            while(attempts-- > 0 && slow != fast)
            {
                if (fast?.Next == null)
                {
                    AsertSame(mergePos, -1);
                    return;
                }

                slow = slow!.Next!;
                fast = fast!.Next!.Next;
            }
            if (attempts <= 0)
                throw new Exception("infinite loop detected 1.");

            int headLength = 0;
            var straight = head;

            attempts = 1000;
            while (attempts-- > 0 && straight != fast)
            {
                straight = straight!.Next;
                fast = fast!.Next;
                headLength++;
            }
            if (attempts <= 0)
                throw new Exception("infinite loop detected 2.");

            Console.WriteLine($"{headLength}");
            AsertSame(mergePos, headLength);
        }

        private static Node TestLoop(int mergePos, int loopPos)
        {
            var nodes = GenerateChain();
            if (loopPos >= 0 && mergePos >= 0)
                nodes[loopPos].Next = nodes[mergePos];
            return nodes.First();
        }


        private static Node[] GenerateChain()
        {
            var count = 100;
            var nodes = Enumerable.Range(0, count).Select(i => new Node {Value = i}).ToArray();
            foreach (var pair in nodes.Zip(nodes.Skip(1), (prev,next) => new {prev, next})) 
                pair.prev.Next = pair.next;
            return nodes;
        }
    }
}
