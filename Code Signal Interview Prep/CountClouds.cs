using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class CountClouds
    {
        //(Number of Islands: 200)
        int countClouds(char[][] skyMap)
        {
            int count = 0;
            int rows = skyMap.Length;
            if (rows == 0) return 0;
            int cols = skyMap[0].Length;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (skyMap[r][c] == '1')
                    {
                        Dfs(skyMap, r, c);
                        count++;
                    }
                }
            }
            return count;
        }

        void Dfs(char[][] skyMap, int r, int c)
        {
            if (skyMap[r][c] != '1')
                return;

            skyMap[r][c] = '2';

            if (r > 0)
                Dfs(skyMap, r - 1, c);
            if (r < skyMap.Length - 1)
                Dfs(skyMap, r + 1, c);
            if (c > 0)
                Dfs(skyMap, r, c - 1);
            if (c < skyMap[r].Length - 1)
                Dfs(skyMap, r, c + 1);
        }



    }
}
