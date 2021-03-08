using System;
using System.Collections.Generic;
using System.Text;

namespace 우선순위큐
{
    // binary max heap 
    public class BinaryMaxHeap
    {
        List<int> _data = new List<int>(); 

        public int this[int index]
        {
            get
            {
                return _data[index]; 
            }
            set
            {
                _data[index] = value; 

                int parentIndex = (index - 1) / 2;
                if (index != 0 && _data[index].CompareTo(_data[parentIndex]) > 0)
                {
                    BubbleUp(index); 
                }
                else
                {
                    MaxHeapify(index, _data.Count - 1);
                }
            }
        }

        public int Count
        {
            get
            {
                return _data.Count; 
            }
        }

        public void Add(int n)
        {
            _data.Add(n);
            BubbleUp(_data.Count - 1); 
        }

        public int ExtractMax()
        {
            int max = _data[0];

            int lastIndex = _data.Count - 1;

            Swap(0, lastIndex);
            _data.RemoveAt(lastIndex);
            
            MaxHeapify(0, --lastIndex);

            return max; 
        }

        private void BubbleUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && _data[index].CompareTo(_data[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int indexX, int indexY)
        {
            int temp = _data[indexX]; 
            _data[indexX] = _data[indexY];
            _data[indexY] = temp; 
        }

        private void MaxHeapify(int index, int lastIndex)
        {
            int left = (index * 2) + 1;
            int right = left + 1;
            int largeIndex = index;

            if (left <= lastIndex && _data[index].CompareTo(_data[left]) < 0)
            {
                largeIndex = left; 
            }

            if (right <= lastIndex && _data[largeIndex].CompareTo(_data[right]) < 0)
            {
                largeIndex = right; 
            }

            if (largeIndex != index)
            {
                Swap(index, largeIndex);
                MaxHeapify(largeIndex, lastIndex); 
            }

        }
    }
}
