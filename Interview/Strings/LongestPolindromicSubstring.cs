using System;
using NUnit.Framework;

namespace Interview.Strings
{
    public class LongestPolindromicSubstring
    {

        [Test]
        public void baba()
        {
            Assert.That(Calc("babad"), Is.EqualTo("bab"));
        }

        [Test]
        public void cbbd()
        {
            Assert.That(Calc("cbbd"), Is.EqualTo("bb"));
        }

        private string Calc(string s)
        {
            var maxLen = 0;
            var location = 0;
            if (s.Length < 2)
            {
                return s;
            }

            for (var i = 0; i < s.Length - 1; i++)
            {
                var res = Extend(s, i, i);
                if (maxLen < res.Item2)
                {
                    maxLen = res.Item2;
                    location = res.Item1;
                }

                var res1= Extend(s,i,i+1);
                if (maxLen < res1.Item2)
                {
                    maxLen = res1.Item2;
                    location = res1.Item1;
                }
            }

            return s.Substring(location, maxLen);

        }

        private Tuple<int,int> Extend(string s, int j, int k)
        {
            while (j >=0 && k < s.Length && s[j]==s[k])
            {
                j--;
                k++;
            }

            return new Tuple<int, int>(j+1, k-j-1);
        }
    }
}
