using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class EvenTermsOfFibonacciSequenceSummation : BaseTest
    {
        public EvenTermsOfFibonacciSequenceSummation()
        {
            TypeToTest = typeof(SumEvenValuedTermsOfFibonacciSequence);
        }

        private void TestImplementations(long limit, long expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (long) implementation.Invoke(null, new object[] {limit});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs0()
        {
            const long limit = 0;
            const long expected = 0;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs1()
        {
            const long limit = 1;
            const long expected = 0;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs2()
        {
            const long limit = 2;
            const long expected = 2;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs28657()
        {
            const long limit = 28657;
            const long expected = 14328;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs3()
        {
            const long limit = 3;
            const long expected = 2;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs4000000()
        {
            const long limit = 4000000;
            const long expected = 4613732;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs5()
        {
            const long limit = 5;
            const long expected = 2;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs8()
        {
            const long limit = 8;
            const long expected = 10;
            TestImplementations(limit, expected);
        }

        [Fact]
        public void CorrectlyCalculatesTheSumWhenLimitIs89()
        {
            const long limit = 89;
            const long expected = 44;
            TestImplementations(limit, expected);
        }
    }
}