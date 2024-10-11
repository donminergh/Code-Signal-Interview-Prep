using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class DeleteFromBST
    {
        Tree<int> DeletefromBST(Tree<int> t, int[] queries)
        {
            foreach (int query in queries)
            {
                t = DeleteNode(t, query);
            }
            return t;
        }

        Tree<int> DeleteNode(Tree<int> root, int key)
        {
            if (root == null) return null;

            if (key > root.value)
            {
                root.right = DeleteNode(root.right, key);
            }
            else if (key < root.value)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;

                // Find the min from the right subtree
                Tree<int> cur = root.right;
                while (cur.left != null)
                {
                    cur = cur.left;
                }
                root.value = cur.value;
                root.right = DeleteNode(root.right, cur.value);
            }

            return root;
        }

    }
}
