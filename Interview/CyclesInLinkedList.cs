using NUnit.Framework;

namespace Interview
{
    /// <summary>
    /// Data Structures: Cycles in Linked List
    /// https://www.youtube.com/watch?v=MFOAbpfrJ8g&list=PLHursRsSD348tf828Y17UWjpSyXuJPXUw
    /// </summary>
    public class CyclesInLinkedList
    {

        [Test]
        public void Cycle()
        {
            var node0= new Node<int>(0);
            var node1 = new Node<int>(1);
            node0.Next = node1;

            node1.Next = new Node<int>(2).Next = node1;
            
            Assert.That(CycleFinder.Find(node0), Is.True);
        }

        [Test]
        public void LongCycle()
        {
            var node0 = new Node<int>(0);
            var node1 = new Node<int>(1);
            node0.Next = node1;

            node1.Next = new Node<int>(2).Next = new Node<int>(30).Next = node1;

            Assert.That(CycleFinder.Find(node0), Is.True);
        }

        [Test]
        public void NoCycle()
        {
            var node = new Node<int>(0).Next = new Node<int>(1).Next = new Node<int>(2);
            Assert.That(CycleFinder.Find(node), Is.False);
        }

        [Test]
        public void Null_node()
        {
            Assert.That(CycleFinder.Find<int>(null), Is.False);
        }
    }

    public class CycleFinder
    {
        public static bool Find<T>(Node<T> root)
        {
            if (root?.Next?.Next == null)
            {
                return false;
            }
            var faster = root.Next.Next;
            var slow = root.Next;

            if (faster.Data.Equals(slow.Data))
            {
                return true;
            }

            return Find<T>(slow);
        }
    }


    public class Node<T>
    {
        public Node()
        {
            
        }

        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }

    }
}
