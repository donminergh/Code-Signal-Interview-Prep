using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class ReverseNodeInKGroups
    {
        ListNode<int> reverseNodesInKGroups(ListNode<int> l, int k)
        {
            var current = l;
            if (l == null) return l;
            for (int i = 0; i < k - 1; i++)
            {
                current = current.next;
                if (current == null) return l;
            }
            var head = l;
            var prev = reverseNodesInKGroups(current.next, k);

            ListNode<int> next = null;
            for (int i = 0; i < k; i++)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return current;
        }
    }
}
