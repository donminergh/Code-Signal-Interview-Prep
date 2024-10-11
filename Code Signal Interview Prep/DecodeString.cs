using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class DecodeString
    {
        string decodeString(string s)
        {
            Stack<int> intStack = new Stack<int>();
            Stack<string> strStack = new Stack<string>();
            string curr = "";
            int k = 0;

            foreach (char ch in s)
            {
                if (char.IsDigit(ch))
                {
                    k = k * 10 + (ch - '0');
                }
                else if (ch == '[')
                {
                    intStack.Push(k);
                    strStack.Push(curr);
                    curr = "";
                    k = 0;
                }
                else if (ch == ']')
                {
                    string tmp = curr;
                    curr = strStack.Pop();
                    int repeatCount = intStack.Pop();
                    for (int i = 0; i < repeatCount; i++)
                    {
                        curr += tmp;
                    }
                }
                else
                {
                    curr += ch;
                }
            }
            return curr;
        }

    }
}
