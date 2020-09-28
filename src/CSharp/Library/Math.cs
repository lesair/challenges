using System;
using System.Diagnostics.CodeAnalysis;

namespace CSharp.Library
{
    public static class Math
    {
        /// <summary>
        ///     Returns the larger of two 32-bit signed nullable integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed nullable integers to compare.</param>
        /// <param name="val2">The second of two 32-bit signed nullable integers to compare.</param>
        /// <returns>
        ///     If both parameters are not null, then val1 or val2, whichever is larger. If one parameter is not null and the
        ///     other is null, then the non-null parameter is returned. If both parameters are null, then null is returned.
        /// </returns>
        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        public static int? Max(int? val1, int? val2)
        {
            return Nullable.Compare(val1, val2) switch
            {
                -1 => val2.Value,
                1 => val1.Value,
                _ => (int?)null,
            };
        }
    }
}