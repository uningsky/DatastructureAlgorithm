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
            CallMyPermutation();

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
    }

}
