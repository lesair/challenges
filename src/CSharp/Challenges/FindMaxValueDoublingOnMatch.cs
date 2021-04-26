using System;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: GeeksforGeeks
    ///     https://www.geeksforgeeks.org/find-final-value-if-we-double-after-every-successful-search-in-array/
    /// </summary>
    public static class FindMaxValueDoublingOnMatch
    {
        /// <summary>
        ///     Iterative. Binary search.
        ///     Time complexity: O(n log n).
        ///     Space complexity: O(n).
        /// </summary>
        public static int BinarySearchImplementation(int[] numbers, int k)
        {
            Array.Sort(numbers);
            while (Array.BinarySearch(numbers, k) >= 0)
                k *= 2;

            return k;
        }
    }
}