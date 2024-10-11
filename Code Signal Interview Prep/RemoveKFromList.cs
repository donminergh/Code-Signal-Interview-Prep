using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class RemoveKFromList
    {
        ListNode<int> removeKFromList(ListNode<int> l, int k)
        {
            ListNode<int> sentinel = new ListNode<int>();
            sentinel.value = 0;
            sentinel.next = l;

            ListNode<int> prev = sentinel, curr = l;
            while (curr != null)
            {
                if (curr.value == k)
                    prev.next = curr.next;
                else
                    prev = curr;

                curr = curr.next;
            }
            return sentinel.next;
        }
    }
}
