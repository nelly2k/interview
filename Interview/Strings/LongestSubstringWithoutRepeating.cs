using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Strings
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters.
    /// </summary>
    public class LongestSubstringWithoutRepeating
    {
        [Test]
        public void Abc()
        {
            Assert.That(Find("abcabcbb"), Is.EqualTo("abc"));
            Assert.That(Calc("abcabcbb"), Is.EqualTo(3));
        }

        [Test]
        public void B()
        {
            Assert.That(Find("bbbbbb"), Is.EqualTo("b"));
            Assert.That(Calc("bbbbbb"), Is.EqualTo(1));
        }

        [Test]
        public void Pwke()
        {
            Assert.That(Find("pwwkew"), Is.EqualTo("wke"));
            Assert.That(Calc("pwwkew"), Is.EqualTo(3));
        }

        [Test]
        public void C()
        {
            Assert.That(Find("c"), Is.EqualTo("c"));
            Assert.That(Calc("c"), Is.EqualTo(1));
        }

        [Test]
        public void Empty()
        {
            Assert.That(Find(string.Empty), Is.EqualTo(string.Empty));
            Assert.That(Calc(string.Empty), Is.EqualTo(0));
        }

        [Test]
        public void Aab()
        {
            Assert.That(Find("aab"), Is.EqualTo("ab"));
            Assert.That(Calc("aab"), Is.EqualTo(2));
        }

        [Test]
        public void Dvdf()
        {
            Assert.That(Find("dvdf"), Is.EqualTo("vdf"));
            Assert.That(Calc("dvdf"), Is.EqualTo(3));
        }

        private int Calc(string s)
        {
            var longest = 0;
            var curr = string.Empty;

            foreach (var ch in s)
            {
                if (curr.Contains(ch.ToString()))
                {
                    if (curr.Length > longest)
                    {
                        longest = curr.Length;
                    }
                    curr = curr.Substring(curr.IndexOf(ch) + 1, curr.Length - curr.IndexOf(ch) - 1);
                }
                curr += ch;
            }
            if (curr.Length > longest)
            {
                longest = curr.Length;
            }
            return longest;
        }

        private string Find(string s)
        {
            var longest = string.Empty;
            var curr = string.Empty;

            foreach (var ch in s)
            {
                if (curr.Contains(ch.ToString()))
                {
                    if (curr.Length > longest.Length)
                    {
                        longest = curr;
                    }
                    
                    curr = curr.Substring(curr.IndexOf(ch)+1, curr.Length - curr.IndexOf(ch)-1);
                }
                curr += ch;
            }
            if (curr.Length > longest.Length)
            {
                longest = curr;
            }
            return  longest;
        }
    }
}