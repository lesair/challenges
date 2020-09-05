using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class MaximumLengthUniqueCharactersUnitTests
    {
        private static void TestImplementations(IList<string> strings, int expected)
        {
            foreach (var implementation in MaximumLengthUniqueCharacters.Implementations)
                MaximumLengthUniqueCharacters.MaxLength(strings, implementation).ShouldBe(expected);
        }

        [Fact]
        public void TestCase01()
        {
            var strings = new[] {"un", "iq", "ue"};
            const int expected = 4;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void TestCase02()
        {
            var strings = new[] {"cha", "r", "act", "ers"};
            const int expected = 6;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void TestCase03()
        {
            // ReSharper disable once StringLiteralTypo
            var strings = new[] {"abcdefghijklmnopqrstuvwxyz"};
            const int expected = 26;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void TestCase04()
        {
            // ReSharper disable once StringLiteralTypo
            var strings = new[] {"yy", "bkhwmpbiisbldzknpm"};
            const int expected = 0;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void TestCase05()
        {
            var strings = new[] {"a", "abc", "d", "de", "def"};
            const int expected = 6;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void TestCase06()
        {
            var strings = new string[0];
            const int expected = 0;
            TestImplementations(strings, expected);
        }
    }
}