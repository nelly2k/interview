using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Data Structures: Cycles in Linked List
    /// https://www.youtube.com/watch?v=MFOAbpfrJ8g&list=PLHursRsSD348tf828Y17UWjpSyXuJPXUw
    /// Time complexity is O(n) because it is require to traverse through the whole list
    /// </summary>
    public class CyclesInLinkedList
    {

        [Test]
        public void Cycle()
        {
            var node0= new LlNode<int>(0);
            var node1 = new LlNode<int>(1);
            var node2 = new LlNode<int>(2);
            node0.Next = node1;
            node1.Next = node2;
            node2.Next = node1;

            Assert.That(CycleFinder.Find(node0), Is.True);
        }

        [Test]
        public void LongCycle()
        {
            var node0 = new LlNode<int>(0);
            var node1 = new LlNode<int>(1);
            node0.Next = node1;

            node1.Next = new LlNode<int>(2).Next = new LlNode<int>(30).Next = node1;

            Assert.That(CycleFinder.Find(node0), Is.True);
        }

        [Test]
        public void LongerCycle()
        {
            var node0 = new LlNode<int>(0);
            var node1 = new LlNode<int>(1);
            var node2 = new LlNode<int>(2);
            var node3 = new LlNode<int>(3);
            var node4 = new LlNode<int>(4);
            var node5 = new LlNode<int>(5);
            node0.Next = node1;
            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node1;

            Assert.That(CycleFinder.Find(node0), Is.True);
        }

        [Test]
        public void NoCycle()
        {
            var node0 = new LlNode<int>(0);
            var node1 = new LlNode<int>(1);
            var node2 = new LlNode<int>(2);
            var node3 = new LlNode<int>(3);
            node0.Next = node1;
            node1.Next = node2;
            node2.Next = node3;

            Assert.That(CycleFinder.Find(node0), Is.False);
        }

        [Test]
        public void Null_node()
        {
            Assert.That(CycleFinder.Find<int>(null), Is.False);
        }
    }

    public class CycleFinder
    {
        public static bool Find<T>(LlNode<T> root)
        {
            if (root== null || root.Next==null)
            {
                return false;
            }
            var slow = root.Next;
            var fast = root.Next.Next;

            while (fast!=null && slow!=null)
            {
                if (slow.Data.Equals(fast.Data))
                {
                    return true;
                }
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return false;
        }
    }

    public class LlNode<T>
    {
        public LlNode()
        {
            
        }

        public LlNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public LlNode<T> Next { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
