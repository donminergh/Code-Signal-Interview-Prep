using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class RotateImage
    {
        int[][] rotateImage(int[][] a)
        {
            var n = a.Length;

            // Transpose
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    var swap = a[j][i];
                    a[j][i] = a[i][j];
                    a[i][j] = swap;
                }
            }

            // Reverse rows
            for (int i = 0; i < n; i++)
            {
                for (int j1 = 0, j2 = n - 1; j1 < j2; j1++, j2--)
                {
                    var swap = a[i][j1];
                    a[i][j1] = a[i][j2];
                    a[i][j2] = swap;
                }
            }

            return a;
        }
    }
}
