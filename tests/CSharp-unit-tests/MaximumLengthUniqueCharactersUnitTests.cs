using Shouldly;
using Xunit;

namespace CSharp
{
    public class MaximumLengthUniqueCharactersUnitTests
    {
        [Fact]
        public void TestCase01()
        {
            var arr = new[] {"un", "iq", "ue"};
            const int expectedMagLength = 4;
            MaximumLengthUniqueCharacters.MaxLength(arr).ShouldBe(expectedMagLength);
        }

        [Fact]
        public void TestCase02()
        {
            var arr = new[] {"cha", "r", "act", "ers"};
            const int expectedMagLength = 6;
            MaximumLengthUniqueCharacters.MaxLength(arr).ShouldBe(expectedMagLength);
        }

        [Fact]
        public void TestCase03()
        {
            var arr = new[] {"abcdefghijklmnopqrstuvwxyz"};
            const int expectedMagLength = 26;
            MaximumLengthUniqueCharacters.MaxLength(arr).ShouldBe(expectedMagLength);
        }

        [Fact]
        public void TestCase04()
        {
            var arr = new[] {"yy", "bkhwmpbiisbldzknpm"};
            const int expectedMagLength = 0;
            MaximumLengthUniqueCharacters.MaxLength(arr).ShouldBe(expectedMagLength);
        }

        [Fact]
        public void TestCase05()
        {
            var arr = new[] {"a", "abc", "d", "de", "def"};
            const int expectedMagLength = 6;
            MaximumLengthUniqueCharacters.MaxLength(arr).ShouldBe(expectedMagLength);
        }
    }
}