using System;
using System.Collections.Generic;
using System.Linq;

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
        public static TrieNode BadPrefixes { get; set; } = new(string.Empty);

        public static IEnumerable<string> Implementation(char[][] board, string[] words)
        {
            var wordsFound = new HashSet<string>();

            foreach (var word in words)
            {
                var wordInBadPrefixes = false;
                var wordFound = false;
                for (var i = 0; i < word.Length - 0; i++)
                {
                    if (!BadPrefixes.ContainsPrefix(word[..^i])) continue;
                    wordInBadPrefixes = true;
                    break;
                }

                if (wordInBadPrefixes)
                    continue;

                var maxMatchIndex = -1;
                for (var y = 0; y < board.Length; y++)
                {
                    if (wordFound)
                        break;
                    for (var x = 0; x < board[0].Length; x++)
                    {
                        if (wordFound)
                            break;

                        int matchIndex;
                        (wordFound, matchIndex) = FindWordInBoard(word, board, y, x);
                        if (wordFound)
                            wordsFound.Add(word);
                        maxMatchIndex = Math.Max(maxMatchIndex, matchIndex);
                    }
                }

                if (!wordFound)
                    BadPrefixes.AddPrefix(word[..(maxMatchIndex + 2)]);
            }

            return wordsFound;
        }

        private static (bool IsFound, int matchIndex) FindWordInBoard(string word, IReadOnlyList<char[]> board, int y,
            int x, int matchIndex = 0)
        {
            if (matchIndex == word.Length)
                return (true, --matchIndex);

            if (x < 0 || y < 0 || y == board.Count || x == board[0].Length)
                return (false, --matchIndex);

            if (board[y][x] == '*')
                return (false, --matchIndex);

            if (word[matchIndex] != board[y][x])
                return (false, --matchIndex);

            var newBoard = board.Select(a => a.ToArray()).ToArray();
            newBoard[y][x] = '*';

            var maxMatchIndex = matchIndex;
            var directions = new[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            foreach (var (dirY, dirX) in directions)
            {
                var (found, foundMatchIndex) = FindWordInBoard(word, newBoard, y + dirY, x + dirX, matchIndex + 1);
                if (found)
                    return (true, foundMatchIndex);
                maxMatchIndex = Math.Max(maxMatchIndex, foundMatchIndex);
            }

            return (false, maxMatchIndex);
        }
    }

    public class TrieNode : IEquatable<TrieNode>
    {
        public TrieNode(string data)
        {
            Data = data;
        }

        public string Data { get; }
        public HashSet<TrieNode> Children { get; set; } = new();

        public bool Equals(TrieNode other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Data == other.Data;
        }

        public void AddPrefix(string s, int prefixIndex = 0)
        {
            var targetChildNode = new TrieNode(s[..++prefixIndex]);

            if (!Children.Contains(targetChildNode))
                Children.Add(targetChildNode);

            if (prefixIndex == s.Length)
                return;

            Children.TryGetValue(targetChildNode, out var foundChildNode);
            foundChildNode?.AddPrefix(s, prefixIndex);
        }

        public bool ContainsPrefix(string s, int prefixIndex = 0)
        {
            if (prefixIndex == s.Length)
                return Data == s && !Children.Any();

            var targetChildNode = new TrieNode(s[..++prefixIndex]);

            if (!Children.Contains(targetChildNode))
                return false;

            Children.TryGetValue(targetChildNode, out var foundChildNode);
            return foundChildNode?.ContainsPrefix(s, prefixIndex) ?? false;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TrieNode)obj);
        }

        public override int GetHashCode()
        {
            return Data != null ? Data.GetHashCode() : 0;
        }

        public static bool operator ==(TrieNode left, TrieNode right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TrieNode left, TrieNode right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Data} [{string.Join(", ", Children)}]";
        }
    }
}