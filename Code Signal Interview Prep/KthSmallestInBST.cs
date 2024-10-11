using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class KthSmallestInBST
    {
        int kthSmallestInBST(Tree<int> root, int k)
        {
            Stack<Tree<int>> stack = new Stack<Tree<int>>();

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (--k == 0) return root.value;
                root = root.right;
            }

            return -1; // Handle the case where k is greater than the number of nodes

        }
    }
}
