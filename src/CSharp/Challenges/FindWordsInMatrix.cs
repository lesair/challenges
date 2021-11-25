using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Given an m x n board of characters and a list of strings words, return all words on the board.
    ///     Backtracking, tries.
    ///     Source: LeetCode.
    ///     https://leetcode.com/problems/word-search-ii/
    /// </summary>
    public static class FindWordsInMatrix
    {
        private static TrieNode RootNode { get; set; }
        private static IReadOnlyList<char[]> Board { get; set; }
        private static ISet<string> WordsFound { get; set; }

        public static IEnumerable<string> Implementation(char[][] board, string[] words)
        {
            Board = board;
            WordsFound = new HashSet<string>();
            RootNode = new TrieNode(string.Empty);

            foreach (var word in words)
                RootNode.AddWord(word);

            for (var y = 0; y < board.Length; y++)
            for (var x = 0; x < board[0].Length; x++)
                BacktrackingDfs(RootNode, y, x);

            return WordsFound;
        }

        private static void BacktrackingDfs(TrieNode node, int y, int x)
        {
            if (node.IsWord)
                WordsFound.Add(node.Prefix);

            if (x < 0 || y < 0 || y == Board.Count || x == Board[0].Length)
                return;

            if (Board[y][x] == '*')
                return;

            var nextPrefix = node.Prefix + Board[y][x];
            if (!node.Children.ContainsKey(nextPrefix))
                return;

            var charValue = Board[y][x];
            Board[y][x] = '*';

            var directions = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            foreach (var (moveY, moveX) in directions) BacktrackingDfs(node.Children[nextPrefix], y + moveY, x + moveX);

            Board[y][x] = charValue;
        }
    }

    public class TrieNode
    {
        public TrieNode(string prefix, bool isWord = false)
        {
            Prefix = prefix;
            IsWord = isWord;
        }

        public string Prefix { get; }
        public bool IsWord { get; set; }
        public Dictionary<string, TrieNode> Children { get; set; } = new();

        public void AddWord(string word, int prefixIndex = 0)
        {
            var prefix = word[..++prefixIndex];

            Children.TryAdd(prefix, new TrieNode(prefix));

            if (prefixIndex < word.Length)
                Children[prefix].AddWord(word, prefixIndex);
            else
                Children[prefix].IsWord = true;
        }

        public override string ToString()
        {
            return $"{Prefix} [{string.Join(", ", Children)}]";
        }
    }
}