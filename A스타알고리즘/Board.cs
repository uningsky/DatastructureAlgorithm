using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace A스타알고리즘
{
    public class Board : IEquatable<Board>
    {
        private int[,] _tiles;
        private int _dimension;
        private int _manhattan = -1;
        private List<Board> _nodes = null;  
        public Board Parent { get; private set; }

        public Board(int[,] tiles, Board parent = null)
        {
            if (tiles.Rank != 2)
            {
                throw new ArgumentException("2 dimension 만 지원");
            }

            if (tiles.GetLength(0) != tiles.GetLength(1))
            {
                throw new ArgumentException("같은 수의 열과 행만 지원");
            }

            this._tiles = tiles;
            this._dimension = tiles.GetLength(0);
            Parent = parent;
        }

        public List<Board> Neighbors()
        {
            if (_nodes != null)
            {
                return _nodes; 
            }

            List<Board> nodes = new List<Board>(); 

            int zeroTileXIndex = 0;
            int zeroTileYIndex = 0;
            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    if (_tiles[i, j] == 0)
                    {
                        zeroTileXIndex = i;
                        zeroTileYIndex = j;
                        break;
                    }
                }
            }

            // 위
            if (zeroTileXIndex > 0)
            {
                var zeroMoveUpBoard = new Board((int[,])_tiles.Clone(), this);
                zeroMoveUpBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex - 1, zeroTileYIndex);
                nodes.Add(zeroMoveUpBoard); 
            }

            // 오른족
            if (zeroTileYIndex < _dimension - 1)
            {
                var zeroMoveRightBoard = new Board((int[,])_tiles.Clone(), this);
                zeroMoveRightBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex, zeroTileYIndex + 1);
                nodes.Add(zeroMoveRightBoard);
            }

            // 왼쪽
            if (zeroTileYIndex > 0)
            {
                var zeroMoveLeftBoard = new Board((int[,])_tiles.Clone(), this);
                zeroMoveLeftBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex, zeroTileYIndex - 1);
                nodes.Add(zeroMoveLeftBoard);
            }

            // 아래
            if (zeroTileXIndex < _dimension - 1)
            {
                var zeroMoveDownBoard = new Board((int[,])_tiles.Clone(), this);
                zeroMoveDownBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex + 1, zeroTileYIndex);
                nodes.Add(zeroMoveDownBoard);
            }

            return _nodes = nodes; 
        }

        private void TileSwap(int sourceX, int sourceY, int targetX, int targetY)
        {
            int temp = _tiles[sourceX, sourceY];
            _tiles[sourceX, sourceY] = _tiles[targetX, targetY];
            _tiles[targetX, targetY] = temp;
        }

        public int Manhattan(Board goalBoard)
        {
            if (_dimension != goalBoard._dimension)
                throw new ArgumentException();

            if (_manhattan != -1)
            {
                return _manhattan; 
            }

            int distance = 0;

            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    distance += CalcDistance(goalBoard, i, j);
                }
            }

            return distance; 
        }

        private int CalcDistance(Board goalBoard, int i, int j)
        {
            for (int k = 0; k < goalBoard._tiles.GetLength(0); k++)
            {
                for (int l = 0; l < goalBoard._tiles.GetLength(1); l++)
                {
                    if (_tiles[i, j] == goalBoard._tiles[k, l])
                    {
                        return Math.Abs(i - k) + Math.Abs(j - l);
                    }
                }
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Board);
        }

        public bool Equals(Board other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true; 
            }

            if (_tiles.GetLength(0) != other._tiles.GetLength(0) || _tiles.GetLength(1) != other._tiles.GetLength(1))
            { 
                return false; 
            }

            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    if (_tiles[i, j] != other._tiles[i, j])
                    {
                        return false;
                    }
                }
                
            }

            return true; 
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _tiles.GetLength(0); i++)
            {
                for (int j = 0; j < _tiles.GetLength(1); j++)
                {
                    builder.Append(_tiles[i, j]);
                    builder.Append(" ");
                }
                builder.Append("\n");
            }

            return builder.ToString(); 
        }
    }
}
