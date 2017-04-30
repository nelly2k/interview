using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview.Graph
{
    public class GraphNode<T>
    {
        public GraphNode(T data)
        {
            Data = data;
        }
        public List<GraphNode<T>> Connections { get; set; }
        public bool IsVisited { get; set; }
        
        public T Data { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }

        public void Add(params GraphNode<T>[] nodes)
        {
            if (Connections == null)
            {
                Connections = new List<GraphNode<T>>();
            }
            foreach (var node in nodes)
            {
                if (Connections.Any(x => node.Data.Equals(x.Data)))
                {
                    throw new Exception("Already exists");
                }

                Connections.Add(node);
            }
           
        }

        public void Add(params T[] datas)
        {
            foreach (var data in datas)
            {
                Add(new GraphNode<T>(data));
            }
        }
    }
}