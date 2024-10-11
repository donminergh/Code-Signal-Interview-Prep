using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{

    public class swapLexOrder
    {
        private const int N = 100001;
        private bool[] visited = new bool[N];
        private List<int>[] adj = new List<int>[N];

        void DFS(string s, int vertex, List<char> characters, List<int> indices)
        {
            // Add the character and index to the list
            characters.Add(s[vertex]);
            indices.Add(vertex);

            visited[vertex] = true;

            // Traverse the adjacents
            foreach (int adjacent in adj[vertex])
            {
                if (!visited[adjacent])
                {
                    DFS(s, adjacent, characters, indices);
                }
            }
        }

        string solution(string s, int[][] pairs)
        {
            for (int i = 0; i < s.Length; i++)
            {
                adj[i] = new List<int>();
            }

            // Build the adjacency list
            foreach (int[] edge in pairs)
            {
                int source = edge[0] - 1;
                int destination = edge[1] - 1;

                // Undirected edge
                adj[source].Add(destination);
                adj[destination].Add(source);
            }

            char[] answer = new char[s.Length];
            for (int vertex = 0; vertex < s.Length; vertex++)
            {
                // If not covered in the DFS yet
                if (!visited[vertex])
                {
                    List<char> characters = new List<char>();
                    List<int> indices = new List<int>();

                    //visit all items in disjoint set and build characters and indices
                    DFS(s, vertex, characters, indices);
                    // Sort the list of characters and indices
                    characters = characters.OrderByDescending(x => x).ToList();
                    indices.Sort();


                    // Store the sorted characters corresponding to the index
                    for (int index = 0; index < characters.Count; index++)
                    {
                        answer[indices[index]] = characters[index];
                    }
                }
            }

            return new string(answer);
        }
    }

}
