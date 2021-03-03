using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallPermutation();
            //CallAllPermutation();
            //CallCombination();

            //CallMyCombi();
            //CallMyCombination(); 
            //CallMyPermutation();
            //CallCombinationForLoop();
            CallPermutationForLoop(); 
        }

        static void CallAllPermutation()
        {
            Console.Write("\nEnter permutation order (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("\nAll permutations: \n");
            Permutation p = new Permutation(n);
            while (p != null)
            {
                Console.WriteLine(p.ToString());
                p = p.Successor();
            }
            Console.WriteLine("\nDone");
        }

        static void CallPermutation()
        {
            string[] source = { "0", "1", "2", "3" };
            //string[] source = { "ant", "bat", "cow", "dog" };
            //StringPerm stringPerm = new StringPerm(a);

            for (StringPerm p = new StringPerm(source); p != null; p = p.Successor())
            {
                Console.WriteLine(p.ToString());
            }
        }

        static void CallCombination()
        {
            string[] source = { "0", "1", "2", "3", "4" };
            int n = 5;
            int k = 3;
            List<string> combinations = new List<string>(); 


            Combination c = new Combination(n, k);

            string[] result = new string[k];

            while (c != null)
            {
                result = c.ApplyTo(source);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; ++i)
                {
                    sb.AppendFormat("{0} {1}", result[i], " ");
                }
                combinations.Add(sb.ToString());

                c = c.Successor();
            }

            foreach (var item in combinations)
            {
                Console.WriteLine(item); 
            }
        }

        static void CallMyPermutation()
        {
            int n = 2;

            MyPermutation p = new MyPermutation(n);
            while (p != null)
            {
                Console.WriteLine(p.ToString());
                p = p.NextPermutation();
            }
        }

        static void CallMyCombination()
        {
            string[] source = { "apple", "banana", "orange", "lemon", "pine apple" };
            int n = 5;
            int k = 3;
            List<string> combinations = new List<string>();


            MyCombination c = new MyCombination(n, k);

            string[] result = new string[k];

            while (c != null)
            {
                //combinations.Add(c.ToString());
                result = c.ApplyTo(source);
                Console.WriteLine("{ " + string.Join(", ", result) + " }");

                c = c.NextCombination();
            }

            //foreach (var item in combinations)
            //{
            //    Console.WriteLine(item);
            //}
        }

        static void CallMyCombi()
        {
            string[] source = { "0", "1", "2", "3", "4" };

            MyCombi myCombination1 = new MyCombi(source);

            ArrayList combinations = myCombination1.Combination(5, 3);

            foreach (var item in combinations)
            {
                Console.WriteLine(item);
            }

        }

        static void CallCombinationForLoop()
        {
            string[] source = { "apple", "banana", "orange", "lemon", "pine apple" };
            int n = 5;
            int k = 3;

            // 0 1 2 3 4

            int[] data = new int[k];

            for (int i = 0; i < k; i++)
            {
                data[i] = i; 
            }

            string[] result = new string[k];
            for (int l = 0; l < data.Length; l++)
            {
                result[l] = source[data[l]];
            }
            Console.WriteLine("{0}", string.Join(", ", result));

            while (data[0] != n - k)
            {
                int index;
                for (index = k - 1; index > 0; index--)
                {
                    if (data[index] != n - k + index)
                    {
                        break;
                    }
                }

                data[index]++;

                for (int j = index; j < k - 1; j++)
                {
                    data[j + 1] = data[j] + 1;
                }

                for (int l = 0; l < data.Length; l++)
                {
                    result[l] = source[data[l]];
                }
                Console.WriteLine("{0}", string.Join(", ", result));
            }

        }

        static void CallPermutationForLoop()
        {
            string[] source = { "0", "1", "2", "3" };
            int n = source.Length;

            int[] data = new int[n];

            for (int i = 0; i < n; i++)
            {
                data[i] = i; 
            }

            string[] result = new string[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = source[data[i]];
            }

            Console.WriteLine("{0}", string.Join(", ", result));

            while (true)
            {
                int left = n - 2; 
                
                while (left > 0 && data[left] > data[left + 1])
                {
                    left--; 
                }

                if (left == 0 && data[left] > data[left + 1])
                {
                    break;
                }

                int right = n - 1;

                while (data[left] > data[right])
                {
                    right--;
                }

                int temp = data[left];
                data[left] = data[right];
                data[right] = temp;

                int start = left + 1;
                int end = n - 1; 

                while (start < end)
                {
                    temp = data[start];
                    data[start++] = data[end];
                    data[end--] = temp;
                }

                for (int i = 0; i < n; i++)
                {
                    result[i] = source[data[i]];
                }

                Console.WriteLine("{0}", string.Join(", ", result)); 
            }
        }

    }

}
