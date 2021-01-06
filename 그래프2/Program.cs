using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    class Program
    {

        static void Main(string[] args)
        {
            // TestIsCycleDFS(); 
            //TestIsCycleUnionFind();
            TestDirectedGraph(); 
        }

        static void TestUnDirectedGraph()
        {
        }

        static void UnDirectedGraphBFSWithLevel()
        {
            
        }

        static void TestDirectedGraph()
        {
            DirectedGraph<int> directedGraph = new DirectedGraph<int>();
            directedGraph.AddVertex(1);
            directedGraph.AddVertex(2);
            directedGraph.AddVertex(3);

            directedGraph.AddEdge(1, 2); 
            directedGraph.AddEdge(2, 3); 
            directedGraph.AddEdge(3, 1); 
            directedGraph.AddEdge(1, 3); 
            directedGraph.AddEdge(3, 2);

            DirectedGraphBFS(directedGraph); 
            DirectedGraphDFS(directedGraph); 
        }

        static void DirectedGraphBFS(DirectedGraph<int> graph)
        {
            Console.WriteLine("bfs start");

            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex.ToString());

                foreach (var edge in graph.Neighbors(currentVertex))
                {
                    if (!visited.Contains(edge))
                    {
                        queue.Enqueue(edge);
                        visited.Add(edge);
                    }
                }
            }
        }

        static void DirectedGraphDFS(DirectedGraph<int> graph)
        {

            Console.WriteLine("dfs start");

            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(1); 
            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();
                Console.WriteLine(currentVertex.ToString());

                if (!visited.Contains(currentVertex))
                {
                    visited.Add(currentVertex);

                    foreach (var edge in graph.Neighbors(currentVertex))
                    {
                        if (!visited.Contains(edge))
                        {
                            stack.Push(edge);
                        }
                    }
                }
            }
        }


        static void TestIsCycleUnionFind()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 1);

            bool isCycle = IsCycleUnionFind(graph);
            Console.WriteLine("Is Cycle: {0}", isCycle);

            graph.AddEdge(0, 2, 1);

            isCycle = IsCycleUnionFind(graph);
            Console.WriteLine("Is Cycle: {0}", isCycle);

        }

        static bool IsCycleUnionFind(Graph<int> graph)
        {
            UisjointSet uisjointSet = new UisjointSet(graph.VerticesCount);

            foreach (var item in graph.Edges)
            {
                int source = item.Source;
                int destination = item.Destination;

                Console.WriteLine("source: {0}, destination: {1}", source, destination);

                //source = uisjointSet.FindWithoutPathCompression(source);
                //destination = uisjointSet.FindWithoutPathCompression(destination);

                source = uisjointSet.FindWithPathCompression(source);
                destination = uisjointSet.FindWithPathCompression(destination);

                Console.WriteLine("parent[]: {0}", uisjointSet.ToString());
                Console.WriteLine("source parent: {0}, destination parenet: {1}", source, destination); 
                if (source == destination)
                {
                    // 같으면 루프
                    return true; 
                }
                else
                {
                    Console.WriteLine("union {0}, {1}", source, destination); 
                    //uisjointSet.Union(source, destination);
                    uisjointSet.UnionByRank(source, destination);
                    Console.WriteLine("parent[]: {0}", uisjointSet.ToString());
                }
            }

            return false; 
        }

        static void TestIsCycleDFS()
        {
            Graph<int> graph = new Graph<int>();
            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 1);
            bool isCycle = IsCycleDFS(graph);
            Console.WriteLine("Is Cycle: {0}", isCycle);
            graph.AddEdge(0, 2, 1);
            isCycle = IsCycleDFS(graph);
            Console.WriteLine("Is Cycle: {0}", isCycle);
        }

        static bool IsCycleDFS<T>(Graph<T> graph)
        {
            HashSet<T> visited = new HashSet<T>();
            Console.WriteLine("Is Cycle ?");

            foreach (var vertex in graph.Vertexs)
            {
                Console.WriteLine("vertex: {0}", vertex);
                if (RecursionIsCycleDFS(graph, vertex, null, ref visited))
                {
                    return true; 
                }
            }

            return false;
        }

        static bool RecursionIsCycleDFS<T>(Graph<T> graph, T vertex, object parent, ref HashSet<T> visited)
        {
            if (!visited.Contains(vertex))
            {
                Console.WriteLine("vertex {0} is not visited", vertex);
                visited.Add(vertex);
                Console.WriteLine("vertex visited check");

                foreach (var neighbor in graph.Neighbors(vertex))
                {
                    Console.WriteLine("neighbor: {0}", neighbor);
                    if (!visited.Contains(neighbor))
                    {
                        Console.WriteLine("neighbor is not visited");
                        Console.WriteLine("recursion call {0}, {1}", neighbor, vertex);
                        if (RecursionIsCycleDFS(graph, neighbor, vertex, ref visited))
                        {
                            Console.WriteLine("recursion {0}, {1} return true", neighbor, vertex);
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("neighbor is visited");
                        if (parent != null && !neighbor.Equals((T)parent))
                        {
                            Console.WriteLine("neighbor: {0}, parent: {1} is not equals : return true", neighbor, parent);
                            return true;
                        }
                        Console.WriteLine("neighbor: {0}, parent: {1} is equals ... next", neighbor, parent);
                    }
                }
            }
            else
            {
                Console.WriteLine("vertex {0} is visited", vertex);
            }

            Console.WriteLine("recursion {0}, {1} return false", vertex, parent);
            return false; 
        }

        static void test1()
        {
            Graph<City> graph = new Graph<City>();
            City 인천 = new City("인천", new Location(372722, 1264219));
            graph.AddVertex(인천);
            City 서울 = new City("서울", new Location(123456, 7584965));
            graph.AddVertex(서울);
            City 광명 = new City("광명", new Location(546654, 2315482));
            graph.AddVertex(광명);
            City 부천 = new City("부천", new Location(123563, 6568285));
            graph.AddVertex(부천);
            City 부산 = new City("부산", new Location(958213, 9873512));
            graph.AddVertex(부산);

            graph.AddEdge(인천, 서울, 2);
            graph.AddEdge(인천, 광명, 1);
            graph.AddEdge(인천, 부산, 8);
            graph.AddEdge(인천, 부천, 1);
            graph.AddEdge(서울, 인천, 2);
            graph.AddEdge(서울, 부산, 7);
            graph.AddEdge(서울, 광명, 1);
            graph.AddEdge(서울, 부천, 1);
            graph.AddEdge(광명, 부산, 6);
            graph.AddEdge(광명, 부천, 1);
        }

    }

    public class City
    {
        public string Name { get; set; }
        public Location Location { get; set; }

        public City(string name, Location location)
        {
            Name = name;
            Location = location; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1}", Name, Location);

            return builder.ToString();
        }
    }

    public class Location
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Location(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1}", Latitude, Longitude);

            return builder.ToString();
        }
    }

}
