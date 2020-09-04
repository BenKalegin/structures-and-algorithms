using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microsoft_questions.geeks4geeks.Bits
{
    class IsBitNumberMultipleOf3
    {
        public static void Test()
        {
            Assert("111111", true);  // 63
            AssertException(null);
            AssertException("");
            AssertException("A");
            AssertException("2");
            Assert("011", true);  // 3
            Assert("0", true);
            Assert("1", false);
            Assert("1111", true);  // 15
            Assert("11111", false); // 31
            Assert("1000000", false); // 64
            Assert("1000010", true); // 66
        }

        private static void AssertException(string value)
        {
            try
            {
                IsMultipleOf3(value);
            }
            catch
            {
                return;
            }
            throw new Exception("Exception expected.");
        }

        private static void Assert(string bits, bool expected)
        {
            var actual = IsMultipleOf3(bits);
            if (actual != expected)
            {
                Console.WriteLine($"{bits}: expected {expected} actual {actual}");
            }
        }

        private static bool IsMultipleOf3(string bits)
        {
            if (string.IsNullOrEmpty(bits))
                throw new Exception("empty");

            // multiple of 3 means that sum of decimal digits is multiple of 3
            // do we have similar binary rules?
            // 0001 F
            // 0010 F
            // 0011 T
            // 0100 F
            // 0101 F
            // 0110 T
            // 0111 F

            // 1001 T
            // 1010 F
            // 1011 F
            // 1100 T
            // 1101 F
            // 1110 F
            // 1111 T

            // 10 * A + B ~ A + B
            // 3 bit
            // 8 * 8 * A + 8 * B + C ~ A - B + C

            int sum = 0;
            bool negate = false;

            for (int i = bits.Length - 1; i >= 0; i -= 3)
            {
                Func<int, int> toInt = 
                    j => j < 0 ? 0 :
                        bits[j] == '0' ? 0 : bits[j] == '1' ? 1 : throw new Exception("invalid input");
                int octet = toInt(i) + toInt(i - 1) * 2 + toInt(i - 2) * 4;
                sum += negate ? -octet : octet;
                negate = !negate;
            }

            return sum % 3 == 0;
        }


    }
}
