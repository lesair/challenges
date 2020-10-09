using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Adds the minimum number of parentheses in any position to make it a balanced bracket sequence.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/minimum-add-to-make-parentheses-valid/
    ///     Source: Competitive Programming Algorithms
    ///     https://cp-algorithms.com/combinatorics/bracket_sequences.html
    ///     Reported by: José Fabricio Rojas Quiroz at a Facebook interview.
    /// </summary>
    public static class AddMinimumToBalanceBracketSequence
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static (int minToAdd, string balanced) Implementation(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == ')' && stack.TryPeek(out var previous) && previous == '(')
                {
                    stack.Pop();
                    continue;
                }

                stack.Push(c);
            }

            var minToAdd = stack.Count;
            while (stack.Any())
            {
                var c = stack.Pop();
                if (c == ')')
                    s = "(" + s;
                else
                    s += ")";
            }

            return (minToAdd, s);
        }
    }
}