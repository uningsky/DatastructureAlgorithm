using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = BuildGraph();

            Console.WriteLine("Type-Independent Searches");
            Console.WriteLine("-------------------------");
            Console.WriteLine("Path from 4 to 4: " + Search(4, 4, graph, SearchType.DepthFirst));
            Console.WriteLine("Path from 4 to 0: " + Search(4, 0, graph, SearchType.DepthFirst));
            Console.WriteLine("Path from 4 to 11: " + Search(4, 11, graph, SearchType.DepthFirst));
            Console.WriteLine("Path from 4 to 42: " + Search(4, 42, graph, SearchType.BreadthFirst));
            Console.WriteLine();

            Console.WriteLine("Depth-First Search");
            Console.WriteLine("------------------");
            Console.WriteLine("Path from 4 to 1: " + Search(4, 1, graph, SearchType.DepthFirst));
            Console.WriteLine();

            Console.WriteLine("Breadth-First Search");
            Console.WriteLine("--------------------");
            Console.WriteLine("Path from 4 to 1: " + Search(4, 1, graph, SearchType.BreadthFirst));
            Console.WriteLine();
        }

        static Graph<int> BuildGraph()
        {
            Graph<int> graph = new Graph<int>();

            graph.AddNode(1); 
            graph.AddNode(4); 
            graph.AddNode(5); 
            graph.AddNode(7); 
            graph.AddNode(10); 
            graph.AddNode(11);
            graph.AddNode(12);
            graph.AddNode(42);

            graph.AddEdge(1, 5);
            graph.AddEdge(4, 11);
            graph.AddEdge(4, 42);
            graph.AddEdge(5, 11);
            graph.AddEdge(5, 12);
            graph.AddEdge(5, 42);
            graph.AddEdge(7, 10);
            graph.AddEdge(7, 11);
            graph.AddEdge(10, 11);
            graph.AddEdge(11, 42);
            graph.AddEdge(12, 42);

            return graph; 
        }

        static string Search(int start, int finish, Graph<int> graph, SearchType searchType)
        {
            LinkedList<GraphNode<int>> searchList = new LinkedList<GraphNode<int>>();

            if (start == finish)
            {
                return start.ToString(); 
            }
            else if (graph.Find(start) == null || graph.Find(finish) == null)
            {
                return "";
            }
            else
            {
                GraphNode<int> startNode = graph.Find(start);

                Dictionary<GraphNode<int>, PathNodeInfo<int>> pathNodes = new Dictionary<GraphNode<int>, PathNodeInfo<int>>();
                pathNodes.Add(startNode, new PathNodeInfo<int>(null));
                searchList.AddFirst(startNode);

                while (searchList.Count > 0)
                {
                    GraphNode<int> currentNode = searchList.First.Value;
                    searchList.RemoveFirst();

                    foreach (GraphNode<int> neighbor in currentNode.Neighbors)
                    {
                        if (neighbor.Value == finish)
                        {
                            pathNodes.Add(neighbor, new PathNodeInfo<int>(currentNode));
                            return ConvertPathToString(neighbor, pathNodes); 
                        }
                        else if (pathNodes.ContainsKey(neighbor))
                        {
                            continue; 
                        }
                        else
                        {
                            pathNodes.Add(neighbor, new PathNodeInfo<int>(currentNode));

                            if (searchType == SearchType.DepthFirst)
                            {
                                searchList.AddFirst(neighbor); 
                            }
                            else
                            {
                                searchList.AddLast(neighbor); 
                            }
                            Console.WriteLine("just added " + neighbor.Value + " to search list"); 
                        }
                    }
                }
            }

            return "";
        }

        static string ConvertPathToString(GraphNode<int> endNode, Dictionary<GraphNode<int>, PathNodeInfo<int>> pathNodes)
        {
            LinkedList<GraphNode<int>> path = new LinkedList<GraphNode<int>>();
            path.AddFirst(endNode);
            GraphNode<int> previous = pathNodes[endNode].Previous;
            while (previous != null)
            {
                path.AddFirst(previous);
                previous = pathNodes[previous].Previous; 
            }

            StringBuilder builder = new StringBuilder();
            LinkedListNode<GraphNode<int>> currentNode = path.First;
            int nodeCount = 0;
            while (currentNode != null)
            {
                nodeCount++;
                builder.Append(currentNode.Value.Value);
                if (nodeCount < path.Count)
                {
                    builder.Append(" "); 
                }

                currentNode = currentNode.Next;
            }

            return builder.ToString(); 
        }
    }
}
