using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Strings
{
    public class NumOfValidCombinations
    {

        [Test]
        public void One111()
        {
            Assert.That(Calc(new []{1,1,1}), Is.EqualTo(3));
        }

        [Test]
        public void One110()
        {
            Assert.That(Calc(new[] { 1, 1, 0 }), Is.EqualTo(1));
        }

        private int Calc(int[] arr)
        {
            if (arr.Length == 0)
            {
                return 0;
            }

            return getCnt(arr, arr.Length - 1);
        }

        int getCnt(int[] arr, int ind)
        {
            if (ind < 0) return 0;

            if (ind == arr.Length - 1)
            {
                if (arr[ind] > 0)
                {
                    return 1 + getCnt(arr, ind - 1);
                }
                else
                {
                    return getCnt(arr, ind - 1);
                }
            }
            if (arr[ind] > 0 && arr[ind] * 10 + arr[ind + 1] <= 26)
            {
                return 1 + getCnt(arr, ind - 1);
            }
            return getCnt(arr, ind - 1);
        }
    }
}
