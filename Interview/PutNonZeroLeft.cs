using NUnit.Framework;

namespace Interview
{
    public class PutNonZeroLeft
    {
        [Test]
        public void Simple()
        {
            var arr = new[] {5, 6, 8, 0, 9, 0};
            MoveZeros(arr);
            Assert.That(arr[0],Is.EqualTo(0));
            Assert.That(arr[1],Is.EqualTo(0));
            for (var i = 2;i< arr.Length; i++)
            {
                Assert.That(arr[i], Is.Not.EqualTo(0));
            }
        }

        [Test]
        public void Empty()
        {
            var arr = new int[0];

            MoveZeros(arr);
        }

        [Test]
        public void One_El_0()
        {
            var arr = new[]{0};

            MoveZeros(arr);
            Assert.That(arr[0], Is.EqualTo(0));
        }

        [Test]
        public void One_El_Non_0()
        {
            var arr = new[] { 1 };

            MoveZeros(arr);
            Assert.That(arr[0], Is.EqualTo(1));
        }

        [Test]
        public void Many_zeros()
        {
            var arr = new[] { 5,0,6,0,8,0,0,0,8,9};

            MoveZeros(arr);

            for (var i = 0; i < 4; i++)
            {
                Assert.That(arr[i], Is.EqualTo(0));
            }

            for (var i = 5; i < arr.Length; i++)
            {
                Assert.That(arr[i], Is.Not.EqualTo(0));
            }
        }

        private void MoveZeros(int[] arr)
        {
            var i = 0;
            var j = arr.Length-1;

            while (i<j)
            {
                while (arr[i] == 0 && i < j)
                {
                    i++;
                }

                while (arr[j] != 0 && j >0)
                {
                    j--;
                }
                if (i < j)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }
}
