using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
   
    internal class TwoSumProblem
    {
        public TwoSumProblem()
        { 
        }

        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length <= 1)
                return null;

            // we  want to store the nums-indices in a map (dicitonary)
            Dictionary<int, int> numToIndex = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
            {
                numToIndex[nums[index]] = index;
            }

            int[] result = new int[2];
            foreach (var kvp in numToIndex)
            {
                if (numToIndex.ContainsKey(target - kvp.Key))
                {
                    result[0] = kvp.Value;
                    result[1] = numToIndex[target - kvp.Key];
                    break;
                }
            }

            return result;
        }

        public static void Test()
        {
            TwoSumProblem obj = new TwoSumProblem();
            int[] input = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] result = obj.TwoSum(input, target);            
        }
    }
}
