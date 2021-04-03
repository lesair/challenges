namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
    /// </summary>
    public static class FindMinimumInRotatedSortedArray
    {
        /// <summary>
        ///     Recursive.
        ///     Time complexity: O(log n)
        ///     Space complexity: O(n).
        /// </summary>
        public static int RecursiveImplementation(int[] numbers)
        {
            if (numbers[0] <= numbers[^1])
                return numbers[0];

            var m = numbers.Length / 2 - 1;
            return RecursiveImplementation(numbers[0] <= numbers[m]
                ? numbers[(m + 1)..numbers.Length]
                : numbers[..(m + 1)]);
        }

        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(log n)
        ///     Space complexity: O(1).
        /// </summary>
        public static int IterativeImplementation(int[] numbers)
        {
            var l = 0;
            var r = numbers.Length - 1;

            while (numbers[l] > numbers[r])
            {
                var m = (l + r) / 2;
                if (numbers[l] <= numbers[m])
                    l = m + 1;
                else
                    r = m;
            }

            return numbers[l];
        }
    }
}