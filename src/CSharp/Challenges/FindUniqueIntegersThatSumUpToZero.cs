using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Find N Unique Integers Sum up to Zero
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/
    /// </summary>
    public static class FindUniqueIntegersThatSumUpToZero
    {
        /// <summary>
        ///     Iterative. Elegant.
        ///     Hash set.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static int[] IterativeImplementation(int n)
        {
            HashSet<int> set;
            if (n % 2 == 0)
            {
                set = new HashSet<int>(Enumerable.Range(-n / 2, n + 1));
                set.Remove(0);
            }
            else
            {
                set = new HashSet<int>(Enumerable.Range(-n / 2, n));
            }

            return set.ToArray();
        }
    }
}