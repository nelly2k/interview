using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Interview.Graph
{
    public class BreathFirstSearch
    {
        private int nodesVisited;

        [SetUp]
        public void Setup()
        {
            nodesVisited = 0;
        }

        [Test]
        public void Simple()
        {
            var a = new GraphNodeVis<char>('A');
            a.Chain('B').Chain('D');
            a.Chain('C').Chain('E');

            Assert.That(Bfs( 'E',a), Is.True);
            Assert.That(nodesVisited, Is.EqualTo(5));
        }

        [Test]
        public void More_Complex()
        {
            var a = new GraphNodeVis<char>('A');   
            var e = new GraphNodeVis<char>('E');
            a.Chain('B').Add('D').Add(e);
            a.Chain('C').Add(e).Add('G').Chain('F').Add('K');

            Assert.That(Bfs('K',a), Is.True);
            Assert.That(nodesVisited, Is.EqualTo(9));
        }

        private bool Bfs(char c, GraphNodeVis<char> node)
        {
            var queue = new Queue<GraphNodeVis<char>>();
            queue.Enqueue(node);
            return Bfs(c, queue);
        }

        private bool Bfs(char c, Queue<GraphNodeVis<char>> queue)
        {
            var node = queue.Dequeue();
            nodesVisited++;
            if (node.Data.Equals(c))
            {
                return true;
            }

            if (!node.IsVisited)
            {
                if (node.Connections != null)
                {
                    foreach (var child in node.Connections)
                    {
                        queue.Enqueue(child);
                    }
                }

                node.IsVisited = true;
            }

            return Bfs(c,queue);
        }
    }
}