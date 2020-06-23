using System;
using System.Collections.Generic;
using System.Text;

namespace Program
{
    class Array
    {
        List<char> list = new List<char>();

        public Array(string _str)
        {
            for(int i = 0; i < _str.Length; i++)
            {
                list.Add(_str[i]);
            }
        }

        public Array(string _str, Array _U)
        {
            for (int i = 0; i < _U.list.Count; i++)
            {
                list.Add('-');
                for(int j = 0; j < _str.Length; j++)
                {
                    if(_U.list[i] == _str[j])
                    {
                        list[i] = _str[j];
                        break;
                    }
                }
            }
        }

        public Array()
        {

        }

        public Array Addiction(Array array1, Array array2, Array _U)
        {
            Array result = new Array();
            for(int i = 0; i < array1.list.Count; i++)
            {
                if (array1.list[i] != '-' || array2.list[i] != '-')
                    result.list.Add(_U.list[i]);
                else
                    result.list.Add('-');
            }

            return result;
        }

        public Array Multiplication(Array array1, Array array2, Array U)
        {
            Array result = new Array();
            for (int i = 0; i < array1.list.Count; i++)
            {
                if (array1.list[i] != '-' && array2.list[i] != '-')
                    result.list.Add(U.list[i]);
                else
                    result.list.Add('-');
            }

            return result;
        }

        public Array Negation(Array array, Array U)
        {
            Array result = new Array();
            for (int i = 0; i < array.list.Count; i++)
            {
                if (array.list[i] == '-')
                    result.list.Add(U.list[i]);
                else
                    result.list.Add('-');
            }
            return result;
        }

        public Array Substraction(Array array1, Array array2, Array U)
        {
            Array result = new Array();
            for (int i = 0; i < array1.list.Count; i++)
            {
                if (array1.list[i] != '-')
                {
                    if (array1.list[i] != array2.list[i])
                        result.list.Add(array1.list[i]);
                    else
                        result.list.Add('-');
                }
                else
                    result.list.Add('-');
            }

            return result;
        }

        public string PrintArray()
        {
            string res = "";

            foreach(char i in list)
            {
                res += i;
            }

            return res;
        }
    }
}
