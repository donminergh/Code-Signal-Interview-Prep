using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class TraverseTree
    {
        //BFS essentially
        int[] traverseTree(Tree<int> t)
        {
            List<int> result = new List<int>();
            Queue<Tree<int>> nodes = new Queue<Tree<int>>();
            nodes.Enqueue(t);

            // BFS
            while (nodes.Count > 0)
            {
                Tree<int> node = nodes.Dequeue();
                if (node != null)
                {
                    nodes.Enqueue(node.left);
                    nodes.Enqueue(node.right);
                    result.Add(node.value);
                }
            }

            return result.ToArray();

        }

    }
}
