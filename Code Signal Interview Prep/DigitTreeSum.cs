using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class DigitTreeSum
    {
        long digitTreeSum(Tree<int> root)
        {
            return SumNumbers(root, 0);
        }

        private long SumNumbers(Tree<int> t, long s)
        {
            if (t == null)
                return 0;
            if (t.left == null && t.right == null)
                return 10 * s + t.value;
            return SumNumbers(t.left, 10 * s + t.value) + SumNumbers(t.right, 10 * s + t.value);
        }
    }
}
