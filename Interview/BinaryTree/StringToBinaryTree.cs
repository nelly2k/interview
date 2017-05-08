using NUnit.Framework;

namespace Interview.Strings
{
    /// <summary>
    /// Convert ternary expression into a Binary tree
    /// </summary>
    public class StringToBinaryTree
    {
        [Test]
        public void Simple()
        {
            var s = "a?b?c:d:e";
            var root = new BtNode<char>();
           Convert(s, root);
            Assert.That(root.Data, Is.EqualTo('a'));
            Assert.That(root.Left.Data, Is.EqualTo('b'));
            Assert.That(root.Right.Data, Is.EqualTo('e'));
            Assert.That(root.Left.Left.Data, Is.EqualTo('c'));
            Assert.That(root.Left.Right.Data, Is.EqualTo('d'));

        }

        [Test]
        public void Empty()
        {
            var root = new BtNode<char>();
            Convert("", root);
            Assert.That(root.Data, Is.EqualTo(default(char)));
        }

        public void Convert(string s, BtNode<char> root)
        {
            if (s.Contains("?") && s.Contains(":"))
            {
                var questionMark = s.IndexOf("?");

                var colon = s.LastIndexOf(":");

                var r = s.Substring(0, 1);
                var left = s.Substring(questionMark + 1, colon- questionMark-1);
                var right = s.Substring(colon + 1);

                root.Data = r[0];

                if (left.Length > 0)
                {
                    root.Left = new BtNode<char>();
                    Convert(left, root.Left);

                }

                if (right.Length > 0)
                {
                    root.Right = new BtNode<char>();
                    Convert(right, root.Right);
                }
            }
            else if (s.Length == 1)
            {
                root.Data = s[0];
            }
        }
    }

    public class BtNode<T>{
        public BtNode()
        {
            
        }
        public BtNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public BtNode<T> Left { get; set; }
        public BtNode<T> Right { get; set; }
    }

}
