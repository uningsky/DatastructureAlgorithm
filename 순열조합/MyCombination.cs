using System;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    public class MyCombination
    {
        private readonly long[] _data;
        private readonly long n;
        private readonly long k; 

        public MyCombination(long n, long k)
        {
            if (n < 0 || k < 0)
            {
                throw new Exception("n 또는 k 가 너무 작습니다. "); 
            }

            this.n = n;
            this.k = k;

            _data = new long[n];
            for (long i = 0; i < n; i++)
            {
                _data[i] = i; 
            }
        }

        public MyCombination NextCombination()
        {
            // 예) 
            // n : 5개, 원소는 0 1 2 3 4 
            // k = 3개
            // 나올 수 있는 조합은 아래와 같다. 
            // 0  1  2
            // 0  1  3
            // 0  1  4
            // 0  2  3
            // 0  2  4
            // 0  3  4
            // 1  2  3
            // 1  2  4
            // 1  3  4
            // 2  3  4

            // 위 예와 같이 마지막 조합의 첫번째 인덱스의 값은 n - k 이다. null 리턴.
            if (_data[0] == n - k)
            {
                return null;
            }

            MyCombination combination = new MyCombination(n, k);

            long i;
            for (i = 0; i < k; i++)
            {
                combination._data[i] = this._data[i];
            }

            // 값을 변경 해 줄 인덱스를 찾는다. 오른쪽부터
            // 예) k = 3이므로 인덱스는 0 1 2 가 된다. 
            // i 는 2부터 줄어들며 비교한다.
            for (i = k - 1; i > 0; i--)
            {
                // 해당 인덱스 자리에 올 수 있는 가장 큰 값이면 계속하여 찾아주고 아니면 나간다.
                // 예) 해당 인덱스 자리에 올 수 있는 가장 큰 값은 
                // 인덱스 2 에는 4, 인덱스 1 에는 3
                if (_data[i] != n - k + i)
                {
                    break;
                }
            }

            // 찾은 위치의 값을 증가 시켜준다. 
            combination._data[i]++;

            // 해당 인덱스 부터 마지막 인덱스까지 루프 돌면서 
            // 나머지 배열에 왼쪽 보다 + 1 씩 큰 값을 넣어준다. 
            for (long j = i; j < k - 1; j++)
            {
                combination._data[j + 1] = combination._data[j] + 1;
            }

            return combination;
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

            string[] result = new string[k];
            for (long i = 0; i < k; i++)
            {
                result[i] = source[_data[i]];
            }

            return result; 
        }
    }
}
