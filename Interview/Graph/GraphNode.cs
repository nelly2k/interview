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
                    throw new Exception($"For node {Data} connection {node.Data} already exists");
                }

                Connections.Add(node);
            }
           
        }

        public GraphNode<T> Chain(T data)
        {
            var node = new GraphNode<T>(data);
            if (Connections == null)
            {
                Connections = new List<GraphNode<T>>();
            }
            Connections.Add(node);

            return node;
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