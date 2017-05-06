using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview
{
    public class Brackets
    {
        [Test]
        public void Short_Yes()
        {
            Assert.That(IsBalansed("{[()]}"), Is.True);
        }

        [Test]
        public void Long_No()
        {
            Assert.That(IsBalansed(")}{){(]{)([)}{)]())[(})[]]))({[[[)}[((]](])][({[]())"), Is.False);
        }

        [Test]
        public void Short_No()
        {
            Assert.That(IsBalansed("{[(])}"), Is.False);
        }

        [Test]
        public void LongYes()
        {
            Assert.That(IsBalansed("{{[[(())]]}}"), Is.True);
        }

        [Test]
        public void LongComplexYes()
        {
            Assert.That(IsBalansed("{{[[([]()){}]]}}"), Is.True);
        }

        [Test]
        public void LongComplexNo()
        {
            Assert.That(IsBalansed("{{[[([]()){}]]}}{"), Is.False);
        }

        private bool IsBalansed(string s)
        {
            var st = new Stack<char>();
            var matches = new Dictionary<char, char>
            {
                {']','[' },
                {'}','{' },
                {')','(' },
            };
            foreach (var ch in s)
            {
                if (!matches.ContainsKey(ch))
                {
                    st.Push(ch);
                }
                else
                {
                    if (st.Count <= 0 || st.Peek() != matches[ch])
                        return false;

                    st.Pop();
                }
            }

            return st.Count == 0;
        }
    }
}