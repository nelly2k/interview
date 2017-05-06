namespace Interview.LinkedList
{
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

        public LlNode<T> Chain(T data)
        {
            var node = new LlNode<T>(data);
            Next = node;
            return node;
        }
    }
}