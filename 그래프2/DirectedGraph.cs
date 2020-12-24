using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class DirectedGraph<T>
    {
        private Dictionary<T, LinkedList<UnweightedEdge<T>>> _adjacencyList;

        public DirectedGraph()
        {
            _adjacencyList = new Dictionary<T, LinkedList<UnweightedEdge<T>>>();
        }

        public IEnumerable<T> Vertexs
        {
            get
            {
                foreach (var vertex in _adjacencyList)
                    yield return vertex.Key;
            }
        }

        public IEnumerable<UnweightedEdge<T>> Edges
        {
            get
            {
                foreach (var vertex in _adjacencyList)
                {
                    foreach (var edge in vertex.Value)
                    {
                        yield return edge;
                    }
                }
            }
        }
        
        public int VerticesCount { get => _adjacencyList.Count; }

        public bool AddVertex(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            _adjacencyList.Add(vertex, new LinkedList<UnweightedEdge<T>>());
            Console.WriteLine("Add Vertex: {0}", vertex);

            return true;
        }

        public void AddVertices(IList<T> vertices)
        {
            if (vertices == null)
                throw new ArgumentNullException();

            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }
        }

        public bool RemoveVertex(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            _adjacencyList.Remove(vertex);

            return true;
        }

        public bool AddEdge(T source, T destination)
        {
            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                Console.WriteLine("fail Add Edge, source 또는 destination vertex 존재 하지 않음");
                return false;
            }

            // edge 존재유무 판단 
            // 방향이 있으므로 한쪽 방향만 판단 
            if (IsExistEdge(source, destination))
            {
                Console.WriteLine("fail Add Edge, source to destination Edge 존재");
                return false;
            }

            // 엣지 추가 
            var sourceEdge = new UnweightedEdge<T>(source, destination);

            _adjacencyList[source].AddLast(sourceEdge);
            Console.WriteLine("Add Edge: \n{0}", sourceEdge);

            return true;
        }

        public bool RemoveEdge(T source, T destination)
        {
            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                Console.WriteLine("fail Add Edge, source 또는 destination vertex 존재 하지 않음");
                return false;
            }

            var sourceEdge = FindEdge(source, destination);

            if (sourceEdge == null)
            {
                return false;
            }

            if (sourceEdge != null)
            {
                _adjacencyList[source].Remove(sourceEdge);
            }

            return true;
        }

        private UnweightedEdge<T> FindEdge(T source, T destination)
        {
            foreach (var item in _adjacencyList[source])
            {
                if (item.Source.Equals(source))
                {
                    if (item.Destination.Equals(destination))
                    {
                        return item;
                    }
                }
            }

            return null;
        }
        
        private bool IsExistEdge(T source, T destination)
        {
            foreach (var item in _adjacencyList[source])
            {
                if (item.Source.Equals(source))
                {
                    if (item.Destination.Equals(destination))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            _adjacencyList.Clear();
        }


    }
}
