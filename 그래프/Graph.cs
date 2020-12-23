using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프
{
    public class Graph<T>
    {
        private List<GraphNode<T>> _nodes = new List<GraphNode<T>>(); 
        public IList<GraphNode<T>> Nodes { get => _nodes.AsReadOnly();  }
        public int Count { get => _nodes.Count; }

        public Graph()
        {
        }
        
        public void Clear()
        {
            foreach (GraphNode<T> node in _nodes)
            {
                node.RemoveAllNeighbors(); 
            }

            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                _nodes.RemoveAt(i); 
            }
        }

        public bool AddNode(T value)
        {
            if (Find(value) != null)
            {
                return false; 
            }
            else
            {
                _nodes.Add(new GraphNode<T>(value));
                return true; 
            }
        }

        public bool AddEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);

            if (node1 == null || node2 == null)
            {
                return false; 
            }
            else if (node1.Neighbors.Contains(node2))
            {
                return false; 
            }
            else
            {
                // 무방향 그래프, 각 노드를 이웃으로 추가 
                node1.AddNeighbor(node2);
                node2.AddNeighbor(node1);
                return true; 
            }
        }

        public bool RemoveNode(T value)
        {
            GraphNode<T> removeNode = Find(value);
            if (removeNode == null)
            {
                return false; 
            }
            else
            {
                _nodes.Remove(removeNode);
                foreach (GraphNode<T> node in _nodes)
                {
                    node.RemoveNeighbor(removeNode); 
                }
                return true; 
            }
        }

        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T> node1 = Find(value1);
            GraphNode<T> node2 = Find(value2);

            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if(!node1.Neighbors.Contains(node2))
            {
                return false; 
            }
            else
            {
                // 무방향 그래프, 각 노드에서 모두 지워줘야 함
                node1.RemoveNeighbor(node2);
                node2.RemoveNeighbor(node1);
                return true; 
            }
        }

        public GraphNode<T> Find(T value)
        {
            foreach (GraphNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node; 
                }
            }
            return null; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                builder.Append(_nodes[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(", ");
                }
            }
            return builder.ToString(); 
        }
    }
}
