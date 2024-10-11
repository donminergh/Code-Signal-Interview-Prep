using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class LongestPath
    {
        int longestPath(string fileSystem)
        {
            int maxLen = 0;
            Dictionary<int, int> pathLen = new Dictionary<int, int> { { 0, 0 } };

            foreach (string line in fileSystem.Split('\f'))
            {
                string name = line.TrimStart('\t');
                int depth = line.Length - name.Length;

                if (name.Contains(".")) //if it's a file
                {
                    maxLen = Math.Max(maxLen, pathLen[depth] + name.Length);
                }
                else
                {
                    pathLen[depth + 1] = pathLen[depth] + name.Length + 1;
                    // + 1 caters for \f that's gone after split
                    // setting the dictionary value forgets past values as whatever max was in the past has been captured
                }
            }

            return maxLen;
        }
    }
}
