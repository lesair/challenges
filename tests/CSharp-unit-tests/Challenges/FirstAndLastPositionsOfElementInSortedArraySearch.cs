using System.Collections;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class FirstAndLastPositionsOfElementInSortedArraySearch : BaseTest
    {
        public FirstAndLastPositionsOfElementInSortedArraySearch()
        {
            TypeToTest = typeof(FindFirstAndLastPositionsOfElementInSortedArray);
        }

        private void TestImplementations(IEnumerable integers, int target, int expectedStart, int expectedEnd)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var (actualStart, actualEnd) =
                    ((int start, int end)) implementation.Invoke(null, new object[] {integers, target});
                actualStart.ShouldBe(expectedStart);
                actualEnd.ShouldBe(expectedEnd);
            }
        }

        [Fact]
        public void ReturnsDuplicatedElementStartAndEndingPositionsTestCase01()
        {
            var integers = new[] {5, 7, 7, 8, 8, 10};
            const int target = 8;
            const int expectedStart = 3;
            const int expectedEnd = 4;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }


        [Fact]
        public void ReturnsDuplicatedElementStartAndEndingPositionsTestCase02()
        {
            var integers = new[] {2, 2};
            const int target = 2;
            const int expectedStart = 0;
            const int expectedEnd = 1;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }

        [Fact]
        public void ReturnsNotFoundIfArrayIsEmpty()
        {
            var integers = new int[0];
            const int target = 0;
            const int expectedStart = -1;
            const int expectedEnd = -1;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }

        [Fact]
        public void ReturnsNotFoundIfElementIsMissingTestCase01()
        {
            var integers = new[] {5, 7, 7, 8, 8, 10};
            const int target = 6;
            const int expectedStart = -1;
            const int expectedEnd = -1;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }

        [Fact]
        public void ReturnsNotFoundIfElementIsMissingTestCase02()
        {
            var integers = new[] {2, 2};
            const int target = 3;
            const int expectedStart = -1;
            const int expectedEnd = -1;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }

        [Fact]
        public void ReturnsSameStartAndEndingPositionsForUniqueElement()
        {
            var integers = new[] {5, 7, 7, 8, 8, 10};
            const int target = 10;
            const int expectedStart = 5;
            const int expectedEnd = 5;
            TestImplementations(integers, target, expectedStart, expectedEnd);
        }
    }
}