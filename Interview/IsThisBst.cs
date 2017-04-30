using System.Collections.Generic;
using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Trees: Is This a Binary Search Tree?
    /// https://www.hackerrank.com/ctci-book?ref=body
    /// </summary>
    public class IsThisBst
    {
        public bool IsBst(BstNode root, int min = int.MinValue, int max = int.MaxValue)
        {
            if (root == null)
            {
                return true;
            }
            return (root.Left == null || (root.Left.Data < root.Data && root.Left.Data > min))
                   && (root.Right == null || (root.Right.Data > root.Data && root.Right.Data < max))
                   && IsBst(root.Left, min, root.Data)
                   && IsBst(root.Right, root.Data, max);

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

        [Test]
        public void DeepDuplicate()
        {
            var node0 = new BstNode(50);
            var node01 = new BstNode(40);
            var node002 = new BstNode(45);
            var node0002 = new BstNode(50);


            node0.Left = node01;
            node01.Right = node002;
            node002.Right = node0002;
            Assert.That(IsBst(node0), Is.False);
        }

        [Test]
        public void DeepWrong()
        {
            var node0 = new BstNode(5);
            var node02 = new BstNode(6);
            var node001 = new BstNode(4);

            node0.Right = node02;
            node02.Left = node001;
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

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
