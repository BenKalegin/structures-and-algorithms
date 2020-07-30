using System.Linq;

namespace microsoft_questions.geeks4geeks
{
    class MergeWithoutExtraSpace
    {
        public static void Test()
        {
            var ar1 = new[]{ 1, 5, 9, 10, 15, 20 };
            var ar2 = new[]{ 2, 3, 8, 13 };

            // 1, 5, 9, 10, 15, 20     13 <-> 20   1, 5, 9, 10, 15, 13   dip 13     1, 5, 9, 10, 13, 15
            // 2, 3, 8, 13                         2, 3, 8, 20                      2, 3, 8, 20   


            MergeSort(ar1, ar2);
            Verify(ar1, ar2);
        }

        private static void MergeSort(int[] a1, int[] a2)
        {
            for (int i1 = 0; i1 < a1.Length; i1++)
            {
                if (a2[0] < a1[i1])
                {
                    Swap(ref a2[0], ref a1[i1]);
                    BubbleUpFirst(a2);
                }
            }


        }

        private static void BubbleUpFirst(int[] a)
        {
            // bubble up to place first element 
            // 5 1 2 3 4  -> 1 2 3 4 5
            for (int i = 0; i < a.Length-1; i++)
            {
                if (a[i] > a[i + 1])
                    Swap(ref a[i], ref a[i+1]);
                else
                    break;
            }
        }

        private static void Swap(ref int i1, ref int i2)
        {
            var tmp = i1;
            i1 = i2;
            i2 = tmp;
        }

        private static bool Verify(int[] values1, int[] values2)
        {
            if (!values1.OrderBy(i => i).ToList().SequenceEqual(values1))
                return false;
            if (!values2.OrderBy(i => i).ToList().SequenceEqual(values2))
                return false;
            if (values1.Max() > values2.Min())
                return false;
            return true;
        }
    }
}
