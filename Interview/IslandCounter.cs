using NUnit.Framework;

namespace Interview
{
    public class IslandCounter
    {
        [Test]
        public void Corners()
        {
            var mat = new bool[3, 3];
            mat[0, 0] = mat[2, 2] = mat[0, 2] = mat[2, 0] = true;

            Assert.That(Counter(mat), Is.EqualTo(4));
        }

        [Test]
        public void Diagonal()
        {
            var mat = new bool[3, 3];
            mat[1, 1] = mat[2, 2] = true;

            Assert.That(Counter(mat), Is.EqualTo(1));
        }

        [Test]
        public void Side()
        {
            var mat = new bool[3, 3];
            mat[1, 1] = mat[1, 2] = true;

            Assert.That(Counter(mat), Is.EqualTo(1));
        }

        [Test]
        public void Large()
        {
            var mat = new bool[5,6];

            mat[1, 1] = mat[3, 0] = mat[4, 1] = mat[1, 2] = mat[2, 2] = mat[3, 3] = mat[0, 4] = mat[1, 5] = true;
            Assert.That(Counter(mat), Is.EqualTo(3));
        }

        private int Counter(bool[,] mat)
        {
            var counter = 0;
            for (var i = 0; i < mat.GetLength(0); i++)
            {
                for (var j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j])
                    {
                        counter++;
                        CleanIsland(mat, i, j);
                    }
                }
            }
            return counter;
        }

        private void CleanIsland(bool[,] mat, int i, int j)
        {
            if (i < 0 || i >= mat.GetLength(0) || j < 0 || j >= mat.GetLength(1) || !mat[i, j])
            {
                return;
            }
            
            mat[i, j] = false;
            var left = i - 1;
            var right = i + 1;
            var top = j + 1;
            var bottom = j + 1;

            CleanIsland(mat, left, top);
            CleanIsland(mat, left, j);
            CleanIsland(mat, left, bottom);

            CleanIsland(mat, i, top);
            CleanIsland(mat, i, bottom);

            CleanIsland(mat, right, top);
            CleanIsland(mat, right, j);
            CleanIsland(mat, right, bottom);
        }
    }
}
