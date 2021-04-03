using System.Collections;
using System.Linq;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class RotatedSortedArrayMinimumSearch : BaseTest
    {
        public RotatedSortedArrayMinimumSearch()
        {
            TypeToTest = typeof(FindMinimumInRotatedSortedArray);
        }

        private void TestImplementations(IEnumerable numbers, int expected)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actual = (int?) implementation.Invoke(null, new object[] {numbers});
                actual.ShouldNotBeNull();
                actual.ShouldBe(expected);
            }
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase01()
        {
            var numbers = new[] {3, 4, 5, 1, 2};
            const int expected = 1;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase02()
        {
            var numbers = new[] {4, 5, 6, 7, 0, 1, 2};
            const int expected = 0;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase03()
        {
            var numbers = new[] {11, 13, 15, 17};
            const int expected = 11;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase04()
        {
            var numbers = new[] {1, 2};
            const int expected = 1;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase05()
        {
            var numbers = new[] {2, 1};
            const int expected = 1;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase06()
        {
            var numbers = new[] {5, 1, 2, 3, 4};
            const int expected = 1;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueTestCase07()
        {
            var numbers = new[] {3, 1, 2};
            const int expected = 1;
            TestImplementations(numbers, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheMinimumValueInLogNTime()
        {
            var numbers = Enumerable.Range(-500_000, 1_000_000).ToArray();
            numbers = numbers.Union(Enumerable.Range(-1_000_000, 500_000)).ToArray();
            const int expected = -1_000_000;
            TestImplementations(numbers, expected);
        }
    }
}