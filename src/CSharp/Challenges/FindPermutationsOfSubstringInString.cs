using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Finds all permutations of a substring in a string.
    ///     This is a variation of "find the needle in the haystack", allowing to find permutations (i.e. anagrams) of the
    ///     needle.
    ///     Source: Stack Overflow
    ///     https://stackoverflow.com/questions/10727118/how-to-find-all-permutations-of-a-given-word-in-a-given-text
    ///     Reported by: Marco Antonio Alvarado Ortega at a Luxoft interview.
    /// </summary>
    public static class FindPermutationsOfSubstringInString
    {
        /// <summary>
        ///     Iterative.
        ///     Hash table.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<string> IterativeImplementation(string needle, string haystack)
        {
            for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                var needleCandidate = haystack.Substring(i, needle.Length);
                if (needle.IsAnagramOf(needleCandidate))
                    yield return needleCandidate;
            }
        }

        private static bool IsAnagramOf(this string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1))
                return false;

            var dictionary = new Dictionary<char, int>();
            foreach (var c in s1)
                if (dictionary.ContainsKey(c))
                    dictionary[c]++;
                else
                    dictionary.Add(c, 1);

            foreach (var c in s2.ToLower())
            {
                if (!dictionary.ContainsKey(c) || dictionary[c] < 1)
                    return false;
                dictionary[c]--;
            }

            return true;
        }
    }
}