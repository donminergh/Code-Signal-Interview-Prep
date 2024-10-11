using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class IsSubTree
    {
        //Leetcode: 572. Subtree of Another Tree

        bool isSubtree(Tree<int> t1, Tree<int> t2)
        {
            if (t2 == null) return true;
            if (t1 == null) return false;

            if (t1.value == t2.value && AreEqual(t1, t2)) return true;
            return solution(t1.left, t2) || solution(t1.right, t2); // otherwise if my right or left
        }

        bool AreEqual(Tree<int> t1, Tree<int> t2)
        {
            if (t1 == null || t2 == null) return t1 == t2; //if both are null
            if (t1.value != t2.value) return false; //deal breaker
            return AreEqual(t1.left, t2.left) && AreEqual(t1.right, t2.right); //check if both right and left are equal
        }
    }
}
