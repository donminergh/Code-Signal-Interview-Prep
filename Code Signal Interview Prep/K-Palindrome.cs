using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class K_Palindrome
    {
        private int?[][] memo;

        bool kpalindrome(string s, int k)
        {
            memo = new int?[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                memo[i] = new int?[s.Length];
            }

            // Return true if the minimum cost to create a palindrome by only deleting the letters
            // is less than or equal to `k`.
            return IsValidPalindrome(s, 0, s.Length - 1) <= k;
        }

        private int? IsValidPalindrome(string s, int i, int j)
        {
            // Base case, only 1 letter remaining.
            if (i == j)
                return 0;

            // Base case 2, only 2 letters remaining.
            if (i == j - 1)
                return s[i] != s[j] ? 1 : 0;

            // Return the precomputed value if exists.
            if (memo[i][j].HasValue)
                return memo[i][j].Value;

            // Case 1: Character at `i` equals character at `j`
            if (s[i] == s[j])
                return memo[i][j] = IsValidPalindrome(s, i + 1, j - 1);

            // Case 2: Character at `i` does not equal character at `j`.
            // Either delete character at `i` or delete character at `j`
            // and try to match the two pointers using recursion.
            // We need to take the minimum of the two results and add 1
            // representing the cost of deletion.
            return memo[i][j] = 1 + Math.Min((int)IsValidPalindrome(s, i + 1, j), (int)IsValidPalindrome(s, i, j - 1));
        }

    }
}
