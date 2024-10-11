using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class ClimbingStairs
    {
        int climbingStairs(int n)
        {
            if (n <= 2) return n;
            int dp1 = 1;

            int dp2 = 2;
            int sum = 0;

            for (int i = 2; i < n; i++)
            {
                sum = dp1 + dp2;
                dp1 = dp2;
                dp2 = sum;
            }

            return sum;
        }

    }
}
