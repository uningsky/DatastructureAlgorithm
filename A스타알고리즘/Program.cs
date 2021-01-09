using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A스타알고리즘
{
    class Program
    {
        // slider puzzle - 8 - 퍼즐
        static void Main(string[] args)
        {
            // 0 : 빈칸
            Board goalBoard = new Board(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } });
            Board board = Suffle(3);

            // 
            List<(Board board, int moves, int f)> openlist = new List<(Board, int, int)>();
            List<Board> closelist = new List<Board>();
            openlist.Add((board, 0, 0 + board.Manhattan(goalBoard)));

            int moveCount = 0; 

            while (openlist.Count > 0)
            {
                (var currentBoard, int moves, int f) = openlist[0];
                Console.WriteLine("{0} f: ({1}) = moves({2}) + manhattan({3})", currentBoard.ToString(), f, moves, currentBoard.Manhattan(goalBoard));
                
                moveCount = moves; 
                openlist.RemoveAt(0);
                closelist.Add(currentBoard);

                // 현재 보드와 목표 보드가 같은지 비교 , 같으면 완료.
                if (currentBoard.Equals(goalBoard))
                {
                    break;
                }

                foreach (var nextBoard in currentBoard.Neighbors())
                {
                    if (!closelist.Contains(nextBoard))
                    {
                        openlist.Add((nextBoard, moves + 1, moves + 1 + nextBoard.Manhattan(goalBoard)));
                    }
                }

                openlist.Sort((x, y) =>
                {
                    return x.f.CompareTo(y.f);
                });
            }

            Console.WriteLine(moveCount); 
        }

        private static bool IsSolvable(int[,] boardArray)
        {
            int count = 0;
            
            int[] array = new int[boardArray.GetLength(0) * boardArray.GetLength(1)];
            int k = 0;

            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    array[k++] = boardArray[i, j];
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == 0 || array[j] == 0)
                    {
                        continue; 
                    }

                    if (array[i] < array[j])
                    {
                        count++; 
                    }
                }
            }

            if (count % 2 == 0)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        private static Board Suffle(int col)
        {
            int[,] boardArray = SuffleArry(col);

            Board board = new Board(boardArray);

            Console.WriteLine(board.ToString()); 

            return board; 
        }

        private static int[,] SuffleArry(int col)
        {
            int[] number = new int[col * col];
            int[,] boardArray = new int[col, col];

            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }

            var numberList = number.ToList();

            Random random = new Random();

            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    int randomIndex = random.Next(0, numberList.Count - 1);

                    boardArray[i, j] = numberList[randomIndex];

                    numberList.RemoveAt(randomIndex);
                }
            }

            if (IsSolvable(boardArray) == false)
            {
                boardArray = SuffleArry(col);
            }

            return boardArray;
        }
    }
}
