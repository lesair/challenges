using System.Collections;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class PairThatAddUpToTargetSearch : BaseTest
    {
        public PairThatAddUpToTargetSearch()
        {
            TypeToTest = typeof(FindPairThatAddUpToTarget);
        }

        private void TestImplementations(IEnumerable integers, int target, (int i1, int i2) expectedIndices)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualIndices = ((int i1, int i2)) implementation.Invoke(null, new object[] {integers, target});
                actualIndices.i1.ShouldBe(expectedIndices.i1);
                actualIndices.i2.ShouldBe(expectedIndices.i2);
            }
        }

        [Fact]
        public void ReturnsIndicesOfElementsFoundTestCase01()
        {
            var integers = new[] {1, 2, 4, 4};
            const int target = 8;
            var expectedIndices = (i1: 2, i2: 3);
            TestImplementations(integers, target, expectedIndices);
        }

        [Fact]
        public void ReturnsIndicesOfElementsFoundTestCase02()
        {
            var integers = new[] {2, 7, 11, 15};
            const int target = 9;
            var expectedIndices = (i1: 0, i2: 1);
            TestImplementations(integers, target, expectedIndices);
        }

        [Fact]
        public void ReturnsIndicesOfElementsFoundTestCase03()
        {
            var integers = new[] {3, 2, 4};
            const int target = 6;
            var expectedIndices = (i1: 1, i2: 2);
            TestImplementations(integers, target, expectedIndices);
        }

        [Fact]
        public void ReturnsIndicesOfElementsFoundTestCase04()
        {
            var integers = new[] {3, 3};
            const int target = 6;
            var expectedIndices = (i1: 0, i2: 1);
            TestImplementations(integers, target, expectedIndices);
        }

        [Fact]
        public void ReturnsNotFoundWhenNoElementsThatAddUpToTargetExist()
        {
            var integers = new[] {1, 2, 3, 9};
            const int target = 8;
            var expectedIndices = (i1: -1, i2: -1);
            TestImplementations(integers, target, expectedIndices);
        }
    }
}