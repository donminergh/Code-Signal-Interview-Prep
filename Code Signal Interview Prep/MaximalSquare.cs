using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class MaximalSquare
    {
        //Leetcode: 221. Maximal Square
        int maximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
                return 0;

            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int[][] dp = new int[rows][];
            int maxSquareLen = 0;

            // Initialize the first row of dp matrix
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[cols];
                dp[i][0] = matrix[i][0] - '0';
                maxSquareLen = Math.Max(maxSquareLen, dp[i][0]);
            }

            // Initialize the first column of dp matrix
            for (int j = 0; j < cols; j++)
            {
                dp[0][j] = matrix[0][j] - '0';
                maxSquareLen = Math.Max(maxSquareLen, dp[0][j]);
            }

            // Build the dp matrix
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i][j] = Math.Min(dp[i - 1][j - 1], Math.Min(dp[i - 1][j], dp[i][j - 1])) + 1;
                        maxSquareLen = Math.Max(maxSquareLen, dp[i][j]);
                    }
                }
            }

            return maxSquareLen * maxSquareLen;
        }

    }
}
