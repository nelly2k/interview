using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Given an array of integers, return indices of the two numbers such that they add up to a specific target.
    /// You may assume that each input would have exactly one solution, and you may not use the same element twice.
    /// </summary>
    public class TwoSum
    {
        private int iterations;

        [SetUp]
        public void Setup()
        {
            iterations = 0;
        }

        [TearDown]
        public void Teradown()
        {
            Console.Write($"Iterations {iterations}");
        }

        [Test]
        public void Simple()
        {
            var arr = new[] {2, 7, 11, 15};
            var target = 9;

            new[] {0,1}.AssertArrays(Calc(arr, target));
            
        }

        [Test]
        public void NoSolution()
        {
            var arr = new[] { 2, 7, 11, 15 };
            var target = 14;
            Calc(arr, target);
        }

        [Test]
        public void Negative()
        {
            var arr = new[] { -1, -2, -3, -4, -5 };
            var target = -8;
            new[] { 2, 4 }.AssertArrays(Calc(arr, target));
        }

        private int[] Calc(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                
                for (var j = i+1; j < nums.Length; j++)
                {
                
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return new int[0];
        }
    }
}
