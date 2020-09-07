using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp
{
    /// <summary>
    ///     Common useful extensions.
    /// </summary>
    public static class Extensions
    {
        public static IEnumerable<Func<string, bool>> Implementations
        {
            get
            {
                return new Func<string, bool>[]
                {
                    HasRepeatedCharactersLinqImplementation,
                    HasRepeatedCharactersDictionaryImplementation
                };
            }
        }

        /// <summary>
        ///     Determines if a string contains repeated characters.
        /// </summary>
        /// <param name="s">The string to evaluate.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        /// <returns>True if it contains repeated characters, false otherwise.</returns>
        public static bool HasRepeatedCharacters(this string s, Func<string, bool> implementation = null)
        {
            if (implementation == null)
                implementation = HasRepeatedCharactersDictionaryImplementation;

            return implementation(s);
        }

        /// <summary>
        ///     <see cref="HasRepeatedCharacters" /> iterative implementation with LINQ.
        ///     Tags: Iterative, LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static bool HasRepeatedCharactersLinqImplementation(this string s)
        {
            return s
                .Select(c => c)
                .GroupBy(c => c)
                .Select(g => g.Count())
                .Any(c => c > 1);
        }

        /// <summary>
        ///     <see cref="HasRepeatedCharacters" /> iterative implementation with a Dictionary.
        ///     Tags: Iterative, hash table.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static bool HasRepeatedCharactersDictionaryImplementation(this string s)
        {
            Guard.Against.Null(s, nameof(s));

            var dictionary = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (dictionary.ContainsKey(c))
                    return true;
                dictionary.Add(c, 1);
            }

            return false;
        }
    }
}