using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Given an array of integers containing n + 1 integers where each integer is in the range [1, n] inclusive, find the
    ///     duplicate number and return it. Solution should have time complexity less than O(n²) and use constant O(1) space.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/linked-list-cycle/
    ///     Source: Joma Tech
    ///     https://youtu.be/pKO9UjSeLew
    /// </summary>
    public static class FindDuplicateNumber
    {
        /// <summary>
        ///     Author: Robert W. Floyd
        ///     https://en.wikipedia.org/wiki/Cycle_detection#Floyd's_Tortoise_and_Hare
        ///     Iterative.
        ///     Time complexity: O(λ + μ).
        ///     Space complexity: O(1).
        /// </summary>
        // ReSharper disable once IdentifierTypo
        public static int FloydsTortoiseAndHareImplementation(IList<int> integers)
        {
            var tortoise = 0;
            var hare = 0;

            do
            {
                tortoise = integers[tortoise];
                hare = integers[hare];
                hare = integers[hare];
            } while (tortoise != hare);

            tortoise = 0;
            while (hare != tortoise)
            {
                tortoise = integers[tortoise];
                hare = integers[hare];
            }

            return tortoise;
        }
    }
}