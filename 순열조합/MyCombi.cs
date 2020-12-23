using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace 순열조합
{
    public class MyCombi
    {
        private string[] _data;
        private bool[] _selectedIndex;
        public MyCombi(string[] data)
        {
            _data = data;
            _selectedIndex = new bool[_data.Length];
        }

        public ArrayList Combination(int n, int r)
        {
            ArrayList arrayList = new ArrayList();
            
            if (r == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    _selectedIndex[i] = true;
                    arrayList.Add(SelectedIndexToMapping((bool[])_selectedIndex.Clone()));
                    _selectedIndex[i] = false;
                }

                return arrayList;
            }

            if (n == r)
            {
                for (int i = 0; i < n; i++)
                {
                    _selectedIndex[i] = true;
                }

                arrayList.Add(SelectedIndexToMapping((bool[])_selectedIndex.Clone()));

                for (int i = 0; i < n; i++)
                {
                    _selectedIndex[i] = false;
                }

                return arrayList;
            }

            ArrayList temp;

            _selectedIndex[n - 1] = true;
            temp = Combination(n - 1, r - 1);
            arrayList.AddRange(temp);

            _selectedIndex[n - 1] = false;
            temp = Combination(n - 1, r);
            arrayList.AddRange(temp);

            return arrayList;
        }

        private string SelectedIndexToMapping(bool[] selectedIndex)
        {
            string result = "{ ";
            for (int i = 0; i < selectedIndex.Length; i++)
            {
                if (selectedIndex[i] == true)
                {
                    result += _data[i] + " ";
                }
            }
            result += "}";

            return result; 
        }
    }
}
