using System;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
    /// </summary>
    public static class FindElementInSortedArray
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(log n)
        ///     Space complexity: O(1).
        /// </summary>
        public static int BinarySearchImplementation(int[] numbers, int target)
        {
            var l = 0;
            var r = numbers.Length - 1;

            while (l <= r)
            {
                var m = (l + r) / 2;
                if (target == numbers[m])
                    return m;

                if (target < numbers[m])
                    r = m - 1;
                else
                    l = m + 1;
            }

            return -1;
        }

        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(log n)
        ///     https://docs.microsoft.com/en-us/dotnet/api/system.array.binarysearch?view=net-5.0
        /// </summary>
        public static int BuiltInBinarySearchImplementation(int[] numbers, int target)
        {
            return Array.BinarySearch(numbers, target);
        }
    }
}