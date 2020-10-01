using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Challenges
{
    /// <summary>
    ///     By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the
    ///     even-valued terms.
    ///     Source: Project Euler.
    ///     https://projecteuler.net/problem=2
    ///     https://www.hackerrank.com/contests/projecteuler/challenges/euler002
    /// </summary>
    public static class SumEvenValuedTermsOfFibonacciSequence
    {
        /// <summary>
        ///     Iterative.
        ///     LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static long IterativeImplementation(long limit)
        {
            static IEnumerable<long> FibonacciNumbers()
            {
                long current = 0, next = 1;

                while (true)
                {
                    yield return current;
                    next = current + (current = next);
                }

                // ReSharper disable once IteratorNeverReturns
            }

            var sum = FibonacciNumbers().TakeWhile(f => f <= limit).Where(f => f % 2 == 0).Sum();
            return sum;
        }

        /// <summary>
        ///     Formula.
        ///     https://www.youtube.com/watch?v=CWhcUea5GNc
        ///     Time complexity: O(1).
        ///     Space complexity: O(1).
        /// </summary>
        public static long FormulaImplementation(long limit)
        {
            if (limit < 1)
                return 0;
            var n = N(limit);
            n = n / 3 * 3; // Only every 3rd limit number is an even number.
            return (Fibonacci(n + 2) - Fibonacci(2)) / 2;
        }

        /// <summary>
        ///     Gets the nth fibonacci number in the series.
        ///     Author: Jacques Philippe Marie Binet.
        ///     http://mathworld.wolfram.com/BinetsFibonacciNumberFormula.html
        ///     http://www.maths.surrey.ac.uk/hosted-sites/R.Knott/Fibonacci/fibFormula.html
        /// </summary>
        private static long Fibonacci(int n)
        {
            var φ = (1 + Math.Sqrt(5)) / 2;
            var f = (Math.Pow(φ, n) - Math.Pow(-φ, -n)) / Math.Sqrt(5);
            return Convert.ToInt64(f);
        }

        /// <summary>
        ///     Gets the nth index of the nearest fibonacci number in the series.
        ///     Author: Neil W.
        ///     https://math.stackexchange.com/questions/848691/how-to-tell-if-a-fibonacci-number-has-an-even-or-odd-index
        ///     Time complexity: O(1).
        /// </summary>
        /// <param name="fibonacci">Fibonacci number to find its nth index in the series.</param>
        /// <returns>Nth index of the provided fibonacci number in the series.</returns>
        private static int N(long fibonacci)
        {
            var φ = (1 + Math.Sqrt(5)) / 2;
            var α = 1 / Math.Log(φ);
            var β = Math.Log(Math.Sqrt(5)) / Math.Log(φ);
            return Convert.ToInt32(α * Math.Log(fibonacci) + β);
        }
    }
}