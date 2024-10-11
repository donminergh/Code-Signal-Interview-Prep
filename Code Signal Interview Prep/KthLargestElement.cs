using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class KthLargestElement
    {
        int kthLargestElement(int[] nums, int k)
        {
            // Create a min-heap (priority queue)
            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();

            foreach (int num in nums)
            {
                heap.Enqueue(num, num);
                if (heap.Count > k)
                {
                    heap.Dequeue();
                }
            }

            return heap.Peek();
        }
    }
}
