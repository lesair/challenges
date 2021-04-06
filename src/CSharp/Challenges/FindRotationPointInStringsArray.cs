using System;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/csharp/find-rotation-point
    /// </summary>
    public static class FindRotationPointInStringsArray
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(ℓ + log n).
        ///     Some languages —like German, Russian, and Dutch— can have arbitrarily long words, so we might want to factor the
        ///     length of the words into our runtime. We could say the length of the words is ℓ, each string comparison takes
        ///     O(ℓ) time, therefore the whole algorithm takes O(ℓ + log n) time. The longest word in English is
        ///     pneumonoultramicroscopicsilicovolcanoconiosis, a medical term. It's 45 letters long, so for English we can assume
        ///     our word lengths are bounded by some constant so we'll say the string comparison takes constant time, making it
        ///     O(log n) time.
        ///     Space complexity: O(1).
        /// </summary>
        public static int IterativeBinarySearchImplementation1(string[] strings)
        {
            var l = 0;
            var r = strings.Length - 1;
            var m = r / 2;

            while (l <= r)
            {
                if (string.Compare(strings[l], strings[r], StringComparison.OrdinalIgnoreCase) <= 0)
                    return l;

                m = (l + r) / 2;
                if (string.Compare(strings[l], strings[m], StringComparison.OrdinalIgnoreCase) <= 0)
                    l = m + 1;
                else
                    r = m;
            }

            return m;
        }

        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(ℓ + log n).
        ///     Space complexity: O(1).
        /// </summary>
        public static int IterativeBinarySearchImplementation2(string[] strings)
        {
            var l = 0;
            var r = strings.Length - 1;

            while (string.Compare(strings[l], strings[r], StringComparison.OrdinalIgnoreCase) > 0)
            {
                var m = (l + r) / 2;
                if (string.Compare(strings[l], strings[m], StringComparison.OrdinalIgnoreCase) <= 0)
                    l = m + 1;
                else
                    r = m;
            }

            return l;
        }
    }
}