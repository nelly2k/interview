using System;
using NUnit.Framework;

namespace Interview
{
    public class Primality
    {

        [Test]
        public void Not_Prime()
        {
            Assert.That(IsPrime(12), Is.False);
        }

        [Test]
        public void Is_Prime()
        {
            Assert.That(IsPrime(3), Is.True);
        }

        [Test]
        public void Four()
        {
            Assert.That(IsPrime(4), Is.False);
        }

        [Test]
        public void Multiple()
        {
            Assert.That(IsPrime(1), Is.False);
            Assert.That(IsPrime(4), Is.False);
            Assert.That(IsPrime(9), Is.False);
            Assert.That(IsPrime(16), Is.False);
            Assert.That(IsPrime(25), Is.False);
            Assert.That(IsPrime(36), Is.False);
            Assert.That(IsPrime(49), Is.False);
            Assert.That(IsPrime(64), Is.False);
            Assert.That(IsPrime(81), Is.False);
            Assert.That(IsPrime(100), Is.False);
            Assert.That(IsPrime(121), Is.False);
            Assert.That(IsPrime(144), Is.False);
            Assert.That(IsPrime(169), Is.False);
            Assert.That(IsPrime(196), Is.False);
            Assert.That(IsPrime(225), Is.False);
            Assert.That(IsPrime(256), Is.False);
            Assert.That(IsPrime(289), Is.False);
            Assert.That(IsPrime(324), Is.False);
            Assert.That(IsPrime(361), Is.False);
            Assert.That(IsPrime(400), Is.False);
            Assert.That(IsPrime(441), Is.False);
            Assert.That(IsPrime(484), Is.False);
            Assert.That(IsPrime(529), Is.False);
            Assert.That(IsPrime(576), Is.False);
            Assert.That(IsPrime(625), Is.False);
            Assert.That(IsPrime(676), Is.False);
            Assert.That(IsPrime(729), Is.False);
            Assert.That(IsPrime(784), Is.False);
            Assert.That(IsPrime(841), Is.False);
            Assert.That(IsPrime(907), Is.True);
        }


        private bool IsPrime(int num)
        {
            if (num < 2)
            {
                return true;
            }
            
            for (var i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
           
            return true;
        }
    }
}
