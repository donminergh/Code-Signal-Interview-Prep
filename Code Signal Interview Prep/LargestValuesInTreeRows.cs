using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class LargestValuesInTreeRows
    {
        int[] largestValuesInTreeRows(Tree<int> root)
        {
            if (root == null) return Array.Empty<int>();

            List<int> largestValues = new List<int>();
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int rowMax = int.MinValue;
                int rowSize = queue.Count;

                for (int i = 0; i < rowSize; i++)
                {
                    Tree<int> node = queue.Dequeue();
                    rowMax = Math.Max(rowMax, node.value);

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                largestValues.Add(rowMax);
            }

            return largestValues.ToArray();
        }
    }
}
