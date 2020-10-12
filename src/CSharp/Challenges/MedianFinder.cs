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
    public class MedianFinder
    {
        private readonly List<int> _sortedList;

        public MedianFinder()
        {
            _sortedList = new List<int>();
        }

        /// <summary>
        ///     Binary search.
        ///     Time complexity: O(n log n).
        ///     Space complexity: O(n).
        /// </summary>
        public void AddNum(int num)
        {
            var index = _sortedList.BinarySearch(num);
            if (index < 0)
                _sortedList.Insert(~index, num);
            else
                _sortedList.Insert(index, num);
        }

        public double FindMedian()
        {
            var middleIndex = _sortedList.Count / 2d;
            var result = _sortedList.Count % 2 == 0
                ? (_sortedList[(int) middleIndex - 1] + _sortedList[(int) middleIndex]) / 2d
                : _sortedList[(int) middleIndex];
            return result;
        }
    }
}