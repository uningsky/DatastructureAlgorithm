using System;
using System.Collections.Generic;
using System.Text;

namespace 그래프2
{
    public class UisjointSet
    {
        private int[] _parent;
        private int[] _rank; 

        public UisjointSet(int v)
        {
            _parent = new int[v];
            _rank = new int[v];

            for (int i = 0; i < v; i++)
            {
                _parent[i] = i;
                _rank[i] = 0; 
            }
        }

        public int FindWithoutPathCompression(int i)
        {
            if (_parent[i] == i)
            {
                return i;
            }
            else
            {
                return FindWithoutPathCompression(_parent[i]);
            }
        }

        public int FindWithPathCompression(int i)
        {
            if (_parent[i] == i)
            {
                return i; 
            }
            else
            {
                _parent[i] = FindWithPathCompression(_parent[i]);
                return _parent[i];
            }
        }

        public void Union(int i, int j)
        {
            Console.WriteLine("union {0}, {1}" , i, j); 
            int iRoot = FindWithoutPathCompression(i);
            int jRoot = FindWithoutPathCompression(j);

            Console.WriteLine("iroot: {0}, jroot: {1}", iRoot, jRoot);

            _parent[iRoot] = jRoot; 
            Console.WriteLine("parent[]: {0}", this.ToString());
        }

        public void UnionByRank(int i, int j)
        {
            int iRoot = FindWithPathCompression(i);
            int jRoot = FindWithPathCompression(j);
            int iRank = _rank[iRoot];
            int jRank = _rank[jRoot];

            if (iRank > jRank)
            {
                _parent[jRoot] = iRoot;
            }
            else if (iRank < jRank)
            {
                _parent[iRoot] = jRoot;
            }
            else
            {
                _parent[iRoot] = jRoot;
                _rank[jRoot]++; 
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendJoin(", ", _parent);

            return builder.ToString(); 
        }
    }
}
