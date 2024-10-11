using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class PossibleSums
    {
        int possibleSums(int[] coins, int[] quantity)
        {
            HashSet<int> sums = new HashSet<int>();
            sums.Add(0);

            for (int i = 0; i < coins.Length; i++)
            {
                int coin = coins[i];
                HashSet<int> currentSums = new HashSet<int>();
                foreach (int sum in sums)
                {
                    for (int j = 1; j <= quantity[i]; j++)
                    {
                        currentSums.Add(sum + coin * j);
                    }
                }
                sums.UnionWith(currentSums);
            }

            return sums.Count - 1;
        }
    }
}
