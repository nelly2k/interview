using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Trees: Is This a Binary Search Tree?
    /// https://www.hackerrank.com/ctci-book?ref=body
    /// </summary>
    public class IsThisBst
    {

        public bool IsBst(BstNode root)
        {
            if (root == null)
            {
                return true;
            }

            return (root.Left == null || root.Left.Data < root.Data)
                   && (root.Right == null || root.Right.Data > root.Data)
                   && IsBst(root.Left)
                   && IsBst(root.Right);
        }

        [Test]
        public void ItIsBst()
        {
            var node0 = new BstNode(5);
            var node01 = new BstNode(4);
            var node02 = new BstNode(6);

            node0.Left = node01;
            node0.Right = node02;

            Assert.That(IsBst(node0), Is.True);
        }

        [Test]
        public void Null_Node()
        {
            Assert.That(IsBst(null), Is.True);
        }

        [Test]
        public void LeftIsNull_StillBst()
        {
            var node0 = new BstNode(5);
            var node02 = new BstNode(6);
            node0.Right = node02;
            Assert.That(IsBst(node0), Is.True);
        }

        [Test]
        public void LeftIsNull_NotBst()
        {
            var node0 = new BstNode(5);
            var node02 = new BstNode(4);
            node0.Right = node02;
            Assert.That(IsBst(node0), Is.False);
        }

        [Test]
        public void RightIsNull_StillBst()
        {
            var node0 = new BstNode(5);
            var node01 = new BstNode(4);
            node0.Left = node01;
            Assert.That(IsBst(node0), Is.True);
        }

        [Test]
        public void RightIsNull_NotBst()
        {
            var node0 = new BstNode(5);
            var node01 = new BstNode(6);
            node0.Left = node01;
            Assert.That(IsBst(node0), Is.False);
        }

        [Test]
        public void Repeating()
        {
            var node0 = new BstNode(5);
            var node01 = new BstNode(5);
            var node02 = new BstNode(6);

            node0.Left = node01;
            node0.Right = node02;
            Assert.That(IsBst(node0), Is.False);
        }
    }



    public class BstNode
    {

        public BstNode(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public BstNode Left { get; set; }
        public BstNode Right { get; set; }

        public override bool Equals(object obj)
        {
            var node = (BstNode)obj;
            return node != null && node.Data.Equals(Data);
        }
    }
}
