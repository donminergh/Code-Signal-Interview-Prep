using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class MinimumOnStack
    {
        int[] minimumOnStack(string[] operations)
        {
            Stack<int> min = new Stack<int>();
            List<int> result = new List<int>();
            foreach (string op in operations)
            {
                switch (op)
                {
                    case "min":
                        result.Add(min.Count > 0 ? min.Peek() : int.MinValue);
                        break;
                    case "pop":
                        if (min.Count > 0)
                            min.Pop();
                        break;
                    default:
                        int n = int.Parse(op.Replace("push ", ""));
                        int m = min.Count == 0 ? n : Math.Min(min.Peek(), n);
                        min.Push(m);
                        break;
                }
            }
            return result.ToArray();
        }


    }
}
