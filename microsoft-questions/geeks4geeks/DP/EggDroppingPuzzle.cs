using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.DP
{
    class EggDroppingPuzzle
    {
        public static void Test()
        {
            AssertResult(2, 10, 4);
            AssertResult(2, 12, 5);
            AssertResult(2, 100, 14);
            AssertResult(3, 5,  3);

        }
        private static void AssertResult(int eggs, int floors, int expected)
        {
            var actual1 = FindMinimumMemoized(eggs, floors);
            var actual2 = FindMinimumTabularWay(eggs, floors);
            if (actual1 != expected || actual2 != expected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual mem: {actual1} actual tab {actual2}");

                Console.ResetColor();
            }
        }

        private static int FindMinimum(int eggs, int floors)
        {
            return 0;
            // guess
            // dp[e, f] = f == T ? dp[e-1, f] : dp[e, f-1]


        }


        private static int FindMinimumMemoized(int totalEggs, int totalFloors)
        {
            var cache = new Dictionary<(int eggs, int floors), int>();
            return FindMinimumRecursive(totalEggs, totalFloors, cache);
        }


        // return minimal number of trials in worst solution
        private static int FindMinimumRecursive(int totalEggs, int totalFloors, Dictionary<(int eggs, int floors), int> cache)
        {
            // if egg breaks at level X, we need to solve subproblem with 0..floor-1 before
            // if egg does not ot break, we need to solve subproblem with floor+1..floors 

            // drop(e, F) = Min(f) (max(eggDrop(e-1, f-1) + eggDrop(e, F-f))) where f in 1..F

            // composition:
            // worst case means max number of trials
            if (cache.TryGetValue((totalEggs, totalFloors), out var result))
                return result;

            if (totalFloors < 2)
                return totalFloors;

            if (totalEggs == 1)
                return totalFloors; 
            int minTrials = int.MaxValue;
            for (int floor = 1; floor <= totalFloors; floor++)
            {
                var worstCaseTrials = Math.Max(FindMinimumRecursive(totalEggs - 1, floor - 1, cache), FindMinimumRecursive(totalEggs, totalFloors - floor, cache));
                if (worstCaseTrials < minTrials)
                {
                    minTrials = worstCaseTrials;
                }
            }

            result = 1 + minTrials;
            cache[(totalEggs, totalFloors)] = result;

            return result;
        }


        private static int FindMinimumTabularWay(int totalEggs, int totalFloors)
        {
            int[,] dp = new int[totalEggs+1, totalFloors+1];

            for (int f = 0; f < totalFloors; f++)
            {
                dp[0, f] = int.MaxValue;
                dp[1, f] = f;
            }

            for (int e = 0; e < totalEggs; e++)
            {
                dp[e, 0] = 0;
                dp[e, 1] = 1;
            }

            for (int e = 2; e <= totalEggs; e++)
            {
                for (int f = 2; f <= totalFloors; f++)
                {
                    dp[e, f] = int.MaxValue;

                    for (int fo = 2; fo <= f; fo++)
                    {
                        var value = 1 + Math.Max(dp[e - 1, fo - 1], dp[e, f - fo]);
                        if (value < dp[e, f])
                            dp[e, f] = value;
                    }
                }
            }

            return dp[totalEggs, totalFloors];
        }

    }
}
