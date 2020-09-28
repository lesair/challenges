using System.Collections.Generic;
using Shouldly;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace CSharp
{
    public class StringWithUniqueCharactersMaximumLengthSearch : BaseTest
    {
        public StringWithUniqueCharactersMaximumLengthSearch()
        {
            TypeToTest = typeof(FindMaximumLengthOfStringWithUniqueCharacters);
        }

        private void TestImplementations(ICollection<string> strings, int expectedMaximumLength)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualMaximumLength = (int) implementation.Invoke(null, new object[] {strings});
                actualMaximumLength.ShouldBe(expectedMaximumLength);
            }
        }

        [Fact]
        public void ReturnsExpectedLengthForTestCase01()
        {
            var strings = new[] {"un", "iq", "ue"};
            const int expected = 4;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsExpectedLengthForTestCase02()
        {
            var strings = new[] {"cha", "r", "act", "ers"};
            const int expected = 6;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsExpectedLengthForTestCase03()
        {
            var strings = new[] {"a", "abc", "d", "de", "def"};
            const int expected = 6;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsExpectedLengthForTestCase04()
        {
            var strings = new[] {"zog", "nvwsuikgndmfexxgjtkb", "nxko"};
            const int expected = 4;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsExpectedLengthInAReasonableTimeForALargeNumberOfPossibleCombinations()
        {
            var strings = new[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p"};
            const int expected = 16;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsTwentySixForASingleItemConsistingOfAllCharactersInTheAlphabet()
        {
            var strings = new[] {"abcdefghijklmnopqrstuvwxyz"};
            const int expected = 26;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsZeroForAnEmptyArray()
        {
            var strings = new string[0];
            const int expected = 0;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void ReturnsZeroWhenAllItemsContainDuplicatedCharacters()
        {
            var strings = new[] {"yy", "bkhwmpbiisbldzknpm"};
            const int expected = 0;
            TestImplementations(strings, expected);
        }
    }
}