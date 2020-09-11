using System;

namespace CSharp.Library.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        ///     Does an integer division rounding the result up to the ceiling. The native integer division rounds down to the
        ///     floor.
        ///     https://stackoverflow.com/a/63012251/4376148
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int RoundUpDivideBy(this int a, int b)
        {
            var result = Math.DivRem(a, b, out var remainder);
            if (remainder != 0) result++;
            return result;
        }
    }
}