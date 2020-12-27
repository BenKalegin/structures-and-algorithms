using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace interview_questions.geeks4geeks.DP
{
    class FindMaximumSingleSellProfit
    {
        /// <summary>
        /// Given a list of daily stock prices (integers for simplicity), return the buy and sell prices for making the maximum profit.
        /// We need to maximize the single buy/sell profit. If we can’t make any profit, we’ll try to minimize the loss. For the below examples, buy (orange) and sell (green) prices for making a maximum profit are highlighted.
        /// 8 5 12 9 19 1 -> buy 5 sell 19 profit 14
        /// 21 12 11 9 6 3 -> buy 12 sell 11 profit -1
        
        /// </summary>
        public static void Test()
        {
            Assert(new[] { 21, 12, 11, 9, 6, 3 }, -1);
            Assert(new[]{8,5,12,9,19,1}, 14);
        }


        // 8,5,12,9,19,1    A B  ->  C
        
        

        private static void Assert(int[] dailyPrices, int expectedProfit)
        {
            var actualProfit = Profit(dailyPrices);
            if (actualProfit != expectedProfit)
            {
                Console.WriteLine($"Expected {expectedProfit} actual {actualProfit}");
            }
        }

        private static int Profit(int[] dailyPrices)
        {
            return OptimizedProfit(dailyPrices);
            return BrutForceProfit(dailyPrices);
        }

        private static int OptimizedProfit(int[] dailyPrices)
        {
            int minPrice = dailyPrices[0];
            int maxPrice = dailyPrices[1];
            int bestProfit = maxPrice - minPrice;
            for (var i = 1; i < dailyPrices.Length; i++)
            {
                if (dailyPrices[i] < minPrice && i < dailyPrices.Length-1)
                {
                    minPrice = dailyPrices[i];
                    maxPrice = dailyPrices[i+1];
                }
                else if (dailyPrices[i] > maxPrice)
                {
                    maxPrice = dailyPrices[i];
                }
                var currentProfit = maxPrice - minPrice;
                if (currentProfit > bestProfit)
                    bestProfit = currentProfit;
            }

            return bestProfit;
        }

        private static int BrutForceProfit(int[] dailyPrices)
        {
            int bestProfit = int.MinValue;
            
            for(int buyIndex = 0; buyIndex < dailyPrices.Length-1; buyIndex++) // O(N)
            for (int sellIndex = buyIndex + 1; sellIndex < dailyPrices.Length; sellIndex++) // O(N)
            {
                var profit = dailyPrices[sellIndex] - dailyPrices[buyIndex];
                if (profit > bestProfit)
                {
                    bestProfit = profit;
                }
            }
            // O(N**2)
            return bestProfit;
        }
    }
}
