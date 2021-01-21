using System;
using System.Collections.Generic;
using 그래프2;
using 우선순위큐;

namespace DijkstraAlgorithm
{
    class Program
    {
        static void Main(string[] args)
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

            HashSet<int> visited = new HashSet<int>(); 
            Dictionary<int, int> distance = new Dictionary<int, int>();
            Dictionary<int, int> path = new Dictionary<int, int>();

            int sourceVertex = 1;
            int destinationVertex = 5;

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


                if (vertexDistance.Vertex == destinationVertex)
                {
                    break;
                }

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

        
    }

    public class VertexDistance : IComparable<VertexDistance>
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

        
    }
}
