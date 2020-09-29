using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Validates if a string of brackets contains a valid combination of opening and closing bracket sequences.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/valid-parentheses/
    ///     Source:
    /// </summary>
    public static class ValidateMatchingParentheses
    {
        /// <summary>
        ///     Iterative. Elegant.
        ///     Stack. Hash table.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static bool ElegantImplementation(string s)
        {
            var dictionary = new Dictionary<char, char> {{')', '('}, {']', '['}, {'}', '{'}};
            var stack = new Stack<char>();

            foreach (var c in s)
                if (dictionary.ContainsKey(c))
                {
                    if (!stack.TryPop(out var opening) || dictionary[c] != opening)
                        return false;
                }
                else
                {
                    stack.Push(c);
                }

            return !stack.Any();
        }
    }
}