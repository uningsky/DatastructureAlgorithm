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
        private List<Board> _nodes = null;  
        
        public Board(int[,] tiles, int dimension)
        {
            this._tiles = tiles;
            this._dimension = dimension; 
        }

        public List<Board> Neighbors()
        {
            List<Board> board = new List<Board>(); 

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
            if (zeroTileYIndex > 0)
            {
                
                var zeroMoveUpBoard = new Board((int[,])_tiles.Clone(), _dimension);
                zeroMoveUpBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex, zeroTileYIndex - 1);
                board.Add(zeroMoveUpBoard); 
            }

            // 오른족
            if (zeroTileXIndex < _dimension - 1)
            {
                var zeroMoveRightBoard = new Board((int[,])_tiles.Clone(), _dimension);
                zeroMoveRightBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex + 1, zeroTileYIndex);
                board.Add(zeroMoveRightBoard);
            }

            // 왼쪽
            if (zeroTileXIndex > 0)
            {
                var zeroMoveLeftBoard = new Board((int[,])_tiles.Clone(), _dimension);
                zeroMoveLeftBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex - 1, zeroTileYIndex);
                board.Add(zeroMoveLeftBoard);
            }

            // 아래
            if (zeroTileYIndex < _dimension - 1)
            {
                var zeroMoveDownBoard = new Board((int[,])_tiles.Clone(), _dimension);
                zeroMoveDownBoard.TileSwap(zeroTileXIndex, zeroTileYIndex, zeroTileXIndex, zeroTileYIndex + 1);
                board.Add(zeroMoveDownBoard);
            }

            return board; 
        }

        private void TileSwap(int sourceX, int sourceY, int targetX, int targetY)
        {
            int temp = _tiles[sourceX, sourceY];
            _tiles[sourceX, sourceY] = _tiles[targetX, targetY];
            _tiles[targetX, targetY] = temp;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj as Board);
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
