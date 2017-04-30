using System;
using NUnit.Framework;

namespace Interview
{
    public static class Extensions
    {

        public static void AssertArrays(this int[] arr1, int[] arr2)
        {
            Assert.That(arr1.Length, Is.EqualTo(arr2.Length));

            for (var i = 0; i < arr1.Length; i++)
            {
                Assert.That(arr1[i], Is.EqualTo(arr2[i]));
            }
        }

        public static int[] ToArray(this int size)
        {
            var randNum = new Random();
            var result = new int[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = randNum.Next();
            }

            return result;
        }
    }
}
