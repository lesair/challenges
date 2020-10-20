using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Find the first and last positions of an element in a sorted array.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    ///     Source:  Errichto
    ///     https://youtu.be/dVXy6hmE_0U
    /// </summary>
    public static class FindFirstAndLastPositionsOfElementInSortedArray
    {
        /// <summary>
        ///     Iterative.
        ///     Manual binary search.
        ///     https://en.wikipedia.org/wiki/Binary_search_algorithm
        ///     Time complexity: O(log n).
        ///     Space complexity: O(n).
        /// </summary>
        public static (int start, int end) ManualBinarySearchImplementation(IList<int> integers, int target)
        {
            int BinarySearch(TargetPosition position)
            {
                var l = 0;
                var r = integers.Count - 1;

                while (l <= r)
                {
                    var m = (l + r) / 2;
                    if (integers[m] < target || integers[m] == target && position == TargetPosition.End)
                        l = m + 1;
                    if (integers[m] > target || integers[m] == target && position == TargetPosition.Start)
                        r = m - 1;
                }

                if (position == TargetPosition.Start)
                    return l < integers.Count && integers[l] == target ? l : -1;
                return r >= 0 && integers[r] == target ? r : -1;
            }

            return (BinarySearch(TargetPosition.Start), BinarySearch(TargetPosition.End));
        }
    }

    public enum TargetPosition
    {
        Start,
        End
    }
}