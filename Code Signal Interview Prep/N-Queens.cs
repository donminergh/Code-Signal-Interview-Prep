using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class N_Queens
    {
        private int size;
        private List<int[]> solutions = new List<int[]>();

        int[][] solution(int n)
        {
            size = n;
            char[][] emptyBoard = new char[size][];
            for (int i = 0; i < n; i++)
            {
                emptyBoard[i] = new char[size];
                for (int j = 0; j < n; j++)
                {
                    emptyBoard[i][j] = '.';
                }
            }

            Backtrack(0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>(), emptyBoard);
            return solutions.ToArray();
        }

        // Making use of a helper function to get the
        // solutions in the correct output format
        private int[] CreateBoard(char[][] state)
        {
            int[] board = new int[state.Length];

            for (int col = 0; col < size; col++)
            {
                for (int row = 0; row < size; row++)
                {
                    if (state[col][row] == 'Q')
                    {
                        board[col] = row + 1;
                    }
                }
            }

            return board;
        }

        private void Backtrack(int row, HashSet<int> diagonals,
                               HashSet<int> antiDiagonals, HashSet<int> cols,
                               char[][] state)
        {
            if (row == size)
            {
                solutions.Add(CreateBoard(state));
                return;
            }

            for (int col = 0; col < size; col++)
            {
                int currDiagonal = row - col;
                int currAntiDiagonal = row + col;

                if (cols.Contains(col) || diagonals.Contains(currDiagonal) ||
                    antiDiagonals.Contains(currAntiDiagonal))
                {
                    continue;
                }

                cols.Add(col);
                diagonals.Add(currDiagonal);
                antiDiagonals.Add(currAntiDiagonal);
                state[row][col] = 'Q';

                Backtrack(row + 1, diagonals, antiDiagonals, cols, state);

                cols.Remove(col);
                diagonals.Remove(currDiagonal);
                antiDiagonals.Remove(currAntiDiagonal);
                state[row][col] = '.';
            }
        }

    }
}
