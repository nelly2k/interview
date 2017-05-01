using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Interview.LinkedList
{
    /// <summary>
    /// You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    ///You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    /// </summary>
    public class SumOfLinkedLists
    {

        [Test]
        public void Simple()
        {
            var node1 = new LlNode<int>(2);
            node1.Chain(4).Chain(3);
            var node2 = new LlNode<int>(5);
            node2.Chain(6).Chain(4);
            var sum = Sum(node1, node2);

            Assert.That(sum.Data, Is.EqualTo(7));
            Assert.That(sum.Next.Data, Is.EqualTo(0));
            Assert.That(sum.Next.Next.Data, Is.EqualTo(8));
            Assert.That(sum.Next.Next.Next, Is.Null);
        }

        [Test]
        public void MovedToCarier()
        {
            var n1 = new LlNode<int>(5);
            var n2 = new LlNode<int>(5);

            var sum = Sum(n1, n2);

            Assert.That(sum.Data ,Is.EqualTo(0));
            Assert.That(sum.Next.Data ,Is.EqualTo(1));
            Assert.That(sum.Next.Next ,Is.Null);
        }

        [Test]
        public void Lists_Not_Equal()
        {
            var n1 = new LlNode<int>(1);
            n1.Chain(8);
            
            var n2 = new LlNode<int>(0);
            var sum = Sum(n1, n2);

            Assert.That(sum.Data, Is.EqualTo(1));
            Assert.That(sum.Next.Data, Is.EqualTo(8));
            Assert.That(sum.Next.Next, Is.Null);
        }

        [Test]
        public void Lists_Not_Equal2()
        {
            var n1 = new LlNode<int>(1);
            n1.Chain(8);

            var n2 = new LlNode<int>(0);
            var sum = Sum(n2, n1);

            Assert.That(sum.Data, Is.EqualTo(1));
            Assert.That(sum.Next.Data, Is.EqualTo(8));
            Assert.That(sum.Next.Next, Is.Null);
        }


        private LlNode<int> Sum(LlNode<int> node1, LlNode<int> node2, int extra = 0)
        {
            var num = node1.Data + node2.Data + extra;
            var carier = (num - num % 10) / 10;
            var node = new LlNode<int>(num % 10);

            var nextNode1 = node1.Next;
            if (nextNode1 == null && node2.Next != null)
            {
                nextNode1 = new LlNode<int>(0);
            }

            var nextNode2 = node2.Next;
            if (nextNode2 == null && node1.Next != null)
            {
                nextNode2 = new LlNode<int>(0);
            }

            if (nextNode1 != null && nextNode2 != null)
            {
                node.Next = Sum(nextNode1, nextNode2, carier);
            }
            else if (carier > 0)
            {
                node.Next = new LlNode<int>(carier);
            }
            
            return node;
        }
    }
}
