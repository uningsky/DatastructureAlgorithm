using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq; 
using 그래프2;
using 우선순위큐;

namespace DijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = Initialize2();
            


            HashSet<int> visited = new HashSet<int>(); 
            Dictionary<int, int> distance = new Dictionary<int, int>();
            Dictionary<int, int> path = new Dictionary<int, int>();

            int sourceVertex = 1;

            distance.Add(sourceVertex, 0);

            VertexDistance vertexDistance = new VertexDistance(sourceVertex, 0);

            PriorityQueue<VertexDistance> queue = new PriorityQueue<VertexDistance>();
            queue.Enqueue(vertexDistance);

            while (queue.Count > 0)
            {
                vertexDistance = queue.Dequeue();

                if (visited.Contains(vertexDistance.Vertex))
                {
                    continue; 
                }

                visited.Add(vertexDistance.Vertex);

                foreach (var adjacency in graph.Neighbors(vertexDistance.Vertex))
                {
                    var edge = graph.GetEdge(vertexDistance.Vertex, adjacency);

                    if (!distance.ContainsKey(adjacency))
                    {
                        distance.Add(adjacency, edge.Weight + distance[vertexDistance.Vertex]);
                        path.Add(adjacency, vertexDistance.Vertex);
                    }
                    else
                    {
                        if (distance[adjacency] > edge.Weight + distance[vertexDistance.Vertex])
                        {
                            distance[adjacency] = edge.Weight + distance[vertexDistance.Vertex];
                            path[adjacency] = vertexDistance.Vertex;
                        }
                    }

                    if (!visited.Contains(adjacency))
                    {
                        queue.Enqueue(new VertexDistance(adjacency, distance[adjacency]));
                    }
                }

                queue.RebuildHeapify();
            }

            foreach (var item in distance)
            {
                Console.WriteLine("vertex: {0}, distance: {1}", item.Key, item.Value);
            }

            foreach (var item in path)
            {
                Console.WriteLine("vertex: {0}, pre vertex: {1}", item.Key, item.Value);
            }
        }

        static Graph<int> Initialize1()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(1, 2, 7);
            graph.AddEdge(1, 3, 9);
            graph.AddEdge(1, 6, 14);
            graph.AddEdge(2, 3, 10);
            graph.AddEdge(2, 4, 15);
            graph.AddEdge(3, 6, 2);
            graph.AddEdge(3, 4, 11);
            graph.AddEdge(4, 5, 6);
            graph.AddEdge(5, 6, 9);

            return graph; 
        }

        static Graph<int> Initialize2()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(1, 2, 10);
            graph.AddEdge(1, 3, 30);
            graph.AddEdge(1, 4, 15);
            graph.AddEdge(2, 5, 20);
            graph.AddEdge(3, 4, 5);
            graph.AddEdge(3, 6, 5);
            graph.AddEdge(4, 6, 20);
            graph.AddEdge(5, 6, 20);

            return graph;
        }

        static Graph<int> Initialize3()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(1, 2, 6);
            graph.AddEdge(1, 3, 3);
            graph.AddEdge(2, 3, 2);
            graph.AddEdge(2, 4, 5);
            graph.AddEdge(3, 4, 3);
            graph.AddEdge(3, 5, 4);
            graph.AddEdge(4, 5, 2);
            graph.AddEdge(4, 6, 3);
            graph.AddEdge(5, 6, 5);

            return graph;
        }
    }

    public class VertexDistance : IComparable<VertexDistance>, IEquatable<VertexDistance>
    {
        public int Vertex { get; set; }
        public int Distance { get; set; }

        public VertexDistance(int vertex, int distance)
        {
            Vertex = vertex;
            Distance = distance;
        }

        public int CompareTo(VertexDistance obj)
        {
            return Distance.CompareTo(obj.Distance);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as VertexDistance);
        }

        public bool Equals(VertexDistance other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (Vertex.Equals(other.Vertex))
            {
                return true; 
            }

            return false; 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
