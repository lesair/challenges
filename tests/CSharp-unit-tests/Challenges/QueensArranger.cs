using System.Collections.Generic;
using System.Linq;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class QueensArranger : BaseTest
    {
        public QueensArranger()
        {
            TypeToTest = typeof(ArrangeNQueens);
        }

        private void TestImplementations(int n, ICollection<IEnumerable<string>> expectedResults)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResults = ((IEnumerable<IEnumerable<string>>) implementation.Invoke(null, new object[] {n}))
                    ?.ToList();
                actualResults.ShouldNotBeNull();
                actualResults.ShouldBe(expectedResults);
            }
        }

        private void TestImplementations(int n, int expectedResultsCount)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResults = ((IEnumerable<IEnumerable<string>>) implementation.Invoke(null, new object[] {n}))
                    ?.ToList();
                actualResults.ShouldNotBeNull();
                actualResults.Count.ShouldBe(expectedResultsCount);
            }
        }

        [Fact]
        public void GeneratesAllValidSolutionsForOneQueen()
        {
            const int n = 1;
            const int expectedResultsCount = 1;
            var solution1 = new List<string> {"Q"};
            var expectedResults = new List<IEnumerable<string>> {solution1};
            TestImplementations(n, expectedResults);
            TestImplementations(n, expectedResultsCount);
        }

        [Fact]
        public void GeneratesAllValidSolutionsForTwoQueens()
        {
            const int n = 2;
            const int expectedResultsCount = 0;
            var expectedResults = new List<IEnumerable<string>>();
            TestImplementations(n, expectedResults);
            TestImplementations(n, expectedResultsCount);
        }

        [Fact]
        public void GeneratesAllValidSolutionsForThreeQueens()
        {
            const int n = 3;
            const int expectedResultsCount = 0;
            var expectedResults = new List<IEnumerable<string>>();
            TestImplementations(n, expectedResults);
            TestImplementations(n, expectedResultsCount);
        }

        [Fact]
        public void GeneratesAllValidSolutionsForFourQueens()
        {
            const int n = 4;
            const int expectedResultsCount = 2;
            var solution1 = new List<string>
            {
                ".Q..",
                "...Q",
                "Q...",
                "..Q."
            };
            var solution2 = new List<string>
            {
                "..Q.",
                "Q...",
                "...Q",
                ".Q.."
            };
            var expectedResults = new List<IEnumerable<string>> {solution1, solution2};
            TestImplementations(n, expectedResults);
            TestImplementations(n, expectedResultsCount);
        }

        [Fact]
        public void GeneratesAllValidSolutionsForFiveQueens()
        {
            const int n = 5;
            const int expectedResultsCount = 10;
            TestImplementations(n, expectedResultsCount);
        }

        [Fact]
        public void GeneratesAllValidSolutionsForElevenQueens()
        {
            const int n = 11;
            const int expectedResultsCount = 2_680;
            TestImplementations(n, expectedResultsCount);
        }
    }
}