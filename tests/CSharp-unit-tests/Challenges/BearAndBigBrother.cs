using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BearAndBigBrotherTest
    {
        [Fact]
        public void ReturnsExpectedValueTestCase01()
        {
            const int limak = 4;
            const int bob = 7;
            const int expected = 2;
            var actual = BearAndBigBrother.GetsValue(limak, bob);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsExpectedValueTestCase02()
        {
            const int limak = 4;
            const int bob = 9;
            const int expected = 3;
            var actual = BearAndBigBrother.GetsValue(limak, bob);
            actual.ShouldBe(expected);
        }

        [Fact]
        public void ReturnsExpectedValueTestCase03()
        {
            const int limak = 1;
            const int bob = 1;
            const int expected = 1;
            var actual = BearAndBigBrother.GetsValue(limak, bob);
            actual.ShouldBe(expected);
        }
    }
}