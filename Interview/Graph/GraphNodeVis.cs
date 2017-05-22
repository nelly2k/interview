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
        public List<GraphNodeVis<T>> Connections { get; set; }
        
        public T Data { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }

        public GraphNode<T> Add(params GraphNodeVis<T>[] nodes)
        {
            if (Connections == null)
            {
                Connections = new List<GraphNodeVis<T>>();
            }
            foreach (var node in nodes)
            {
                if (Connections.Any(x => node.Data.Equals(x.Data)))
                {
                    throw new Exception($"For node {Data} connection {node.Data} already exists");
                }

                Connections.Add(node);
            }
            return this;
        }

        public GraphNodeVis<T> Chain(T data)
        {
            var node = new GraphNodeVis<T>(data);
            if (Connections == null)
            {
                Connections = new List<GraphNodeVis<T>>();
            }
            Connections.Add(node);

            return node;
        }

        public GraphNode<T> Add(params T[] datas)
        {
            foreach (var data in datas)
            {
                Add(new GraphNodeVis<T>(data));
            }
            return this;
        }
    }
    public class GraphNodeVis<T>: GraphNode<T>
    {
        public GraphNodeVis(T data):base(data)
        {
            Data = data;
        }
        public bool IsVisited { get; set; }
        

        public override string ToString()
        {
            return Data.ToString();
        }

        public new GraphNodeVis<T>  Add(params GraphNodeVis<T>[] nodes)
        {
            if (Connections == null)
            {
                Connections = new List<GraphNodeVis<T>>();
            }
            foreach (var node in nodes)
            {
                if (Connections.Any(x => node.Data.Equals(x.Data)))
                {
                    throw new Exception($"For node {Data} connection {node.Data} already exists");
                }

                Connections.Add(node);
            }
            return this;
        }

        public new GraphNodeVis<T> Chain(T data)
        {
            var node = new GraphNodeVis<T>(data);
            if (Connections == null)
            {
                Connections = new List<GraphNodeVis<T>>();
            }
            Connections.Add(node);

            return node;
        }

        public new GraphNodeVis<T> Add(params T[] datas)
        {
            foreach (var data in datas)
            {
                Add(new GraphNodeVis<T>(data));
            }
            return this;
        }
    }
}