using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class CombinationSum
    {
        string combinationSum(int[] candidates, int target)
        {
            candidates = candidates.Distinct().ToArray();
            Array.Sort(candidates);

            List<IList<int>> results = new List<IList<int>>();
            this.backtrack(target, new List<int>(), candidates, 0, results);

            string ret = "";
            foreach (var item in results)
            {
                ret += "(" + String.Join(" ", item) + ")";
            }

            if (ret == "") ret = "Empty";
            return ret;
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

            for (int i = start; i < candidates.Length; ++i)
            {
                comb.Add(candidates[i]);
                this.backtrack(remain - candidates[i], comb, candidates, i,
                               results);
                comb.RemoveAt(comb.Count - 1);
            }
        }
    }
}
