using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Graph
{
    public class IsWordExistsInGraph
    {
        [Test]
        public void Dog_Exists()
        {
            var a = new GraphNodeVis<char>('a');
            a.Chain('d').Chain('o').Chain('g');
            Assert.That(IsExists(a, "dog"), Is.True);
        }

        [Test]
        public void Dog_NotExists()
        {
            var a = new GraphNodeVis<char>('a');
            a.Add('b', 'r', 't');
            a.Chain('m').Chain('t');
            Assert.That(IsExists(a, "dog"), Is.False);
        }

        [Test]
        public void Dog_NotExists1()
        {
            var a = new GraphNodeVis<char>('a');
            a.Add('b', 'r', 't');
            a.Chain('m').Chain('t').Chain('d').Chain('g').Chain('o');
            
            Assert.That(IsExists(a, "dog"), Is.False);
        }

        [Test]
        public void Dog_Exists1()
        {
            var a = new GraphNodeVis<char>('a');
            a.Add('b', 'r', 't');
            a.Chain('m').Chain('d').Chain('d').Chain('o').Chain('g').Add('d');

            Assert.That(IsExists(a, "dog"), Is.True);
        }

        [Test]
        public void WithLoop()
        {
            var m = new GraphNodeVis<char>('m');
            var d = new GraphNodeVis<char>('d');
            var t = new GraphNodeVis<char>('t');
            var o = new GraphNodeVis<char>('o');
            var g = new GraphNodeVis<char>('g');
            
            m.Add(t,d);

            d.Add(m,g,o,t);

            o.Add(d,g);

            g.Add(o,d);
            Assert.That(IsExists(m, "dog"), Is.True);
        }

        private bool IsExists(GraphNodeVis<char> node, string word, int index = 0)
        {
            if (!word.Contains(node.Data))
            {
                node.IsVisited = true;
            }
            
            if (index >= word.Length)
            {
                return true;
            }
            if (node.Connections == null)
            {
                return false;
            }
            foreach (var child in node.Connections.Where(x=>!x.IsVisited))
            {
                if (index == word.IndexOf(child.Data))
                {
                    if (IsExists(child, word, index + 1))
                    {
                        return true;
                    }
                }
                else
                {
                    if (IsExists(child, word, index))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
