using System.Collections.Generic;

namespace CSharp
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    /// </summary>
    public static class MaximumLengthUniqueCharacters
    {
        /// <summary>
        ///     Iterative, Linq.
        ///     Time complexity:
        ///     Space complexity:
        /// </summary>
        public static int MaxLength(IEnumerable<string> arr)
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