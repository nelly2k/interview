using Interview.LinkedList;

namespace Interview
{
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
}
