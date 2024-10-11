using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class TextJustification
    {
        string[] textJustification(string[] words, int maxWidth)
        {
            var ans = new List<string>();
            int i = 0;
            while (i < words.Length)
            {
                var currentLine = GetWords(i, words, maxWidth);
                i += currentLine.Count;
                ans.Add(CreateLine(currentLine, i, words, maxWidth));
            }

            return ans.ToArray();
        }

        private List<string> GetWords(int i, string[] words, int maxWidth)
        {
            var currentLine = new List<string>();
            int currLength = 0;
            while (i < words.Length && currLength + words[i].Length <= maxWidth)
            {
                currentLine.Add(words[i]);
                currLength += words[i].Length + 1;
                i++;
            }

            return currentLine;
        }

        private string CreateLine(List<string> line, int i, string[] words,
                                  int maxWidth)
        {
            int baseLength = -1;
            foreach (var word in line)
            {
                baseLength += word.Length + 1;
            }

            int extraSpaces = maxWidth - baseLength;
            if (line.Count == 1 || i == words.Length)
            {     // if it's the last line
                return string.Join(" ", line) + new string(' ', extraSpaces); // just append extra spaces
            }

            int wordCount = line.Count - 1;
            int spacesPerWord = extraSpaces / wordCount;
            int needsExtraSpace = extraSpaces % wordCount; // remainder after even distribution
            for (int j = 0; j < needsExtraSpace; j++)
            {
                line[j] += " ";
            }

            for (int j = 0; j < wordCount; j++)
            {
                line[j] += new string(' ', spacesPerWord);
            }

            return string.Join(" ", line);
        }



    }
}
