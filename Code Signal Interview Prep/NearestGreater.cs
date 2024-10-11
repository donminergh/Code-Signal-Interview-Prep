using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class NearestGreater
    {
        int[] nearestGreater(int[] a)
        {
            int[] res = new int[a.Length];
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < a.Length; i++)
            {
                while (st.Count > 0 && a[st.Peek()] <= a[i])
                {
                    st.Pop();
                }
                res[i] = st.Count == 0 ? -1 : st.Peek();
                st.Push(i);
            }

            st.Clear(); // Clear the stack for re-use

            for (int i = a.Length - 1; i >= 0; i--)
            {
                while (st.Count > 0 && a[st.Peek()] <= a[i])
                {
                    st.Pop();
                }
                if (res[i] == -1 || (i - res[i]) > (st.Count == 0 ? i + 1 : st.Peek() - i))
                {
                    res[i] = st.Count == 0 ? -1 : st.Peek();
                }
                st.Push(i);
            }

            return res;
        }
    }
}
