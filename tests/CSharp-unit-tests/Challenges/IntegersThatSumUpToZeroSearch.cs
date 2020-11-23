using System.Linq;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class IntegersThatSumUpToZeroSearch : BaseTest
    {
        public IntegersThatSumUpToZeroSearch()
        {
            TypeToTest = typeof(FindUniqueIntegersThatSumUpToZero);
        }

        private void TestImplementations(int n)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int[]) implementation.Invoke(null, new object[] {n});
                actualResult.ShouldNotBeNull();
                actualResult.Sum().ShouldBe(0);
                actualResult.Length.ShouldBe(n);
                actualResult.ShouldBeUnique();
            }
        }

        [Fact]
        public void ReturnsEvenUniqueIntegersThatSumUpToZero()
        {
            const int n = 4;
            TestImplementations(n);
        }

        [Fact]
        public void ReturnsManyUniqueIntegersThatSumUpToZero()
        {
            const int n = 100;
            TestImplementations(n);
        }

        [Fact]
        public void ReturnsOddUniqueIntegersThatSumUpToZero()
        {
            const int n = 5;
            TestImplementations(n);
        }
    }
}