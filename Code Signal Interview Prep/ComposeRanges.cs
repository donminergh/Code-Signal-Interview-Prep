using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class ComposeRanges
    {
        string[] composeRanges(int[] nums)
        {
            List<string> res = new List<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                int start = nums[i];
                while (i + 1 < nums.Length && nums[i] + 1 == nums[i + 1])
                {
                    i++;
                }
                int end = nums[i];
                res.Add(start != end ? start + "->" + end : "" + start);
            }

            return res.ToArray();
        }
    }
}
