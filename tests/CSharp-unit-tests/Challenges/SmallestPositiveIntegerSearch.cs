using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class SmallestPositiveIntegerSearch : BaseTest
    {
        public SmallestPositiveIntegerSearch()
        {
            TypeToTest = typeof(FindSmallestPositiveInteger);
        }

        private void TestImplementations(IEnumerable<int> integers, int expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int) implementation.Invoke(null, new object[] {integers});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyReturnsMissingSmallestPositiveInteger()
        {
            var integers = new[] {1, 3, 6, 4, 1, 2};
            const int expected = 5;
            TestImplementations(integers, expected);
        }
    }
}