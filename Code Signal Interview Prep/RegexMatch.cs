using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class RegexMatch
    {
        private bool?[,] memo;

        bool solution(string text, string pattern)
        {
            memo = new bool?[text.Length + 1, pattern.Length + 1];
            return Dp(0, 0, text, pattern);
        }

        private bool Dp(int i, int j, string text, string pattern)
        {
            if (memo[i, j].HasValue)
            {
                return memo[i, j].Value;
            }
            bool ans;
            if (j == pattern.Length)
            {
                ans = i == text.Length;
            }
            else
            {
                bool firstMatch =
                    (i < text.Length &&
                        (pattern[j] == text[i] ||
                            pattern[j] == '.'));

                if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                {
                    ans = (Dp(i, j + 2, text, pattern) ||
                        (firstMatch && Dp(i + 1, j, text, pattern)));
                }
                else
                {
                    ans = firstMatch && Dp(i + 1, j + 1, text, pattern);
                }
            }
            memo[i, j] = ans;
            return ans;
        }

    }
}
