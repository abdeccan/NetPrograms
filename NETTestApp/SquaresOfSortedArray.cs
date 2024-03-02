using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class SquaresOfSortedArray
    {
        public static void Test()
        {
            int[] nums = new int[] { -4, -1, 0, 3, 10 };
            SquaresOfSortedArray sq = new SquaresOfSortedArray();
            int[] result =  sq.SortedSquares(nums);
            foreach (var i in result)
                Console.WriteLine(i);
        }
         public int[] SortedSquares(int[] nums)
        {
            int size = nums.Length;


            int left = 0, right = size - 1;
            int[] result = new int[size];
            for (int idx = size - 1; idx >= 0; idx--)
            {
                if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                {
                    result[idx] = nums[right] * nums[right];
                    right--;
                }
                else
                {
                    result[idx] = nums[left] * nums[left];
                    left++;
                }
            }
            return result;
        }
    }
}
