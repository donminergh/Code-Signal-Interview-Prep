using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class RearrangeLastN
    {
        ListNode<int> rearrangeLastN(ListNode<int> l, int n)
        {
            var current = l;
            if (n == 0) return l;
            for (int i = 0; i < n; i++)
            {
                if (current == null) return l;
                current = current.next;
            }
            if (current == null) return l;
            var head = l;

            //At the end of the loop, head will be pointing to the node just before the new head of
            // the rotated list (i.e., the node at position (length - n - 1)).
            while (current.next != null)
            {
                current = current.next;
                head = head.next;
            }
            var result = head.next;
            head.next = null;
            current.next = l;
            return result;
        }

    }
}
