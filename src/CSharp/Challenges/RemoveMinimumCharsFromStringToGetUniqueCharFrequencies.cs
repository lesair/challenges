using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Returns the minimum removals needed to make character frequencies unique in a given string.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/
    /// </summary>
    public static class RemoveMinimumCharsFromStringToGetUniqueCharFrequencies
    {
        /// <summary>
        ///     Iterative.
        ///     Hash table.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static int IterativeImplementation(string s)
        {
            var charMap = new Dictionary<char, int>();
            foreach (var c in s)
                if (!charMap.TryAdd(c, 1))
                    charMap[c]++;
            var countMap = new Dictionary<int, char>();
            var removalsCounter = 0;
            foreach (var (key, value) in charMap)
            {
                var removals = 0;
                while (removals < value && !countMap.TryAdd(value - removals, key)) removals++;

                removalsCounter += removals;
            }

            return removalsCounter;
        }
    }
}