using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Find a pair of numbers such that they add up to a target sum.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/two-sum/
    ///     Source:  Google
    ///     https://youtu.be/XKu_SEDAykw
    /// </summary>
    public static class FindPairThatAddUpToTarget
    {
        /// <summary>
        ///     Iterative.
        ///     Hash table.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static (int i1, int i2) BuiltInBinarySearchImplementation(IList<int> integers, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < integers.Count; i++)
            {
                var integer = integers[i];
                var complement = target - integer;
                if (dictionary.ContainsKey(complement))
                    return (dictionary[complement], i);
                dictionary.TryAdd(integers[i], i);
            }

            return (-1, -1);
        }
    }
}