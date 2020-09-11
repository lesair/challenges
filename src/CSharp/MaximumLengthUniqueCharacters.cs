using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Extensions;

namespace CSharp
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    /// </summary>
    public static class MaximumLengthUniqueCharacters
    {
        public static IEnumerable<Func<IList<string>, int>> Implementations
        {
            get
            {
                return new Func<IList<string>, int>[]
                {
                    MaxLengthIterativeImplementation,
                    MaxLengthRecursiveImplementation
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
        public static int MaxLength(IList<string> strings, Func<IList<string>, int> implementation = null)
        {
            if (implementation == null)
                implementation = MaxLengthIterativeImplementation;

            return implementation(strings);
        }

        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n²).
        ///     Space complexity: O(n²).
        /// </summary>
        private static int MaxLengthIterativeImplementation(IList<string> strings)
        {
            var longestLengthFound = 0;
            var candidates = new List<string>();

            foreach (var s in strings)
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
                longestLengthFound = Math.Max(longestLengthFound, s.Length);
            }
        }

        /// <summary>
        ///     Recursive. Backtracking.
        ///     Time complexity: Θ(?).
        ///     Space complexity: Θ(?).
        /// </summary>
        private static int MaxLengthRecursiveImplementation(IList<string> strings)
        {
            int FindMaxLength(string accumulatedConcatenation, IEnumerable<string> currentStrings)
            {
                var stringsQueue = new Queue<string>(currentStrings);

                if (accumulatedConcatenation.HasRepeatedCharacters()) return 0;
                if (!stringsQueue.Any()) return accumulatedConcatenation.Length;

                var nextString = stringsQueue.Dequeue();

                var depthMaxLength = FindMaxLength(accumulatedConcatenation + nextString, stringsQueue);
                var breadthMaxLength = FindMaxLength(accumulatedConcatenation, stringsQueue);

                return Math.Max(accumulatedConcatenation.Length, Math.Max(depthMaxLength, breadthMaxLength));
            }

            return FindMaxLength(string.Empty, strings);
        }
    }
}