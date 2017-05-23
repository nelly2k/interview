using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Strings
{
    public class IsStringHasAllUniqueCharacters
    {
        [Test]
        public void Unique()
        {
            Assert.That(Runner("abcdfg"), Is.True);
        }
        [Test]
        public void Notunique()
        {
            Assert.That(Runner("abcdfgb"), Is.False);
        }


        public bool Runner(string str)
        {
            return IsAllUniqueQuick(str);

        }

        private bool UseLanguage(string str)
        {
            return str.Distinct().Count() == str.Length;
        }

        private bool IsAllUniquHash(string str)
        {
            var hash = new HashSet<char>();
            foreach (var ch in str)
            {
                if (hash.Contains(ch))
                {
                    return false;
                }

                hash.Add(ch);
            }
            return true;
        }

        private bool IsAllUniqueQuick(string str, int? left = null, int? right = null)
        {
            var foundDuplicate = false;
            if (left == null)
            {
                left = 0;
            }

            if (right == null)
            {
                right = str.Length-1;
            }

            var i = left.Value;
            var j = right.Value;
            var center = str[(j-i) / 2];

            while (i <= j)
            {
                while (str[i] < center)
                {
                    i++;
                }

                while (str[j] > center)
                {
                    j++;
                }

                if (i < j)
                {
                    var tmp = str[j];
                    str = Replace(str, j, str[i], out foundDuplicate);
                    if (foundDuplicate)
                    {
                        return true;
                    }
                    str = Replace(str, i, tmp ,out foundDuplicate);
                    if (foundDuplicate)
                    {
                        return true;
                    }
                    i++;
                    j--;
                }

                if (left < j)
                {
                    foundDuplicate &= IsAllUniqueQuick(str, left, j);
                }

                if (right > i)
                {
                    foundDuplicate &= IsAllUniqueQuick(str, i, right);
                }


            }
            return foundDuplicate;

        }

        private string Replace(string str, int ind, char ch, out bool foundDuplicate)
        {
            str = str.Remove(ind, 1);
            str = str.Insert(ind, ch.ToString());

            foundDuplicate = (ind!=str.Length-1 && str[ind] == str[ind + 1]) 
                || (ind != 0 && str[ind] == str[ind - 1]);
            return str;
        }


    }
}
