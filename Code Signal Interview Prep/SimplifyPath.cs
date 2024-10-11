using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class SimplifyPath
    {
        string simplifyPath(string path)
        {

            Stack<string> stack = new Stack<string>();
            string[] components = path.Split('/');

            foreach (string component in components)
            {
                if (component == "" || component == ".")
                {
                    continue;
                }
                else if (component == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(component);
                }
            }

            List<string> result = new List<string>(stack);
            result.Reverse();
            return "/" + string.Join("/", result);
        }

    }
}
