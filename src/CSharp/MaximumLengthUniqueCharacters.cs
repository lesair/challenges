using System;
using System.Collections.Generic;

namespace CSharp
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    /// </summary>
    public static class MaximumLengthUniqueCharacters
    {
        public static IEnumerable<Func<IEnumerable<string>, int>> Implementations
        {
            get
            {
                return new Func<IEnumerable<string>, int>[]
                {
                    MaxLengthIterativeImplementation
                };
            }
        }

        /// <summary>
        ///     Gets the maximum length of a string that results from the concatenation of a sub-sequence of strings which have
        ///     unique characters.
        /// </summary>
        /// <param name="strings">Array of strings to concatenate.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        /// <returns>The maximum possible length of the resulting string whose characters are unique.</returns>
        public static int MaxLength(IEnumerable<string> strings, Func<IEnumerable<string>, int> implementation = null)
        {
            if (implementation == null)
                implementation = MaxLengthIterativeImplementation;

            return implementation(strings);
        }

        /// <summary>
        ///     Iterative, no Linq.
        ///     Time complexity:
        ///     Space complexity:
        /// </summary>
        private static int MaxLengthIterativeImplementation(IEnumerable<string> arr)
        {
            var longestLengthFound = 0;
            var candidates = new List<string>();

            foreach (var s in arr)
            {
                for (var i = 0; i < candidates.Count; i++)
                    if (!(candidates[i] + s).HasRepeatedCharacters())
                        AddCandidate(candidates[i] + s);

                if (!s.HasRepeatedCharacters())
                    AddCandidate(s);
            }

            return longestLengthFound;

            void AddCandidate(string s)
            {
                candidates.Add(s);
                if (s.Length > longestLengthFound)
                    longestLengthFound = s.Length;
            }
        }
    }
}