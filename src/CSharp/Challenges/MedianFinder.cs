using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Median is the middle value in an ordered integer list. If the size of the list is even, there is no middle value.
    ///     So the median is the mean of the two middle value.
    ///     Design a data structure that supports the following two operations:
    ///     * void addNum(int num) - Add a integer number from the data stream to the data structure.
    ///     * double findMedian() - Return the median of all elements so far.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-median-from-data-stream/
    ///     Source: Joma Tech
    ///     https://youtu.be/HTXTVfBCeSY?t=390
    /// </summary>
    public abstract class MedianFinder
    {
        protected readonly List<int> SortedList;

        protected MedianFinder()
        {
            SortedList = new List<int>();
        }

        public abstract void AddNum(int num);

        public virtual double FindMedian()
        {
            var middleIndex = SortedList.Count / 2d;
            var result = SortedList.Count % 2 == 0
                ? (SortedList[(int) middleIndex - 1] + SortedList[(int) middleIndex]) / 2d
                : SortedList[(int) middleIndex];
            return result;
        }
    }

    public class BuiltInBinarySearchImplementation : MedianFinder
    {
        /// <summary>
        ///     Built-in binary search.
        ///     Time complexity: O(n log n).
        ///     Space complexity: O(n).
        /// </summary>
        public override void AddNum(int num)
        {
            var index = SortedList.BinarySearch(num);
            if (index < 0)
                SortedList.Insert(~index, num);
            else
                SortedList.Insert(index, num);
        }
    }

    public class InsertionSortImplementation : MedianFinder
    {
        /// <summary>
        ///     Iterative.
        ///     Manual binary search.
        ///     https://en.wikipedia.org/wiki/Binary_search_algorithm
        ///     Time complexity: O(n log n).
        ///     Space complexity: O(n).
        /// </summary>
        public override void AddNum(int num)
        {
            int BinarySearch()
            {
                var l = 0;
                var r = SortedList.Count - 1;

                while (l <= r)
                {
                    var m = (l + r) / 2;
                    if (SortedList[m] == num)
                        return m;
                    if (SortedList[m] < num)
                        l = m + 1;
                    if (SortedList[m] > num)
                        r = m - 1;
                }

                return l;
            }

            var index = BinarySearch();
            SortedList.Insert(index, num);
        }
    }
}