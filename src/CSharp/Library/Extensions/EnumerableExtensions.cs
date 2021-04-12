using System;
using System.Collections.Generic;

namespace CSharp.Library.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Intersperses an <see cref="element" /> between the elements of the <see cref="source" /> enumeration. Inspired by
        ///     Haskell, see: https://hoogle.haskell.org/?hoogle=intersperse
        /// </summary>
        /// <typeparam name="T">The objects type in the enumeration.</typeparam>
        /// <param name="source">Source enumeration.</param>
        /// <param name="element">Separator to intersperse between the elements of the enumeration.</param>
        /// <param name="options">Specifies the leading and trailing intersperse behavior.</param>
        /// <returns>The enumeration <see cref="source" /> with the <see cref="element" /> interspersed between its elements.</returns>
        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T element, IntersperseOptions options)
        {
            if (options == IntersperseOptions.Leading) yield return element;

            var first = true;
            foreach (var value in source)
            {
                if (!first) yield return element;
                yield return value;
                first = false;
            }

            if (options == IntersperseOptions.Trailing) yield return element;
        }
    }

    /// <summary>
    ///     Specifies the leading and trailing intersperse behavior.
    /// </summary>
    [Flags]
    public enum IntersperseOptions
    {
        /// <summary>
        ///     The return enumeration won't contain a leading or trailing element.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The return enumeration will contain a leading element.
        /// </summary>
        Leading = 1,

        /// <summary>
        ///     The return enumeration will contain a trailing element.
        /// </summary>
        Trailing = 2
    }
}