using System;
using System.Collections.Generic;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Write a function for doing an in-place shuffle of a list.
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/csharp/shuffle
    /// </summary>
    public static class ShuffleAListInPlace
    {
        /// <summary>
        ///     Fisher-Yates shuffle (Knuth shuffle).
        ///     https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        /// <param name="list"></param>
        public static void FisherYatesImplementation(IList<int> list)
        {
            void SwapListItemsInPlace(int i, int j)
            {
                list[i] = list[i] ^ list[j];
                list[j] = list[j] ^ list[i];
                list[i] = list[i] ^ list[j];
            }

            var n = list.Count;
            var random = new Random();
            for (var i = 0; i < n - 1; i++)
            {
                var j = random.Next(0 + i, n);
                SwapListItemsInPlace(j, i);
            }
        }
    }
}