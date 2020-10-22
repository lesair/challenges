using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Merge two sorted arrays and keep the merged array, sorted.
    ///     Source: Interview Cake
    ///     https://www.interviewcake.com/question/csharp/merge-sorted-arrays
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/merge-sorted-array/
    /// </summary>
    public static class MergeSortedArrays
    {
        /// <summary>
        ///     Iterative. Manual.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<int> ManualImplementation(IList<int> integers1, IList<int> integers2)
        {
            var i1 = 0;
            var i2 = 0;
            while (i1 < integers1.Count && i2 < integers2.Count)
                if (integers1[i1] <= integers2[i2])
                {
                    yield return integers1[i1];
                    i1++;
                }
                else
                {
                    yield return integers2[i2];
                    i2++;
                }

            for (; i1 < integers1.Count; i1++) yield return integers1[i1];
            for (; i2 < integers2.Count; i2++) yield return integers2[i2];
        }

        /// <summary>
        ///     Iterative. LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<int> LinqImplementation(IList<int> integers1, IList<int> integers2)
        {
            var result = integers1.Concat(integers2).OrderBy(i => i);
            return result;
        }
    }
}