using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace CSharp
{
    public class SubstringPermutationsInStringSearch : BaseTest
    {
        public SubstringPermutationsInStringSearch()
        {
            TypeToTest = typeof(FindPermutationsOfSubstringInString);
        }

        private void TestImplementations(string needle, string haystack, ICollection<string> expectedResults)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResults = (IEnumerable<string>) implementation.Invoke(null, new object[] {needle, haystack});
                actualResults.ShouldBe(expectedResults);
            }
        }

        [Fact]
        public void CorrectlyReturnsSubstringPermutationsTestCase01()
        {
            const string needle = "abbc";
            const string haystack = "bdabcbaacb";
            var expectedResults = new[] {"abcb", "bcba"};
            TestImplementations(needle, haystack, expectedResults);
        }

        [Fact]
        public void CorrectlyReturnsSubstringPermutationsTestCase02()
        {
            const string needle = "abc";
            const string haystack = "abcxyaxbcayxycab";
            var expectedResults = new[] {"abc", "bca", "cab"};
            TestImplementations(needle, haystack, expectedResults);
        }

        [Fact]
        public void CorrectlyReturnsSubstringPermutationsTestCase03()
        {
            const string needle = "si";
            const string haystack = "Mississippi";
            var expectedResults = new[] {"is", "si", "is", "si"};
            TestImplementations(needle, haystack, expectedResults);
        }

        [Fact]
        public void ReturnsNoMatchesWhenSubstringIsEmpty()
        {
            var needle = string.Empty;
            const string haystack = "abdxyaxbdayxydab";
            var expectedResults = new string[0];
            TestImplementations(needle, haystack, expectedResults);
        }

        [Fact]
        public void ReturnsNoMatchesWhenThereAreNoMatches()
        {
            const string needle = "abc";
            const string haystack = "abdxyaxbdayxydab";
            var expectedResults = new string[0];
            TestImplementations(needle, haystack, expectedResults);
        }
    }
}