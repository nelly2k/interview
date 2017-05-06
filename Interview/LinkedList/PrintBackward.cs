using NUnit.Framework;

namespace Interview.LinkedList
{

    /// <summary>
    /// If your are given an Integer Singly linked list. Print it   backwards. 
    /// Constraints: 1. Do not manipulate the list. (example: do not make it a doubly linked list, do not add or delete elements, 
    /// do not change any memory location of any element) 2. O(n) < time < O(n^2) 3. O(1) < space < O(n) 
    /// </summary>
    public class PrintBackward
    {

        [Test]
        public void Simple()
        {
            var node = new LlNode<char>('a');
            node.Chain('b').Chain('c').Chain('d');

            Assert.That(Backward(node), Is.EqualTo("dcba"));

        }

        private string Backward(LlNode<char> node)
        {
            return (node.Next == null ? "" : Backward(node.Next)) + node.Data;
        }
    }
}
