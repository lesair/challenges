using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class SortedArrayElementSearch : BaseTest
    {
        public SortedArrayElementSearch()
        {
            TypeToTest = typeof(FindElementInSortedArray);
        }

        private void TestImplementations(IEnumerable<int> numbers, int target, int expected)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var invocationResult = (int?) implementation.Invoke(null, new object[] {numbers, target});
                invocationResult.ShouldNotBeNull();
                var actual = invocationResult.Value;
                if (expected >= 0)
                    actual.ShouldBe(expected);
                else
                    actual.ShouldBeLessThan(0);
            }
        }

        [Fact]
        public void CorrectlyReturnsTheIndexOfTheMatchedElementTestCase01()
        {
            var numbers = new[] {5};
            const int target = 5;
            const int expected = 0;
            TestImplementations(numbers, target, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheIndexOfTheMatchedElementTestCase02()
        {
            var numbers = new[] {2, 5};
            const int target = 2;
            const int expected = 0;
            TestImplementations(numbers, target, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheIndexOfTheMatchedElementTestCase03()
        {
            var numbers = new[] {2, 5};
            const int target = 5;
            const int expected = 1;
            TestImplementations(numbers, target, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheIndexOfTheMatchedElementTestCase04()
        {
            var numbers = new[] {-1, 0, 3, 5, 9, 12};
            const int target = 9;
            const int expected = 4;
            TestImplementations(numbers, target, expected);
        }

        [Fact]
        public void CorrectlyReturnsNotFoundTestCase01()
        {
            var numbers = new[] {5};
            const int target = 6;
            const int expected = -1;
            TestImplementations(numbers, target, expected);
        }

        [Fact]
        public void CorrectlyReturnsNotFoundTestCase02()
        {
            var numbers = new[] {-1, 0, 3, 5, 9, 12};
            const int target = 2;
            const int expected = -1;
            TestImplementations(numbers, target, expected);
        }
    }
}