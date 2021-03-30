using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Place n chess queens on an n×n chessboard so that no two queens threaten each other.
    ///     Source: Wikipedia
    ///     https://en.wikipedia.org/wiki/Eight_queens_puzzle
    ///     Source: Abdul Bari
    ///     https://youtu.be/xFv_Hl4B83A
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/n-queens/
    /// </summary>
    public static class ArrangeNQueens
    {
        private static int _n;

        public static IEnumerable<IEnumerable<string>> Implementation(int n)
        {
            _n = n;
            foreach (var validBoard in Backtracking()) yield return validBoard.ToStrings();
        }

        private static IEnumerable<IEnumerable<int>> Backtracking(IReadOnlyCollection<int> board = null)
        {
            board ??= new HashSet<int>();

            if (board.Count == _n)
            {
                yield return board;
                yield break;
            }

            for (var i = 0; i < _n; i++)
            {
                var newBoard = new HashSet<int>(board);
                if (!newBoard.Add(i) || newBoard.ToArray().ContainsQueensInDiagonal()) continue;
                foreach (var result in Backtracking(newBoard)) yield return result;
            }
        }

        private static bool ContainsQueensInDiagonal(this IReadOnlyList<int> board)
        {
            if (board.Count < 2)
                return false;

            var lastY = board.Count - 1;
            var lastX = board[lastY];

            for (var currentY = 0; currentY < board.Count - 1; currentY++)
            {
                var currentX = board[currentY];
                if (Math.Abs(lastX - currentX) - Math.Abs(lastY - currentY) == 0)
                    return true;
            }

            return false;
        }

        private static IEnumerable<string> ToStrings(this IEnumerable<int> board)
        {
            foreach (var row in board)
            {
                var stringRepresentation = Enumerable.Repeat('.', _n).ToArray();
                stringRepresentation[row] = 'Q';
                yield return new string(stringRepresentation);
            }
        }
    }
}