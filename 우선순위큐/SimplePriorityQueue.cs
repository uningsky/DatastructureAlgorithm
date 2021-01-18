using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 우선순위큐
{
    public class SimplePriorityQueue<T> : IEnumerable<T>
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
            _pq.Sort();
        }

        public T Dequeue()
        {
            T item = _pq[0];
            _pq.RemoveAt(0);

            return item;
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
