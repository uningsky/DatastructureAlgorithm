using System;
using System.Collections.Generic;
using System.Linq;

namespace 소수만들기
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = 9999999;

            int[] nums = new int[maxNum];

            for (int i = 2; i < maxNum; i++)
            {
                nums[i] = i; 
            }

            for (int i = 2; i < maxNum; i++)
            {
                if (nums[i] == 0) continue;

                for (int j = i + i; j < maxNum; j += i)
                {
                    nums[j] = 0;
                }
            }
            
            int count = 0;

            //List<int> primeNumbers = new List<int>(); 
            foreach (var item in nums)
            {
                if (item != 0)
                {
                    count++;
                    //primeNumbers.Add(item); 
                }
            }

            Console.WriteLine(count);
        }
    }
}
