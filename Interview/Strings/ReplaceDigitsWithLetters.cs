using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Interview.Strings
{
    public class ReplaceDigitsWithLetters
    {
        [Test]
        public void TwoNum()
        {
            var result = new[] { "AD", "AE", "AF", "BD", "BE", "BF", "CD", "CE", "CF" };

            Check(Cl("12"), result);
        }

        [Test]
        public void ThreeNums()
        {
            var result = new[]
            {
                "GAD", "GAE", "GAF",
                "GBD", "GBE", "GBF",
                "GCD", "GCE", "GCF",
                "HAD", "HAE", "HAF",
                "HBD", "HBE", "HBF",
                "HCD", "HCE", "HCF",
                "JAD", "JAE", "JAF",
                "JBD", "JBE", "JBF",
                "JCD", "JCE", "JCF"
            };
            Assert.That(result.Length, Is.EqualTo(27));

            Check(Cl("312"), result);
        }


        private static Dictionary<char, char[]> Mapping => new Dictionary<char, char[]>
        {
            {'3', new[] {'G', 'H', 'J'}},
            {'1', new[] {'A', 'B', 'C'}},
            {'2', new[] {'D', 'E', 'F'}},

        };


        private void Check(string[] result, string[] expected)
        {
            foreach (var s in expected)
            {
                Assert.That(result.Any(x => x == s), Is.True);
            }
        }

        private string[] Cl(string s)
        {
            var hash = new List<string>();
            GetCombo(s);

            void GetCombo(string strKeys)
            {
                if (!strKeys.Any(char.IsDigit))
                {
                    hash.Add(strKeys);
                    return;
                }
                var digit = strKeys.First(char.IsDigit);
                foreach (var ch in Mapping[digit])
                {
                    GetCombo(strKeys.Replace(digit, ch));
                }
            }

            return hash.ToArray();
        }


        private string[] Calc(string dig, Dictionary<char, char[]> mapping)
        {
            var lineLength = mapping['1'].Length;
            var count = Math.Pow(lineLength, dig.Length);
            var counter = new int[dig.Length];

            var output = new List<string>();

            for (var i = 0; i < count; i++)
            {
                var cur = string.Empty;

                foreach (var ch in dig)
                {
                    cur += mapping[ch][counter[dig.IndexOf(ch)]];
                }

                output.Add(cur);

                for (var j = counter.Length - 1; j >= 0; j--)
                {
                    if (counter[j] < lineLength - 1)
                    {

                        if (counter[j] == 0)
                        {
                            for (var m = j + 1; m < counter.Length; m++)
                            {
                                counter[m] = 0;
                            }
                        }

                        counter[j]++;
                        break;
                    }
                    if (counter[j] == lineLength - 1)
                    {
                        counter[j] = 0;
                    }
                }

            }
            return output.ToArray();
        }

    }
}
