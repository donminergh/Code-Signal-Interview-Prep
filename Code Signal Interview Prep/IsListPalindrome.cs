using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class IsListPalindrome
    {
        bool isListPalindrome(ListNode<int> l)
        {
            // To solve in O(n) time and O(1) space (the tricky bit), we'll
            // try the following approach: Split the list at the middle,
            // reverse the latter half. Compare the two sub-lists element
            // by element. Reverse the latter half again before returning,
            // in order to leave the original list unchanged.
            if (l == null || l.next == null) return true; // degenerate cases, zero or one elements
            ListNode<int> head = l;     // store original head
            ListNode<int> end = new ListNode<int>();
            ListNode<int> middle = FindMiddle(l);
            ReverseInPlace(ref middle); //reverse the 2nd half of the list in place
            bool result = CompareLists(l, middle);
            ReverseInPlace(ref middle); // leave things as we found them
            return result;
        }


        bool CompareLists(ListNode<int> p1, ListNode<int> p2)
        {
            // Compare elements of p1 and p2 up to the length of the shorter
            // Return false if any elements are different
            while (p1 != null && p2 != null)
            {
                if (p1.value != p2.value) return false;
                p1 = p1.next;
                p2 = p2.next;
            }
            return true;
        }

        void ReverseInPlace(ref ListNode<int> p)
        {
            // Reverse a linked list in place, with head at p
            // Return new head pointing to reversed list
            ListNode<int> rhead = p;
            ListNode<int> fwd = p.next;
            rhead.next = null; // new end of list
            while (fwd != null)     // done when end reached, return last
            {
                // save where the next node currently points, and
                // change it to point to previous node 
                ListNode<int> tmp = fwd.next;
                fwd.next = rhead;
                rhead = fwd;
                fwd = tmp;
            }
            p = rhead;
        }

        ListNode<int> FindMiddle(ListNode<int> l)
        {
            // The idea is to move two pointers along the linked list, one
            // a node at a time, the other 2 nodes at a time. When the "fast"
            // pointer reaches the end of the list, the "slow" pointer will
            // be at the middle.  [Need to consider even and odd list
            // sizes.]
            // For purposes of palindome checking, we want the middle
            // to point to the first node just past the middle, as this
            // denotes the start of the section we'll reverse, and compare
            // to the original, up to the length of the shorter. In lists
            // with an even number (n) of nodes, it will point to 
            // node (n/2) + 1 (one-based). In lists with an odd number of 
            // nodes, it will point to floor(n/2) + 1, or just past the center
            // node. (You don't need to consider the center value in a
            // palindrome with an odd number of elements.)

            ListNode<int> p1 = l;
            ListNode<int> p2 = l;   // start both at the list head
            while (p2.next != null)
            {
                p1 = p1.next;
                p2 = p2.next;
                if (p2.next == null) return p1; //don't go off the end
                p2 = p2.next;   // take another step
            }
            return p1;
        }


    }
}
