using System;
using System.Collections.Generic;

namespace 연결리스트
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddLast(i);
            }

            LinkedListNode<int> node = linkedList.First;

            while (node != null)
            {
                Console.WriteLine("node: {0}", node.Value);
                node = node.Next;
            }

            Console.WriteLine("end");
        }
    }
}
