using System;
using System.Collections.Generic;
using System.Linq;

namespace interview_questions.geeks4geeks.Arrays
{
    class StockBuyAndSell
    {
        // The cost of stock on each day is given in an array A[] of size N.
        // Find all the days on which you buy and sell the stock so that in between those days your profit is maximum.
        public static void Test()
        {
            AssertResult(new[] { 100, 50, 30, 20 }, new (int buy, int sell)[0]);
            AssertResult(new[] { 23, 13, 25, 29, 33, 19, 34, 45, 65, 67 }, new [] { (buy: 1, sell: 4), (buy: 5, sell: 9) });
            AssertResult(new[] { 100, 180, 260, 310, 40, 535, 695 }, new[] { (buy: 0, sell: 3), (buy: 4, sell: 6) });
        }

        private static void AssertResult(int[] prices, (int buy, int sell)[] expected)
        {
            var actual = FindBestDays(prices);
            if (!actual.SequenceEqual(expected))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"expected: {expected} actual: {actual}");

                Console.ResetColor();
            }
        }

        private static (int buy, int sell)[] FindBestDays(int[] prices)
        {
            var result = new List<(int buy, int sell)>();

            int profit = 0;

            int buy = 0;
            int sell = 0;


            while (sell < prices.Length-1)
            {
                while (sell < prices.Length - 1 && prices[sell + 1] - prices[buy] > profit )
                {
                    profit = prices[sell + 1] - prices[buy];
                    sell++;
                }

                while (prices[sell] - prices[buy+1] > profit && sell > buy)
                {
                    profit = prices[sell] - prices[buy+1];
                    buy++;
                }

                if (profit > 0)
                    result.Add((buy, sell));
                Console.WriteLine("Profit: " + profit);
                buy = sell + 1;
                sell = buy;
                profit = 0;
            }

            return result.ToArray();
        }
    }
}