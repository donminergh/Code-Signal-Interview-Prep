using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class PaintHouses
    {
        public int paintHouses(int[][] cost)
        {
            int n = cost.Length;
            for (int i = 1; i < n; i++)
            {
                cost[i][0] += Math.Min(cost[i - 1][1], cost[i - 1][2]);
                cost[i][1] += Math.Min(cost[i - 1][0], cost[i - 1][2]);
                cost[i][2] += Math.Min(cost[i - 1][1], cost[i - 1][0]);
            }
            return Math.Min(cost[n - 1][0], Math.Min(cost[n - 1][1], cost[n - 1][2]));
        }

    }
}
