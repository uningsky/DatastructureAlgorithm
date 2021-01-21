using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class Graph<T>
    {
        private Dictionary<T, LinkedList<Edge<T>>> _adjacencyList;

        public Graph()
        {
            _adjacencyList = new Dictionary<T, LinkedList<Edge<T>>>();
        }

        public IEnumerable<T> Vertexs
        {
            get
            {
                foreach (var vertex in _adjacencyList)
                    yield return vertex.Key;
            }
        }

        public IEnumerable<Edge<T>> Edges
        {
            get
            {
                var duplicate = new HashSet<KeyValuePair<T, T>>(); 
                foreach (var vertex in _adjacencyList)
                {
                    foreach (var edge in vertex.Value)
                    {
                        var incoming = new KeyValuePair<T, T>(edge.Destination, edge.Source);
                        var outgoing = new KeyValuePair<T, T>(edge.Source, edge.Destination);

                        if (duplicate.Contains(incoming) || duplicate.Contains(outgoing))
                        {
                            continue; 
                        }
                        duplicate.Add(outgoing);

                        yield return edge;
                    }
                }
            }
        }

        public Edge<T> GetEdge(T source, T destination)
        {
            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                throw new KeyNotFoundException(); 
            }

            var edge = FindEdge(source, destination);

            if (edge == null)
            {
                throw new Exception("edge is not exist"); 
            }

            return edge; 
        }

        public int VerticesCount { get => _adjacencyList.Count; }

        public bool AddVertex(T vertex)
        {
            if (_adjacencyList.ContainsKey(vertex))
            {
                return false;
            }

            _adjacencyList.Add(vertex, new LinkedList<Edge<T>>());
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

            // 해당 vertex로 향하는 Edge 지우기
            foreach (var pair in _adjacencyList)
            {
                var edge = FindEdge(pair.Key, vertex);

                if (edge != null)
                {
                    pair.Value.Remove(edge);
                }
            }

            return true;
        }

        public bool AddEdge(T source, T destination, int weight)
        {
            // 가중치를 사용할 경우 
            if (weight == 0)
            {
                return false;
            }

            if (!_adjacencyList.ContainsKey(source) || !_adjacencyList.ContainsKey(destination))
            {
                Console.WriteLine("fail Add Edge, source 또는 destination vertex 존재 하지 않음");
                return false;
            }

            // edge 존재유무 판단 
            // 무방향, 역으로 된 엣지도 확인
            if (IsExistEdge(source, destination) || IsExistEdge(destination, source))
            {
                Console.WriteLine("fail Add Edge, source 또는 destination Edge 존재");
                return false;
            }

            // 무방향, 역으로 된 엣지도 추가 
            var sourceEdge = new Edge<T>(source, destination, weight);
            var destinationEdge = new Edge<T>(destination, source, weight);

            _adjacencyList[source].AddLast(sourceEdge);
            _adjacencyList[destination].AddLast(destinationEdge);
            Console.WriteLine("Add Edge: \n{0}", sourceEdge);
            Console.WriteLine("Add Edge: \n{0}", destinationEdge);

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
            var destinationEdge = FindEdge(destination, source);

            // 확인필요.
            if (sourceEdge == null && destinationEdge == null)
            {
                return false;
            }

            if (sourceEdge != null)
            {
                _adjacencyList[source].Remove(sourceEdge);
            }

            if (destinationEdge != null)
            {
                _adjacencyList[destination].Remove(destinationEdge);
            }

            return true;
        }

        private Edge<T> FindEdge(T source, T destination)
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

        public LinkedList<T> Neighbors(T vertex)
        {
            if (!_adjacencyList.ContainsKey(vertex))
            {
                return null; 
            }

            var neighbors = new LinkedList<T>();

            foreach (var item in _adjacencyList[vertex])
            {
                neighbors.AddLast(item.Destination); 
            }

            return neighbors; 
        }

        public void Clear()
        {
            _adjacencyList.Clear(); 
        }
    }
}
