using System;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Return the smallest positive integer (greater than 0) that does not occur in a given array.
    ///     Source: Codility
    ///     Codility demo test.
    /// </summary>
    public static class FindSmallestPositiveInteger
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n log n).
        ///     Space complexity: O(1).
        /// </summary>
        public static int IterativeImplementation(int[] integers)
        {
            var result = 1;
            Array.Sort(integers);

            foreach (var i in integers.Distinct())
                if (result == i)
                    result++;

            return result;
        }
    }
}