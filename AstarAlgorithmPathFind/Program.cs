using System;
using System.Collections.Generic;

namespace AstarAlgorithmPathFind
{
    class Program
    {
        static int[,] map = new int[,] {
                { 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0}
            };

        static void Main(string[] args)
        {
            

            Node startTile = new Node() { Row = 2, Col = 1 };
            Node endTile = new Node() { Row = 2, Col = 5 };

            List<(Node node, int F, int G, int H)> openList = new List<(Node, int, int, int)>(); 
            List<Node> closeList = new List<Node>();

            openList.Add((startTile, 0, 0, 0)); 


            while (openList.Count > 0)
            {
                var tile = openList[0];

                Console.WriteLine("select tile: [{0}, {1}], F: {2}, G: {3}, H: {4}", tile.node.Row, tile.node.Col, tile.F, tile.G, tile.H);


                if (tile.node.Equals(endTile))
                {
                    MarkPath(tile.node); 
                    break; 
                }

                openList.Remove(tile);
                closeList.Add(tile.node);

                List<Node> tiles = Neighbors(tile.node);

                foreach (Node item in tiles)
                {
                    
                    if (closeList.Contains(item))
                    {
                        continue; 
                    }

                    Console.WriteLine("tile: [{0}, {1}]", item.Row, item.Col);

                    int itemsF;
                    int itemsG;
                    int itemsH;

                    itemsH = (Math.Abs(endTile.Row - item.Row) + Math.Abs(endTile.Col - item.Col)) * 10;
                    
                    if (Math.Abs(tile.node.Row - item.Row) + Math.Abs(tile.node.Col - item.Col) == 1)
                    {
                        itemsG = tile.G + 10;
                    }
                    else
                    {
                        itemsG = tile.G + 14;
                    }

                    itemsF = itemsG + itemsH;


                    var openListItem = openList.Find(x => x.node == item);
                    if (openListItem.node != null)
                    {
                        if (openListItem.G > itemsG)
                        {
                            openListItem.node.Parent = tile.node;
                            openListItem.G = itemsG;
                            openListItem.H = itemsH;
                            openListItem.F = itemsF; 
                        }
                    }
                    else
                    {
                        item.Parent = tile.node; 
                        openList.Add((item, itemsF, itemsG, itemsH)); 
                    }
                }

                openList.Sort((x, y) => x.F.CompareTo(y.F));

            }

            PrintMap(); 
        }

        static void MarkPath(Node node)
        {
            map[node.Row, node.Col] = 2;

            if (node.Parent == null)
            {
                return; 
            }

            MarkPath(node.Parent);
        }

        static void PrintMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(" {0} ", map[i, j]);
                }

                Console.WriteLine("");
            }
        }

        static List<Node> Neighbors(Node tile)
        {
            int[,] adjacencyMap =
            {
                { -1, -1 }, { -1, 0 }, { -1, 1 },
                {  0, -1 }, {  0, 1 },
                {  1, -1 }, {  1, 0 }, {  1, 1 },
            };

            List<Node> tiles = new List<Node>(); 

            int row = 0;
            int col = 0;

            for (int i = 0; i < adjacencyMap.GetLength(0); i++)
            {
                row = tile.Row + adjacencyMap[i, 0];
                col = tile.Col + adjacencyMap[i, 1];

                if (row >= 0 && row < map.GetLength(0) && col >= 0 && col < map.GetLength(1))
                {
                    if (map[row, col] == 0)
                    {
                        tiles.Add(new Node() { Row = row, Col = col }); 
                    }
                }
            }

            return tiles; 
        }
    }

    public class Node
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public Node Parent { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Node);
        }

        public bool Equals(Node other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Row == other.Row && this.Col == other.Col)
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
