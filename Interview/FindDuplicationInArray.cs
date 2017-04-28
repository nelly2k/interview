using System.Collections.Generic;
using System.Net.Http.Headers;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview
{
    public class FindDuplicationInArray
    {
        private IDuplicateFinder _duplicateFinder;

        [SetUp]
        public void Setup()
        {
            _duplicateFinder = new HashDuplicateFinder();
        }

        [Test]
        public void ShortArray_WithDuplicate()
        {
            var arr = new[] {1, 2, 3, 4, 6, 7, 8, 6, 9, 10};
            Assert.That(_duplicateFinder.IsDuplicate(arr), Is.True);
        }

        [Test]
        public void ShortArray_NoDuplicates()
        {
            var arr = new[] {1, 2, 5, 7, 8, 32};
            Assert.That(_duplicateFinder.IsDuplicate(arr), Is.False);
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

    public class QuickSortDuplicateFinder : IDuplicateFinder
    {
        public bool IsDuplicate(int[] arr)
        {
            
        }

        public void Quicksort(int[] arr, int left, int right)
        {
            var i = left;
            var j = right;

            var center = arr[(left + right) / 2];

            while (i <= j)
            {
                
            }
        }
    }
}