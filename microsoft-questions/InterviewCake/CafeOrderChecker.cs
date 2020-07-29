using System;

namespace microsoft_questions.InterviewCake
{
    class CafeOrderChecker
    {
        public static void Test()
        {
            var takeOutOrders = new[] {1, 3, 5};
            var dineInOrders = new[] {2, 4, 6};
            var servedOrders = new[] {1, 2, 4, 6, 5, 3};

            Console.WriteLine($"First come first served False -> {FirstComeFirstServed(takeOutOrders, dineInOrders,  servedOrders)}");

            takeOutOrders = new[] {17, 8, 24};
            dineInOrders = new[] {12, 19, 2};
            servedOrders = new[] {17, 8, 12, 19, 24, 2};

            Console.WriteLine($"First come first served True -> {FirstComeFirstServed(takeOutOrders, dineInOrders, servedOrders)}");
        }

        private static bool FirstComeFirstServed(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            if (takeOutOrders.Length + dineInOrders.Length != servedOrders.Length)
                throw new ArgumentException("Mismatching orders");

            if (servedOrders.Length == 0)
                return true;

            var simpleViolations = CheckOrdersOfOneKind(takeOutOrders, servedOrders) && CheckOrdersOfOneKind(dineInOrders, servedOrders);

            return simpleViolations;
        }

        /// <summary>
        /// check
        /// </summary>
        /// <returns></returns>
        private static bool CheckOrdersOfOneKind(int[] orderedOrders, int[] servedOrders)
        {
            // check takeout orders
            int outPos = 0;

            foreach (var lookingFor in orderedOrders)
            {
                bool found = false;
                for (var j = outPos; j < servedOrders.Length; j++)
                    if (servedOrders[j] == lookingFor)
                    {
                        outPos = j + 1;
                        found = true;
                        break;
                    }

                if (!found)
                    return false;
            }

            return true;
        }
    }
}
