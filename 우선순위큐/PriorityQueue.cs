using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 우선순위큐
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> _pq = new List<T>();

        public int Count
        {
            get
            {
                return _pq.Count;
            }
        }

        public void Enqueue(T item)
        {
            _pq.Add(item);
            BubbleUp(); 
        }

        public T Dequeue()
        {
            T item = _pq[0];

            int lastIndex = _pq.Count - 1;
            _pq[0] = _pq[lastIndex];
            _pq.RemoveAt(lastIndex);

            SyncDown(); 

            return item;
        }

        private void BubbleUp()
        {
            int index = _pq.Count - 1;
            int parentIndex = index / 2;

            while (index > 0 && _pq[index].CompareTo(_pq[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = index / 2;
            }
        }

        private void Swap(int source, int target)
        {
            var temp = _pq[source];
            _pq[source] = _pq[target];
            _pq[target] = temp; 
        }

        private void SyncDown()
        {
            SyncDown(0, _pq.Count - 1); 
        }

        private void SyncDown(int startIndex, int lastIndex)
        {
            int parentIndex = startIndex;

            while (true)
            {
                int leftChildIndex = 2 * parentIndex + 1;
                int rightChildIndex = leftChildIndex + 1;

                if (leftChildIndex > lastIndex)
                {
                    break; 
                }

                int compareTarget;

                if (rightChildIndex <= lastIndex)
                {
                    if (_pq[leftChildIndex].CompareTo(_pq[rightChildIndex]) < 0)
                    {
                        compareTarget = leftChildIndex; 
                    }
                    else
                    {
                        compareTarget = rightChildIndex;
                    }
                }
                else
                {
                    compareTarget = leftChildIndex; 
                }

                if (_pq[parentIndex].CompareTo(_pq[compareTarget]) > 0)
                {
                    Swap(parentIndex, compareTarget);
                    parentIndex = compareTarget;
                }
                else
                {
                    break; 
                }
            }
        }

        public void RebuildHeapify()
        {
            int startIndex = _pq.Count / 2;
            int lastIndex = _pq.Count - 1; 

            for (int i = startIndex; i >= 0; i--)
            {
                SyncDown(startIndex, lastIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _pq.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
