using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Numbers
{
    public class ClosestToYear
    {
        [Test]
        public void Y99()
        {
            Assert.That(Closest(99), Is.EqualTo(1999));
            Assert.That(Closest(15), Is.EqualTo(2015));
            Assert.That(Closest(2), Is.EqualTo(2002));
            Assert.That(Closest(50), Is.EqualTo(1950));
            Assert.That(Closest(17), Is.EqualTo(2017));
        }

        private int Closest(int num)
        {
            var current = DateTime.Today.Year;
            var lastTwoDig = current % 100;
            return num > lastTwoDig ? current - 100 - lastTwoDig + num : current - lastTwoDig + num;
        }
    }
}