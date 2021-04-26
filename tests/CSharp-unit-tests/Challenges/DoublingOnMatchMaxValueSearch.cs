using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class DoublingOnMatchMaxValueSearch : BaseTest
    {
        public DoublingOnMatchMaxValueSearch()
        {
            TypeToTest = typeof(FindMaxValueDoublingOnMatch);
        }

        private void TestImplementations(int[] numbers, int k, int expected)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var invocationResult = (int?) implementation.Invoke(null, new object[] {numbers, k});
                invocationResult.ShouldNotBeNull();
                var actual = invocationResult.Value;
                actual.ShouldBe(expected);
            }
        }

        [Fact]
        public void ReturnsTheMaximumValueTestCase01()
        {
            var numbers = new[] {2, 3, 4, 10, 8, 1};
            const int k = 2;
            var expected = 16;
            TestImplementations(numbers, k, expected);
        }

        [Fact]
        public void ReturnsTheMaximumValueTestCase02()
        {
            var numbers = new[] {4};
            const int k = 2;
            var expected = 2;
            TestImplementations(numbers, k, expected);
        }

        [Fact]
        public void ReturnsTheMaximumValueTestCase03()
        {
            var numbers = new[] {4};
            const int k = 4;
            var expected = 8;
            TestImplementations(numbers, k, expected);
        }

        [Fact]
        public void ReturnsTheMaximumValueTestCase04()
        {
            var numbers = new[] {8, 8, 0, 4, 3, 2, -2};
            const int k = 2;
            var expected = 16;
            TestImplementations(numbers, k, expected);
        }

        [Fact]
        public void ReturnsTheMaximumValueTestCase05()
        {
            var numbers = new[] {2, 4, 5, 6, 7};
            const int k = 3;
            var expected = 3;
            TestImplementations(numbers, k, expected);
        }
    }
}