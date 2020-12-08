using System;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Given a collection of characters, reverse the order of the words in place.
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/csharp/reverse-words
    ///     Source: LeetCode.
    ///     https://leetcode.com/problems/reverse-words-in-a-string/
    /// </summary>
    public static class ReverseWordsInPlace
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static void IterativeImplementation(char[] chars)
        {
            void Swap(int start, int end)
            {
                while (++start < --end)
                {
                    chars[start] = (char) (chars[start] ^ chars[end]);
                    chars[end] = (char) (chars[end] ^ chars[start]);
                    chars[start] = (char) (chars[start] ^ chars[end]);
                }
            }

            // First step: full char reversal.
            var i = 0;
            var j = chars.Length;
            Swap(i - 1, j);

            // Second step: char reversal by word.
            i = 0;
            while (i < chars.Length)
            {
                j = Array.IndexOf(chars, ' ', i);
                if (j == -1)
                    j = chars.Length;
                Swap(i - 1, j);
                i = j + 1;
            }
        }
    }
}