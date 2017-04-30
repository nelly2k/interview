using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Find duplicates in array
    /// Hash - using hash set, complexity O(n)
    /// Quick sort, sorting and comparing, complexity from O(n log n) to O(n^2) - rare
    /// </summary>
    public class FindDuplicationInArray
    {
        private IDuplicateFinder _duplicateFinder;

        [SetUp]
        public void Setup()
        {
            _duplicateFinder = new SortAndFind();
        }

        [Test]
        public void ShortArray_WithDuplicate()
        {
            var arr = new[] { 1, 2, 3, 4, 6, 7, 8, 6, 9, 10 };
            Assert.That(_duplicateFinder.IsDuplicate(arr), Is.True);
        }

        [Test]
        public void ShortArray_NoDuplicates()
        {
            var arr = new[] { 1, 2, 5, 7, 8, 32 };
            Assert.That(_duplicateFinder.IsDuplicate(arr), Is.False);
        }

        [Test]
        public void Performance()
        {
            var arr = 100000.ToArray();
            RunPerformance(new QuickSortDuplicateFinder(), arr, "Quik {0}");
            RunPerformance(new SortAndFind(), arr, "Sort {0}");
            RunPerformance(new HashDuplicateFinder(), arr, "Hash {0}");
        }

        private static void RunPerformance(IDuplicateFinder finder, int[] arr, string message)
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = finder.IsDuplicate(arr);
            sw.Stop();
            Console.WriteLine(message + " result: {1}", sw.Elapsed,result);
        }
    }

    public interface IDuplicateFinder
    {
        bool IsDuplicate(int[] arr);
    }

    public class HashDuplicateFinder : IDuplicateFinder
    {
        public bool IsDuplicate(int[] arr)
        {
            var hash = new HashSet<int>();

            foreach (var i in arr)
            {
                if (hash.Contains(i))
                {
                    return true;
                }
                hash.Add(i);
            }
            return false;
        }
    }

    public class SortAndFind : IDuplicateFinder
    {
        public bool IsDuplicate(int[] arr)
        {
            Array.Sort(arr);
            
            for (var i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class QuickSortDuplicateFinder : IDuplicateFinder
    {
        public bool IsDuplicate(int[] arr)
        {
            var arrCopy = new int[arr.Length];
            Array.Copy(arr, arrCopy, arr.Length);
            return Sort(arrCopy);
        }

        private bool Sort(int[] arr, int? left = null, int? right = null)
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
                    if (arr[i] == arr[j] && i != j)
                    {
                        return true;
                    }

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
            return false;
        }

    }
}