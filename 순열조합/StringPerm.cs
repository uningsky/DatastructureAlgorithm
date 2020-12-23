using System;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    // https://docs.microsoft.com/en-us/archive/msdn-magazine/2006/december/test-run-string-permutations
    public class StringPerm
    {
        private string[] element;
        private int order;

        // create a StringPerm object which is the 0th (identity) element
        public StringPerm(string[] atoms)
        {
            this.element = new string[atoms.Length];
            atoms.CopyTo(this.element, 0);
            this.order = atoms.Length;
        }

        // create a StringPerm object which is the kth element
        public StringPerm(string[] atoms, int k)
        {
            this.element = new string[atoms.Length];
            this.order = atoms.Length;

            // Step #1 - Find factoradic of k
            int[] factoradic = new int[this.order];

            for (int j = 1; j <= this.order; ++j)
            {
                factoradic[this.order - j] = k % j;
                k /= j;
            }

            // Step #2 - Convert factoradic[] to numeric permuatation in perm[]
            int[] temp = new int[this.order];
            int[] perm = new int[this.order];

            for (int i = 0; i < this.order; ++i)
            {
                temp[i] = ++factoradic[i];
            }

            perm[this.order - 1] = 1;  // right-most value is set to 1.

            for (int i = this.order - 2; i >= 0; --i)
            {
                perm[i] = temp[i];
                for (int j = i + 1; j < this.order; ++j)
                {
                    if (perm[j] >= perm[i])
                        ++perm[j];
                }
            }

            for (int i = 0; i < this.order; ++i)  // put in 0-based form
                --perm[i];

            // Step #3 - map numeric permutation to string permutation
            for (int i = 0; i < this.order; ++i)
                this.element[i] = atoms[perm[i]];

        } // StringPerm(string[] element, int k)

        public static bool isValid(string[] e)
        {
            if (e == null)
                return false;
            if (e.Length < 2)
                return false;
            for (int i = 0; i < e.Length - 1; ++i)
            {
                if (e[i].CompareTo(e[i + 1]) >= 0) // >= means no dups allowed
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            string result = "{ ";
            for (int i = 0; i < this.order; ++i)
                result += this.element[i] + " ";
            result += "}";
            return result;
        }

        public StringPerm Successor() // assumes no duplicate atoms
        {
            StringPerm result = new StringPerm(this.element);
            int left, right;

            left = result.order - 2;  // Step #1 - Find left value 
            while ((result.element[left].CompareTo(result.element[left + 1])) > 0 && (left >= 1))
            {
                --left;
            }
            if ((left == 0) && (this.element[left].CompareTo(this.element[left + 1])) > 0)
                return null;

            right = result.order - 1;  // Step #2 - find right; first value > left
            while (result.element[left].CompareTo(result.element[right]) > 0)
            {
                --right;
            }

            string temp = result.element[left];  // Step #3 - swap [left] and [right]
            result.element[left] = result.element[right];
            result.element[right] = temp;

            int i = left + 1;              // Step #4 - reverse order the tail
            int j = result.order - 1;

            while (i < j)
            {
                temp = result.element[i];
                result.element[i++] = result.element[j];
                result.element[j--] = temp;
            }

            //return result;
            return result;
        } // Successor()

        public static ulong FactorialCompute(int n)
        {
            //if (n < 0 || n > 20)
            //  throw new Exception("Input argument must be between 0 and 20");
            ulong answer = 1;
            for (int i = 1; i <= n; ++i)
            {
                answer = checked(answer * (ulong)i);
            }
            return answer;
        } // FactorialCompute()

        public static ulong FactorialLookup(int n)
        {
            if (n < 0 || n > 20)
                throw new Exception("Input argument must be between 0 and 20");

            ulong[] answers = new ulong[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320,
        362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000,
        20922789888000, 355687428096000, 6402373705728000, 121645100408832000,
        2432902008176640000 };

            return answers[n];
        } // FactorialCompute()

        public static ulong FactorialRecursive(int n)
        {
            //if (n < 0 || n > 20)
            //  throw new Exception("Input argument must be between 0 and 20");

            if (n == 0 || n == 1)
                return 1;
            else
                return (ulong)n * FactorialRecursive(n - 1);
        } // FactorialRecursive()
    }


}
