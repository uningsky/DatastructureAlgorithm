using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프
{
    public class GraphNode<T>
    {
        private List<GraphNode<T>> _neighbors;
        public IList<GraphNode<T>> Neighbors { get => _neighbors.AsReadOnly(); }
        public T Value { get; private set; }

        public GraphNode(T value)
        {
            this.Value = value;
            _neighbors = new List<GraphNode<T>>();
        }

        public bool AddNeighbor(GraphNode<T> neighbor)
        {
            if (_neighbors.Contains(neighbor) == true)
            {
                return false;
            }
            else
            {
                _neighbors.Add(neighbor);
                return true;
            }
        }

        public bool RemoveNeighbor(GraphNode<T> neighbor)
        {
            return _neighbors.Remove(neighbor);
        }

        public bool RemoveAllNeighbors()
        {
            for (int i = _neighbors.Count - 1; i >= 0; i--)
            {
                _neighbors.RemoveAt(i);
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("[\nNode Value: {0}, \n", Value);
            builder.Append("Neighbors: { ");
            for (int i = 0; i < _neighbors.Count; i++)
            {
                builder.Append(_neighbors[i].Value + " ");
            }
            builder.Append("} \n]");

            return builder.ToString();
        }
    }

}
