using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class IsSymmetric
    {
        bool IsSymmetric(Tree<int> t)
        {
            return Check(t, t);
        }

        bool Check(Tree<int> t1, Tree<int> t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }
            if (t1 == null || t2 == null || t1.value != t2.value)
            {
                return false;
            }
            return Check(t1.left, t2.right) && Check(t1.right, t2.left);
        }

    }
}
