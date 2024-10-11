using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class Sumsubsets
    {
        int[][] sumSubsets(int[] candidates, int target)
        {

            List<IList<int>> results = new List<IList<int>>();
            this.backtrack(target, new List<int>(), candidates, 0, results);
            return results.Select(x => x.ToArray()).ToArray();
        }

        private void backtrack(int remain, List<int> comb, int[] candidates,
                               int start, List<IList<int>> results)
        {
            if (remain == 0)
            {
                results.Add(new List<int>(comb));
                return;
            }
            else if (remain < 0)
            {
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (i > start && candidates[i] == candidates[i - 1]) continue;

                comb.Add(candidates[i]);
                this.backtrack(remain - candidates[i], comb, candidates, i + 1,
                               results);
                comb.RemoveAt(comb.Count - 1);
            }
        }


    }
}
