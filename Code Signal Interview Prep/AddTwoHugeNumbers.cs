using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class AddTwoHugeNumbers
    {
        ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b)
        {
            Stack<int> sa = new Stack<int>();
            Stack<int> sb = new Stack<int>();

            // Push values of list 'a' to stack 'sa'
            for (ListNode<int> n = a; n != null; n = n.next)
            {
                sa.Push(n.value);
            }

            // Push values of list 'b' to stack 'sb'
            for (ListNode<int> n = b; n != null; n = n.next)
            {
                sb.Push(n.value);
            }

            ListNode<int> result = null;
            int carry = 0;

            // Calculate sum while there are elements in either stack or carry is non-zero
            while (sa.Count > 0 || sb.Count > 0 || carry > 0)
            {
                int sum = (sa.Count == 0 ? 0 : sa.Pop()) + (sb.Count == 0 ? 0 : sb.Pop()) + carry;
                ListNode<int> node = new ListNode<int>();
                node.value = sum % 10000;
                node.next = result;
                result = node;
                carry = sum / 10000;
            }

            return result;
        }

    }
}
