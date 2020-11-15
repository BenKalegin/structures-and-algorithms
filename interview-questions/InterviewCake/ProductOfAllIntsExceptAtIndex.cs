using System;
using System.Linq;

namespace interview_questions.InterviewCake
{
    class ProductOfAllIntsExceptAtIndex
    {
        public static void Test()
        {
            var values = new[] {1, 7, 3, 4};

            var expected = new[] {84, 12, 28, 21};
            var actual = CalculateProducts(values);
            if (!actual.SequenceEqual(expected))
                throw new Exception("wrong");

        }

        private static int[] CalculateProducts(int[] values)
        {
            int[] prefixesOfLength = new int[values.Length];
            int[] suffixesOfLength = new int[values.Length];

            int leftProduct = 1;
            int rightProduct = 1;
            for (int i = 0; i < values.Length; i++)
            {
                prefixesOfLength[i] = leftProduct;
                leftProduct *= values[i];
                suffixesOfLength[i] = rightProduct;
                rightProduct *= values[values.Length-i-1];
            }

            var result = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                result[i] = prefixesOfLength[i] * suffixesOfLength[values.Length - 1 - i];
            }

            return result;
        }
    }
}
