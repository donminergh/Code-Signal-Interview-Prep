using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class WordBoggle
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
            public string Word { get; set; }

            public TrieNode()
            {
            }
        }

        public char[][] _board = null;
        public List<string> _result = new List<string>();

        string[] wordBoggle(char[][] board, string[] words)
        {
            // Step 1). Construct the Trie
            TrieNode root = new TrieNode();
            foreach (var word in words)
            {
                TrieNode node = root;
                foreach (var letter in word)
                {
                    if (!node.Children.ContainsKey(letter))
                    {
                        TrieNode newNode = new TrieNode();
                        node.Children[letter] = newNode;
                        node = newNode;
                    }
                    else
                    {
                        node = node.Children[letter];
                    }
                }
                node.Word = word; // store words in Trie
            }
            _board = board;

            // Step 2). Backtracking starting for each cell in the board
            for (int row = 0; row < board.Length; ++row)
            {
                for (int col = 0; col < board[row].Length; ++col)
                {
                    if (root.Children.ContainsKey(board[row][col]))
                    {
                        Backtracking(row, col, root);
                    }
                }
            }

            _result.Sort();
            return _result.ToArray();
        }

        private void Backtracking(int row, int col, TrieNode parent)
        {
            char letter = _board[row][col];
            TrieNode currNode = parent.Children[letter];

            // check if there is any match
            if (currNode.Word != null)
            {
                _result.Add(currNode.Word);
                currNode.Word = null;
            }

            // mark the current letter before the EXPLORATION
            _board[row][col] = '#';

            // explore neighbor cells in around-clock directions: up, right, down, left
            int[] rowOffset = { -1, 0, 1, 0, 1, -1, 1, -1 };
            int[] colOffset = { 0, 1, 0, -1, 1, -1, -1, 1 };
            for (int i = 0; i < 8; ++i)
            {
                int newRow = row + rowOffset[i];
                int newCol = col + colOffset[i];
                if (                                            //if out of bounds
                    newRow < 0 || newRow >= _board.Length ||
                    newCol < 0 || newCol >= _board[newRow].Length
                )
                {
                    continue;
                }
                if (currNode.Children.ContainsKey(_board[newRow][newCol]))
                {
                    Backtracking(newRow, newCol, currNode);
                }
            }

            // End of EXPLORATION, restore the original letter in the board.
            _board[row][col] = letter;

            // Optimization: incrementally remove the leaf nodes
            if (currNode.Children.Count == 0)
            {
                parent.Children.Remove(letter);
            }
        }

    }
}
