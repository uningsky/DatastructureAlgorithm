using System;
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
            int[] goalBoard = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            int[] board = Suffle(3);

            // 



        }

        private static void TileSwap(int[] array, int source, int target)
        {
            int temp = array[source];
            array[source] = array[target];
            array[target] = temp; 
        }

        private static int[] Suffle(int col)
        {
            int[] number = new int[col * col];
            int[] puzzlePanel = new int[col * col];

            for (int i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }

            var numberList = number.ToList();

            Random random = new Random();

            for (int i = 0; i < puzzlePanel.Length; i++)
            {
                int randomIndex = random.Next(0, numberList.Count - 1);

                puzzlePanel[i] = numberList[randomIndex];

                numberList.RemoveAt(randomIndex);
            }

            StringBuilder builder = new StringBuilder(); 
            for (int i = 0; i < puzzlePanel.Length; i++)
            {
                builder.Append(puzzlePanel[i]);
                builder.Append(" ");

                if ((i + 1) % col == 0)
                {
                    Console.WriteLine("{0}", builder);
                    builder.Clear(); 
                }
            }

            return puzzlePanel; 
        }
    }
}
