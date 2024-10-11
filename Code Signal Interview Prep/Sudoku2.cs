using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class Sudoku2
    {
        bool sudoku2(char[][] grid)
        {


            int n = grid.Length;

            HashSet<string> set = new HashSet<string>();

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (grid[row][col] != '.' && !set.Add(grid[row][col] + " in row " + row))
                        return false;
                    if (grid[row][col] != '.' && !set.Add(grid[row][col] + " in col " + col))
                        return false;
                    if (grid[row][col] != '.' && !set.Add(grid[row][col] + " in square " + row / 3 + " " + col / 3))
                        return false;
                }
            }

            return true;
        }
    }
}
