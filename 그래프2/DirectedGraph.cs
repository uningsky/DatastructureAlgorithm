using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class DirectedGraph<T>
    {
        private Dictionary<T, LinkedList<T>> _adjacencyList;

        public DirectedGraph()
        {
            _adjacencyList = new Dictionary<T, LinkedList<T>>();
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
                        yield return new UnweightedEdge<T>(vertex.Key, edge);
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

            _adjacencyList.Add(vertex, new LinkedList<T>());
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

            _adjacencyList[source].AddLast(destination);
            Console.WriteLine("Add Edge: \n{0}", destination);

            return true;
        }

        public bool RemoveEdge(T source, T destination)
        {
            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                Console.WriteLine("fail Add Edge, source 또는 destination vertex 존재 하지 않음");
                return false;
            }
            if (!IsExistEdge(source, destination))
            {
                return false;
            }

            _adjacencyList[source].Remove(destination);

            return true;
        }

        private T FindEdge(T source, T destination)
        {
            foreach (var item in _adjacencyList[source])
            {
                if (item.Equals(destination))
                {
                    return item;
                }
            }

            return default(T);
        }
        
        private bool IsExistEdge(T source, T destination)
        {
            return _adjacencyList[source].Contains(destination); 
        }

        public LinkedList<T> Neighbors(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                return null;
            }

            var neighbors = new LinkedList<T>();

            foreach (var item in _adjacencyList[vertex])
            {
                neighbors.AddLast(item);
            }

            return neighbors;
        }

        public void Clear()
        {
            _adjacencyList.Clear();
        }


    }
}
