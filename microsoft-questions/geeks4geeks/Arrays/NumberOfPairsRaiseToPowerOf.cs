using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks
{
    internal class NumberOfPairsRaiseToPowerOf
    {
        // Given two arrays X and Y of positive integers, find number of pairs such that x**y > y**x (raised to power of) where x is an element from X and y is an element from Y.
        public static void Test()
        {
            // x
            // y    0    1    2  3   4   5 
            // ________________________
            // 0 |     0/1   0/1  0/1   0/1   0/1 
            // 1 |  1  1/1   1/2  1   1   1  
            // 2 |  1    2  4  8   16  32 
            // 3 |  1    3  9  27  81  243
            // 4 |  1    4  16 64  256 1024  
            // 5 |  1    5  25 125 625 3125  


            // 1   2   3   4   5   6   7   8
            // 1   0  -1  -1  -1  -1  -1  -1
            // 2   1   0  -1   0   1   1   1
            // 3   1   1   0   1   1   1   1
            // 4   1   0  -1   0   1   1   1
            // 5   1  -1  -1  -1   0   1   1
            // 6   1  -1  -1  -1  -1   0   1
            // 7   1  -1  -1  -1  -1  -1   0
            // 8   1  -1  -1  -1  -1  -1  -1
            // 9   1  -1  -1  -1  -1  -1  -1
            // 10  1  -1  -1  -1  -1  -1  -1
            // 11  1  -1  -1  -1  -1  -1  -1
            // 12  1  -1  -1  -1  -1  -1  -1
            // 13  1  -1  -1  -1  -1  -1  -1

        }
    }


}
