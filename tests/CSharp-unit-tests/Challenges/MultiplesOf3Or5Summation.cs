using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class MultiplesOf3Or5Summation : BaseTest
    {
        public MultiplesOf3Or5Summation()
        {
            TypeToTest = typeof(SumMultiplesOf3Or5);
        }

        private void TestImplementations(int n, long expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (long) implementation.Invoke(null, new object[] {n});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyCalculatesTheSumOfMultiplesOf3Or5Below10()
        {
            const int n = 10;
            const long expected = 23;
            TestImplementations(n, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumOfMultiplesOf3Or5Below100()
        {
            const int n = 100;
            const long expected = 2318;
            TestImplementations(n, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumOfMultiplesOf3Or5Below1000()
        {
            const int n = 1000;
            const long expected = 233168;
            TestImplementations(n, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumOfMultiplesOf3Or5Below1000000000()
        {
            const int n = 1000000000;
            const long expected = 233333333166666668;
            TestImplementations(n, expected);
        }
    }
}