﻿using System;
using System.Collections.Generic;
using 그래프2;

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


        }
    }
}
