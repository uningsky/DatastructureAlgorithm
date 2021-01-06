using System;

namespace 이분탐색
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] collection = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int findValue = 11; 

            int left;
            int right;
            int mid = 0;

            Array.Sort(collection);

            left = collection[0];
            right = collection[collection.Length - 1];

            while (left <= right)
            {
                mid = (left + right) / 2;

                Console.WriteLine("left: {0}, mid: {1}, right; {2}", left, mid, right);

                if (findValue > mid)
                {
                    left = mid + 1; 
                }
                else if (findValue < mid)
                {
                    right = mid - 1; 
                }
                else
                {
                    break; 
                }
            }

            Console.WriteLine("answer: {0}", mid); 
        }


    }
}
