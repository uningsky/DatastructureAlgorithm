using System;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    public class MyPermutation
    {
        private readonly long[] _data;
        private readonly long n;

        public MyPermutation(long n)
        {
            if (n < 2)
            {
                throw new Exception("n 이 너무 작습니다. ");
            }

            this.n = n;

            _data = new long[n];
            for (long i = 0; i < n; i++)
            {
                _data[i] = i;
            }
        }

        public MyPermutation NextPermutation()
        {
            MyPermutation permutation = new MyPermutation(n);

            for (long i = 0; i < _data.Length; i++)
            {
                permutation._data[i] = _data[i];
            }

            long left, right;

            // 스왑 할 left 인덱스를 찾는다. 
            // left = n - 2 부터 시작해서 오른쪽에 있는 값과 비교
            // left 인덱스의 값이 left + 1 인덱스의 값보다 크다면 
            // left 를 -1 하여 왼쪽 인덱스를 기준으로 비교한다. 
            left = n - 2; 
            while ((permutation._data[left] > permutation._data[left + 1]) && (left >= 1))
            {
                --left;
            }

            // 0번째 인덱스를 바꿔주어야 하는 경우
            // 1번째 인덱스에는 0번째 인덱스의 값을 제외한 나머지 가장 큰 값이 들어있게 된다. 
            // 0번째 인덱스에 가장 큰 값이 가장 큰 값이라면 
            // 순열을 모두 구한것이므로 null 리턴
            if (left == 0 && permutation._data[left] > permutation._data[left + 1])
            {
                return null; 
            }

            // 스왑 할 right 인덱스를 찾는다. 
            // right = n - 1 부터 
            // left 값이 right 값보다 크다면 right - 1 하여 다음 왼쪽 인덱스의 값을 비교한다. 
            right = n - 1;
            while (permutation._data[left] > permutation._data[right])
            {
                right--;
            }

            // left 와 right 를 스왑해준다. 
            long temp = permutation._data[left];
            permutation._data[left] = permutation._data[right];
            permutation._data[right] = temp;

            // left + 1 부터 나머지는 reverse 해준다. 
            long start = left + 1;
            long end = n - 1;
            while(start < end)
            {
                temp = permutation._data[start];
                permutation._data[start++] = permutation._data[end];
                permutation._data[end--] = temp;
            }

            return permutation; 
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            sb.AppendJoin(", ", _data);
            sb.Append(" }");
            return sb.ToString();
        }

        public string[] ApplyTo(string[] source)
        {
            if (source.Length != n)
            {
                throw new Exception("source의 크기가 n 과 다릅니다. ");
            }

            string[] result = new string[n];
            for (long i = 0; i < n; i++)
            {
                result[i] = source[_data[i]];
            }

            return result;
        }

    }
}
