using System;
using System.Diagnostics;

namespace interview_questions.geeks4geeks.Arrays
{
	class SearchInSortedAndRotatedArray
	{
		public static void Test()
		{
			var array = new[] {7, 8, 1, 2, 3, 5, 6};

			Debug.Assert(3 == Find(array, array[3]));
			Debug.Assert(6 == Find(array, array[6]));
		}

		private static int Find(int[] array, int value)
		{
			int pivotIndex = FindPivot(array, 0, array.Length-1);
			return PivotedBinarySearch(array, pivotIndex, value);
		}

		private static int PivotedBinarySearch(int[] array, int pivotIndex, int value)
		{
			int low = 0;
			int high = array.Length - 1;

			int mid = (low + high) / 2;
			while (low < high)
			{
				var sign = Math.Sign(array[(mid - pivotIndex - 1 + array.Length) % array.Length] - value);
				switch (sign)
				{
					case 0:
						return mid;

					case -1:
						low = mid + 1;
						mid = (high + mid + 1) / 2;
						break;

					default:
						high = mid;
						mid = (low + mid) / 2;
						break;
				}
			}

			return mid;
		}

		private static int FindPivot(int[] array, int low, int high)
		{
			int mid = (low + high) / 2;
			if (mid == low)
				return mid;

			if (array[mid] < array[low])
				return FindPivot(array, low, mid);
		
			return FindPivot(array, mid, high);
		}
	}
}
