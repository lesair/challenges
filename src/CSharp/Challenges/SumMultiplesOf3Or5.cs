using System;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Find the sum of all the multiples of 3 or 5 below 1000.
    ///     Source: Project Euler.
    ///     https://projecteuler.net/problem=1
    ///     https://www.hackerrank.com/contests/projecteuler/challenges/euler001
    /// </summary>
    public static class SumMultiplesOf3Or5
    {
        /// <summary>
        ///     Formula. Heuristic.
        ///     Triangular number.
        ///     Time complexity: O(1).
        ///     Space complexity: O(1).
        /// </summary>
        public static long HeuristicImplementation(int n)
        {
            --n; // Below n.
            const int firstDivisor = 3;
            const int secondDivisor = 5;
            const int leastCommonMultiple = 15;
            var firstSum = SumOfMultiplesOfDivisor(firstDivisor, n);
            var secondSum = SumOfMultiplesOfDivisor(secondDivisor, n);
            var lcmSum = SumOfMultiplesOfDivisor(leastCommonMultiple, n);
            return firstSum + secondSum - lcmSum;
        }

        private static long SumOfMultiplesOfDivisor(int divisor, int n)
        {
            var maximumMultipleUnderN = n / divisor * divisor;
            return Convert.ToInt64((1 + (maximumMultipleUnderN / divisor - 1) / 2m) * maximumMultipleUnderN);
        }
    }
}