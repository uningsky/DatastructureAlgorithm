using System;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    // https://jamesmccaffrey.wordpress.com/2009/05/25/generating-all-permutations/

    public class Permutation
    {
        public readonly int n;
        public readonly int[] data;

        public Permutation(int n)
        {
            this.n = n;
            this.data = new int[n];
            for (int i = 0; i < n; ++i)
                data[i] = i;
        }

        public override string ToString()
        {
            string s = "( ";
            for (int i = 0; i < n; ++i)
                s += data[i] + " ";
            s += ")";
            return s;
        }

        public Permutation Successor()
        {
            Permutation result = new Permutation(n);
            int left, right;

            for (int i = 0; i < n; ++i)
                result.data[i] = this.data[i];

            left = result.n - 2;  // Step #1 – Find left value
            while ((result.data[left] > result.data[left + 1]) && (left >= 1))
            {
                --left;
            }

            if ((left == 0) && (this.data[left] > this.data[left + 1]))
                return null;

            right = result.n - 1;  // Step #2 – find right value
            while (result.data[left] > result.data[right])
            {
                --right;
            }

            int temp = result.data[left];  // Step #3 – left and right
            result.data[left] = result.data[right];
            result.data[right] = temp;

            int x = left + 1;              // Step #4 – order the tail
            int y = result.n - 1;
            while (x < y)
            {
                temp = result.data[x];
                result.data[x++] = result.data[y];
                result.data[y--] = temp;
            }
            return result;
        }
    } // Permutation
}
