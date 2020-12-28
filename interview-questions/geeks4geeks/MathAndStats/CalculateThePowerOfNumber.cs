using System;

namespace interview_questions.geeks4geeks.MathAndStats
{
    class CalculateThePowerOfNumber
    {
        public static void Test()
        {
            Assert(2, 5, 32);
            Assert(3, 4, 81);
            Assert(1.5, 3, 3.375);
            Assert(2, -2, 0.25);
        }

        private static void Assert(double number, int power, double expected)
        {
            var actual = Power(number, power);
            if (Math.Abs(actual - expected) > 1e-9)
            {
                Console.WriteLine($"Expected {expected} actual {actual}");
            }
        }

        private static double Power(in double number, in int power)
        {
            return OptimizedPower(number, power);
            return NaivePower(number, power);
        }

        private static double OptimizedPower(in double number, int power)
        {
            if (power == 0)
                return 1;

            double multiplier = power > 0 ? number : 1 / number;
            power = Math.Abs(power);

            // 2: x * x  
            // 4: (x*x) * (x*x)
            // 8: x**4 * x**4
            // 16: x**4 * x **4
            // 32: x**8  * x**8
            // 31: 16 + 8 + 4 + 2 + 1

            int exp = 1;
            double result = multiplier;
            while (exp * 2 <= power)
            {
                result *= result;
                exp *= 2;
            }

            for (int i = exp + 1; i <= power; i++)
            {
                result *= multiplier;
            }

            return result;

        }

        private static double NaivePower(in double number, in int power)
        {
            double result = 1;
            if (power == 0)
                return 1;
            
            if (power > 1)
                for (int i = 1; i <= power; i++)
                {
                    result *= number;
                }
            else
            {
                for (int i = -1; i >= power; i--)
                {
                    result /= number;
                }

            }

            return result;
        }
    }
}
