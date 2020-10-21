using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class SortedArraysMerge : BaseTest
    {
        public SortedArraysMerge()
        {
            TypeToTest = typeof(MergeSortedArrays);
        }

        private void TestImplementations(IEnumerable<int> integers1, IEnumerable<int> integers2,
            IReadOnlyCollection<int> expectedResults)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResults = (IEnumerable<int>) implementation.Invoke(null, new object[] {integers1, integers2});
                actualResults.ShouldBe(expectedResults);
            }
        }

        [Fact]
        public void ReturnsACorrectlyMergedArrayTestCase01()
        {
            var integers1 = new[] {3, 4, 6, 10, 11, 15};
            var integers2 = new[] {1, 5, 8, 12, 14, 19};
            var expectedResults = new[] {1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19};
            TestImplementations(integers1, integers2, expectedResults);
        }

        [Fact]
        public void ReturnsACorrectlyMergedArrayTestCase02()
        {
            var integers1 = new[] {1, 2, 3};
            var integers2 = new[] {2, 5, 6};
            var expectedResults = new[] {1, 2, 2, 3, 5, 6};
            TestImplementations(integers1, integers2, expectedResults);
        }

        [Fact]
        public void ReturnsACorrectlyMergedArrayTestCase03()
        {
            var integers1 = new[] {0, 4, 8};
            var integers2 = new[] {1, 2, 3};
            var expectedResults = new[] {0, 1, 2, 3, 4, 8};
            TestImplementations(integers1, integers2, expectedResults);
        }

        [Fact]
        public void ReturnsACorrectlyMergedArrayTestCase04()
        {
            var integers1 = new[] {1};
            var integers2 = new int[0];
            var expectedResults = new[] {1};
            TestImplementations(integers1, integers2, expectedResults);
        }
    }
}