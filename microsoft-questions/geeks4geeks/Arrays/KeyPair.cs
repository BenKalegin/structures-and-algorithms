using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Arrays
{
    /// <summary>
    /// Given an array A of N positive integers and another number X. Determine whether or not there exist two elements in A whose sum is exactly X.
    /// </summary>
    class KeyPair
    {
        public static void Test()
        {
            AssertResult(new[] { 1, 4, 45, 6, 10, 8 }, 16, true);
            AssertResult(new[] { 1, 2, 4, 3, 6 }, 10, true);
            AssertResult(new[]
                {
                    335, 501, 170, 725, 479, 359, 963, 465, 706, 146, 282, 828, 962, 492, 996, 943, 828, 437, 392, 605,
                    903, 154, 293, 383, 422, 717, 719, 896, 448, 727, 772, 539, 870, 913, 668, 300, 36, 895, 704, 812,
                    323, 334
                }
                , 468, false);

        }


        private static int Parse(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch 
            {
                Console.WriteLine($"Cannot convert '{s}' to int");
                throw;
            }

        }

        public static void Main1()
        {
            var ntestsString = Console.ReadLine();
            var nTests = ntestsString != "" ? Parse(ntestsString) : 1;
            for (var i = 0; i < nTests; i++)
            {
                var s = Console.ReadLine()!.Split(' ');
                var arrLength = int.Parse(s[0]);
                var sum = int.Parse(s[1]);
                s = Console.ReadLine()!.Split(' ');
                var array = s.Select(int.Parse).ToArray();
                var result = DoesSumExistUsingHashSet(array, sum);
                Console.WriteLine(result ? "Yes" : "No");
            }
        }

        private static void AssertResult(int[] array, int sum, bool expected)
        {
            var actual1 = DoesSumExistUsingHashSet(array, sum);
            var actual2 = DoesSumExistUsingPointers(array, sum);
            if (actual1 != expected || actual2 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual1: {actual1} actual2: {actual2}");

                Console.ResetColor();
            }
        }

        private static bool DoesSumExistUsingHashSet(int[] array, int sum)
        {
            var complement =  new HashSet<int>();
            foreach (var i in array) 
                complement.Add(sum - i);
            foreach (var i in array)
                if (complement.Contains(i))
                    return true;
            return false;
        }
        private static bool DoesSumExistUsingPointers(int[] array, int sum)
        {
            // 1 sort
            Array.Sort(array);
            var l = 0;
            var r = array.Length - 1;
            while (l < r)
            {
                var trySum = array[l] + array[r];
                if (trySum == sum)
                    return true;
                else if (trySum < sum)
                    l++;
                else
                    r--;
            }

            return false;
        }
    }
}
