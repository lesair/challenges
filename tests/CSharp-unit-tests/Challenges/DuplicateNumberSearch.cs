using System.Collections;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class DuplicateNumberSearch : BaseTest
    {
        public DuplicateNumberSearch()
        {
            TypeToTest = typeof(FindDuplicateNumber);
        }

        private void TestImplementations(IEnumerable integers, int expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int) implementation.Invoke(null, new object[] {integers});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsDuplicatedNumberTestCase01()
        {
            var integers = new[] {1, 3, 4, 2, 2};
            const int expectedResult = 2;
            TestImplementations(integers, expectedResult);
        }


        [Fact]
        public void ReturnsDuplicatedNumberTestCase02()
        {
            var integers = new[] {3, 1, 3, 4, 2};
            const int expectedResult = 3;
            TestImplementations(integers, expectedResult);
        }

        [Fact]
        public void ReturnsDuplicatedNumberTestCase03()
        {
            var integers = new[] {1, 1};
            const int expectedResult = 1;
            TestImplementations(integers, expectedResult);
        }

        [Fact]
        public void ReturnsDuplicatedNumberTestCase04()
        {
            var integers = new[] {1, 1, 2};
            const int expectedResult = 1;
            TestImplementations(integers, expectedResult);
        }

        [Fact]
        public void ReturnsDuplicatedNumberTestCase05()
        {
            var integers = new[] {2, 5, 9, 6, 9, 3, 8, 9, 7, 1};
            const int expectedResult = 9;
            TestImplementations(integers, expectedResult);
        }

        [Fact]
        public void ReturnsDuplicatedNumberTestCase06()
        {
            var integers = new[] {4, 2, 5, 7, 5, 3, 5, 9, 5, 5};
            const int expectedResult = 5;
            TestImplementations(integers, expectedResult);
        }
    }
}