using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class MapDecoding
    {
        int mapDecoding(string s)
        {
            return RecursiveWithMemo(0, s) % mod;
        }

        private Dictionary<int, int> memo = new Dictionary<int, int>();
        int mod = 1000000007; // 1e9+7 in C#

        private int RecursiveWithMemo(int index, string s)
        {
            if (memo.ContainsKey(index))
            {
                return memo[index];
            }

            if (index == s.Length)
            {
                return 1;
            }

            if (s[index] == '0')
            {
                return 0;
            }

            if (index == s.Length - 1)
            {
                return 1;
            }

            int ans = RecursiveWithMemo(index + 1, s);
            if (int.Parse(s.Substring(index, 2)) <= 26)
            {
                ans += RecursiveWithMemo(index + 2, s);
            }

            ans %= mod;

            memo[index] = ans;
            return ans;
        }
    }
}
