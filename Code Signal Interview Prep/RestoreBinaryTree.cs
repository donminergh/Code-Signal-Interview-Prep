using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class RestoreBinaryTree
    {
        //Leetcode 105. Construct Binary Tree from Preorder and Inorder Traversal
        Tree<int> restoreBinaryTree(int[] inorder, int[] preorder)
        {
            if (inorder.Length == 0) return null;

            int rootVal = preorder[0];
            int rootIndex = -1;

            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == rootVal)
                {
                    rootIndex = i;
                    break;
                }
            }

            var root = new Tree<int>();
            root.value = rootVal;
            root.left = solution(inorder.Take(rootIndex).ToArray(), preorder.Skip(1).Take(rootIndex).ToArray());
            root.right = solution(inorder.Skip(rootIndex + 1).ToArray(), preorder.Skip(rootIndex + 1).ToArray());

            return root;
        }

    }
}
