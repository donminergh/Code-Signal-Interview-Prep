using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class NextLarger
    {
        int[] nextLarger(int[] a)
        {
            int n = a.Length;
            int[] result = new int[n];

            Stack<int> stack = new Stack<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && a[i] >= stack.Peek())
                {
                    stack.Pop();
                }
                result[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(a[i]);
            }
            return result;
        }

    }
}
