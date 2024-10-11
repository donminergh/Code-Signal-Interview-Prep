using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class StackOps
    {
        int[] solution(string[] operations)
        {
            var result = new List<int>();
            var stack = new Stack<int>();

            foreach (var op in operations)
            {

                switch (op)
                {
                    case "min":
                        result.Add(stack.Count > 0 ? stack.Peek() : int.MinValue);
                        break;
                    case "pop":
                        if (stack.Count > 0) stack.Pop();
                        break;
                    default:
                        int val = int.Parse(op.Replace("push", ""));
                int min = stack.Count == 0 ? val : Math.Min(val, stack.Peek());
                        stack.Push(min);
                        break;
                }
            }
            return result.ToArray();
        }
    }
}
