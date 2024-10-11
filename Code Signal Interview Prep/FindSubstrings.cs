using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class FindSubstrings
    {
        string[] findSubstrings(string[] words, string[] parts)
        {
            var hash = new HashSet<string>();

            foreach (string part in parts)
            {
                hash.Add(part);
            }

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int len = word.Length;
                for (int j = 5; j > 0; j--)
                {
                    for (int k = 0; k <= len - j; k++)
                    {
                        string sub = word.Substring(k, j);
                        if (hash.Contains(sub))
                        {
                            words[i] = word.Substring(0, k) + "[" + sub + "]" + word.Substring(k + j);
                            j = -1; // Break loop out
                            break;
                        }
                    }
                }
            }
            return words;
        }

    }
}
