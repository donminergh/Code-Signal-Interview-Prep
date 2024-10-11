using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class ClimbingStairCase
    {

        int[][] climbingStaircase(int n, int k)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> path = new List<int>();
            Backtrack(n, k, 0, path, result);
            return result.Select(x => x.ToArray()).ToArray();
        }

        void Backtrack(int n, int k, int currentSum, List<int> path, List<IList<int>> result)
        {
            if (currentSum == n)
            {
                result.Add(new List<int>(path));
                return;
            }
            if (currentSum > n)
            {
                return;
            }
            for (int step = 1; step <= k; step++)
            {
                path.Add(step);
                Backtrack(n, k, currentSum + step, path, result);
                path.RemoveAt(path.Count - 1);
            }
        }

    }
}
