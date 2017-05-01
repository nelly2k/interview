using NUnit.Framework;

namespace Interview
{
    public class LargestRegion
    {
        [Test]
        public void Diagonal()
        {
            var mat = new short[4, 4];

            mat[3, 3] = mat[2, 2] = mat[3, 2] = mat[0,1] = 1;
            Assert.That(IslandFinder(mat), Is.EqualTo(3));
        }

        [Test]
        public void Side()
        {
            var mat = new short[4, 4];

            mat[3, 3] = mat[3, 2] = mat[0, 1] = 1;
            Assert.That(IslandFinder(mat), Is.EqualTo(2));
           
        }

        private int IslandFinder(short[,] mat)
        {
            var maxRegion = 0;
            for (var i = 0; i < mat.GetLength(0); i++)
            {
                for (var j = 0; j < mat.GetLength(1); j++)
                {
                    if (mat[i, j] == 0)
                    {
                        continue;
                    }
                    var regions = RegionCounter(mat, i, j);
                    if (maxRegion < regions)
                    {
                        maxRegion = regions;
                    }
                }
            }

            return maxRegion;
        }

        private int RegionCounter(short[,] mat, int i, int j)
        {
            if (i < 0 || i >= mat.GetLength(0) || j < 0 || j >= mat.GetLength(1) || mat[i, j] == 0)
            {
                return 0;
            }
            var left = i - 1;
            var right = i + 1;
            var top = j - 1;
            var bottom = j + 1;

            mat[i, j] = 0;

            return 1 + RegionCounter(mat, left, top) + RegionCounter(mat, left, j) + RegionCounter(mat, left, bottom)
                   + RegionCounter(mat, i, top) + RegionCounter(mat, i, bottom)
                   + RegionCounter(mat, right, top) + RegionCounter(mat, right, j) + RegionCounter(mat, right, bottom);
            
        }
    }
}
