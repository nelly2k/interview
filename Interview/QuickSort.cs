using NUnit.Framework;

namespace Interview
{
    public class QuickSort
    {
        [Test]
        public void CheckSort()
        {
            var arr = new[] { 65, 23, 7, 12, 8, 44, 67, 9 };
            var sorted = new[] { 7, 8, 9, 12, 23, 44, 65, 67 };
            
            Sort(arr);
            arr.AssertArrays(sorted);
        }

        public void Sort(int[] arr, int? left = null, int? right = null)
        {
            left = left ?? 0;
            right = right ?? arr.Length - 1;

            var i = left.Value;
            var j = right.Value;
            var center = arr[(left.Value + right.Value) / 2];

            while (i <= j)
            {
                while (arr[i] < center)
                {
                    i++;
                }

                while (arr[j] > center)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;

                    i++;
                    j--;
                }

            }

            if (left < j)
            {
                Sort(arr, left, j);
            }

            if (i < right)
            {
                Sort(arr, i, right);
            }

        }
    }
}
