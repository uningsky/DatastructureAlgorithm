using System;

namespace 우선순위큐
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue(); 
            //MaxHeap(); 
        }

        static void MaxHeap()
        {
            BinaryMaxHeap binaryMaxHeap = new BinaryMaxHeap();

            binaryMaxHeap.Add(1);
            binaryMaxHeap.Add(3);
            binaryMaxHeap.Add(4);
            binaryMaxHeap.Add(10);
            binaryMaxHeap.Add(20); 
            binaryMaxHeap.Add(8); 
            binaryMaxHeap.Add(9); 
            binaryMaxHeap.Add(30); 
            binaryMaxHeap.Add(5);

            for (int i = 0; i < binaryMaxHeap.Count; i++)
            {
                Console.WriteLine("{0}", binaryMaxHeap[i]);
            }

            Console.WriteLine("extract max: {0}", binaryMaxHeap.ExtractMax());

            for (int i = 0; i < binaryMaxHeap.Count; i++)
            {
                Console.WriteLine("{0}", binaryMaxHeap[i]);
            }
        }


        static void PriorityQueue()
        {
            SimplePriorityQueue<int> simplePriorityQueue = new SimplePriorityQueue<int>();
            simplePriorityQueue.Enqueue(2);
            simplePriorityQueue.Enqueue(3);
            simplePriorityQueue.Enqueue(4);
            simplePriorityQueue.Enqueue(5);
            simplePriorityQueue.Enqueue(6);
            simplePriorityQueue.Enqueue(9);
            simplePriorityQueue.Enqueue(10);
            simplePriorityQueue.Enqueue(14);

            Console.WriteLine("========= simple PriorityQueue =========");
            Console.WriteLine(string.Join(",", simplePriorityQueue));

            Console.WriteLine("enqueue 1");
            simplePriorityQueue.Enqueue(1);

            Console.WriteLine(string.Join(",", simplePriorityQueue));

            Console.WriteLine("dequeue");
            while (simplePriorityQueue.Count > 0)
            {
                var value = simplePriorityQueue.Dequeue();

                Console.WriteLine("dequeue: {0}, queue: [{1}]", value, string.Join(",", simplePriorityQueue));
            }

            Console.WriteLine("\n");

            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();
            priorityQueue.Enqueue(2);
            priorityQueue.Enqueue(3);
            priorityQueue.Enqueue(4);
            priorityQueue.Enqueue(5);
            priorityQueue.Enqueue(6);
            priorityQueue.Enqueue(9);
            priorityQueue.Enqueue(10);
            priorityQueue.Enqueue(14);

            Console.WriteLine("========= PriorityQueue =========");
            Console.WriteLine(string.Join(",", priorityQueue));

            Console.WriteLine("enqueue 1");
            priorityQueue.Enqueue(1);

            Console.WriteLine(string.Join(",", priorityQueue));

            Console.WriteLine("dequeue");

            while (priorityQueue.Count > 0)
            {
                var value = priorityQueue.Dequeue();

                Console.WriteLine("dequeue: {0}, queue: [{1}]", value, string.Join(",", priorityQueue));
            }
        }
    }
}
