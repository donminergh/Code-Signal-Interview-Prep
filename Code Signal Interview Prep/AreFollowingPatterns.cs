using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class AreFollowingPatterns
    {
        bool areFollowingPatterns(string[] strings, string[] patterns)
        {
            Dictionary<string, string> patternCache = new Dictionary<string, string>();
            Dictionary<string, string> valueCache = new Dictionary<string, string>();

            for (int i = 0; i < patterns.Length; ++i)
            {
                string pattern = patterns[i];
                string value = strings[i];
                if (patternCache.ContainsKey(pattern) && !patternCache[pattern].Equals(value))
                {
                    return false;
                }
                else if (valueCache.ContainsKey(value) && !valueCache[value].Equals(pattern))
                {
                    return false;
                }
                else
                {
                    patternCache[pattern] = value;
                    valueCache[value] = pattern;
                }
            }
            return true;
        }

    }
}
