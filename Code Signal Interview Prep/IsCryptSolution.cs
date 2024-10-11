using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class IsCryptSolution
    {
        bool isCryptSolution(string[] crypt, char[][] solution)
        {
            foreach (char[] arr in solution)
            {
                //Replace letters with their corresponding numbers
                for (int i = 0; i < crypt.Length; i++)
                {
                    crypt[i] = crypt[i].Replace(arr[0], arr[1]);
                }
            }

            //No number should start with a 0
            for (int i = 0; i < crypt.Length; i++)
            {
                if (crypt[i] != "0" && crypt[i].StartsWith("0"))
                    return false;
            }

            //Check if equation works. i.e LHS = RHS
            return long.Parse(crypt[0]) + long.Parse(crypt[1]) == long.Parse(crypt[2]);

        }

    }
}
