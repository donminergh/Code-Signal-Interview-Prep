using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class HouseRobber
    {
        int houseRobber(int[] nums)
        {

            int max = 0;
            int dp1 = 0;
            int dp2 = 0;


            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(dp2, dp1 + nums[i]);

                dp1 = dp2;
                dp2 = max;
            }

            return max;
        }
    }
}
