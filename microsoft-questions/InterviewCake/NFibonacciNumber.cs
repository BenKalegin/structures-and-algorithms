using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.InterviewCake
{
    class NFibonacciNumber
    {
        public static void Test()
        {
            if (FindFibonacciNumber(6) != 8)
                throw new Exception("expected 8");
            if (FindFibonacciNumber(5) != 5)
                throw new Exception("expected 5");
            if (FindFibonacciNumber(1) != 1)
                throw new Exception("expected 1");
        }

        private static int FindFibonacciNumber(int i)
        {
            
            if (i <= 2)
                return 1;

            int olderValue = 1;
            int newerValue = 1;

            for (int j = 0; j < i - 2; j++)
            {
                int tmp = olderValue;
                olderValue = newerValue;
                newerValue = olderValue + tmp;
            }

            return newerValue;

        }
    }
}
