﻿using System.Linq;
using NUnit.Framework;

namespace Interview.Graph
{
    public class DepthFirstSearch
    {
        private int iterations;

        [SetUp]
        public void Setup()
        {
            iterations = 0;
        }

        [Test]
        public void SearchTest()
        {
            var s = new GraphNodeVis<char>('S');
            var b = new GraphNodeVis<char>('B');
            s.Add(b);
            s.Add('A','Z','X');
            b.Add('C');

            Assert.That(Dfs(s,'C'), Is.True);
            Assert.That(iterations,Is.EqualTo(3));
        }

        [Test]
        public void Dfs_With_loop_NotFound()
        {
           var a = new GraphNodeVis<char>('A'); 
            a.Add('D');
            var t=new GraphNodeVis<char>('T');
            var b=new GraphNodeVis<char>('B');
            var c=new GraphNodeVis<char>('C');
            a.Add(b,c);

            b.Add(t);
            c.Add(t);

            Assert.That(Dfs(a, 'Z'), Is.False);
            Assert.That(iterations, Is.EqualTo(5));
        }

        public bool Dfs<T>(GraphNodeVis<T> root, T data)
        {
            iterations++;
            root.IsVisited = true;
            if (root.Data.Equals(data))
            {
                return true;
            }

            if (root.Connections == null)
            {
                return false;
            }

            foreach (var node in root.Connections.Where(x=>!x.IsVisited))
            {
                if (Dfs<T>(node, data))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
