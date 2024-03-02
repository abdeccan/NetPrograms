using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class MaxBinaryNum
    {
        public static void Test()
        {
            MaxBinaryNum bin = new();
            string s = bin.MaximumOddBinaryNumber("0110");
            s = bin.MaximumOddBinaryNumber("0101");
        }
        /// <summary>
        /// You are given a binary string s that contains at least one '1'.You have to 
        /// rearrange the bits in such a way that the resulting binary number is the maximum odd binary number that can be created from this combination.
        /// Return a string representing the maximum odd binary number that can be created from the given combination. 
        /// Note that the resulting string can have leading zeros.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MaximumOddBinaryNumber(string s)
        {
            if (string.IsNullOrEmpty(s) || s == "1" || s == "0")
                return s;

            char[] arr = s.ToArray();
            int len = s.Length;
            int one = 0;
            int lastOneIndex = len - 1;
            for (int idx = 0; idx < len; idx++)
            {
                if (arr[idx] == '1')
                {
                    one++;
                }
            }
            if (one == 0)
                return s;

            lastOneIndex = one - 1;
            for (int idx = 0; idx < one; idx++)
            {
                arr[idx] = '1';
            }
            for (int idx = one; idx < len; idx++)
            {
                arr[idx] = '0';
            }

            arr[len - 1] = '1';
            if (one < len)
            {
                arr[lastOneIndex] = '0';
            }

            return new string(arr);
        }
    }
}
