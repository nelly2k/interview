using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Numbers
{
    public class LotteryNumbers
    {

        [Test]
        public void Simple1()
        {
            var str = "4938532894754";
            Assert.That(IsValid(str),Is.True);
        }

        [Test]
        public void Simple2()
        {
            var str = "1634616512";
            Assert.That(IsValid(str), Is.True);
        }

        [Test]
        public void Simple3()
        {
            var str = "1122334";
            Assert.That(IsValid(str), Is.False);
        }

        [Test]
        public void One()
        {
            var str = "4";
            Assert.That(IsValid(str), Is.False);
        }

        private bool IsValid(string str)
        {
            return Nums(str, new HashSet<int>());
        }

        private bool Nums(string str, HashSet<int> found)
        {
            if (str == "" && found.Count == 7)
            {
                return true;
            }

            if (str == "" && found.Count != 7)
            {
                return false;
            }

            var firstInt = int.Parse(str[0].ToString());
            var hasTwo = str.Length >= 2;
            var firstTwoInt = 0;
            if (hasTwo)
            {
                firstTwoInt = int.Parse(str.Substring(0, 2));
            }
            
            if (found.Contains(firstInt) && (!hasTwo || found.Contains(firstTwoInt)))
            {
                return false;
            }

            return Nums(str.Substring(1), new HashSet<int>(found) {firstInt})
                   || (hasTwo && firstTwoInt <= 59 && Nums(str.Substring(2), new HashSet<int>(found) {firstTwoInt}));
        }
        //Can use dynamic programming here
        //private bool Nums2(string str, HashSet<int> found, Dictionary<string, bool> dp)
        //{
        //    if (str == "" && found.Count == 7)
        //    {
        //        return true;
        //    }

        //    if (str == "" && found.Count != 7)
        //    {
        //        return false;
        //    }

        //    var firstInt = int.Parse(str[0].ToString());
        //    var hasTwo = str.Length >= 2;
        //    var firstTwoInt = 0;
        //    if (hasTwo)
        //    {
        //        firstTwoInt = int.Parse(str.Substring(0, 2));
        //    }
            
        //    if (found.Contains(firstInt) && (!hasTwo || found.Contains(firstTwoInt)))
        //    {
        //        return false;
        //    }
        //    var calcOne = Nums(str.Substring(1), new HashSet<int>(found) {firstInt});
        //    dp.Add(str.Substring(1), calcOne);



        //    return Nums(str.Substring(1), new HashSet<int>(found) {firstInt})
        //           || (hasTwo && firstTwoInt <= 59 && Nums(str.Substring(2), new HashSet<int>(found) {firstTwoInt}));
        //}
    }
}
