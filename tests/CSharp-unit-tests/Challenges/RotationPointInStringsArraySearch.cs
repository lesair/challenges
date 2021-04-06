using System.Collections.Generic;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class RotationPointInStringsArraySearch : BaseTest
    {
        public RotationPointInStringsArraySearch()
        {
            TypeToTest = typeof(FindRotationPointInStringsArray);
        }

        private void TestImplementations(IEnumerable<string> strings, int expected)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var invocationResult = (int?) implementation.Invoke(null, new object[] {strings});
                invocationResult.ShouldNotBeNull();
                var actual = invocationResult.Value;
                actual.ShouldBe(expected);
            }
        }

        [Fact]
        public void CorrectlyReturnsTheRotationPointIndexTestCase01()
        {
            var strings = new[]
            {
                "ptolemaic",
                "retrograde",
                "supplant",
                "undulate",
                "xenoepist",
                "asymptote", // <-- rotates here!
                "babka",
                "banoffee",
                "engender",
                "karpatka",
                "othellolagkage"
            };
            const int expected = 5;
            TestImplementations(strings, expected);
        }


        [Fact]
        public void CorrectlyReturnsTheRotationPointIndexTestCase02()
        {
            var strings = new[]
            {
                "ptolemaic"
            };
            const int expected = 0;
            TestImplementations(strings, expected);
        }

        [Fact]
        public void CorrectlyReturnsTheRotationPointIndexTestCase03()
        {
            var strings = new[]
            {
                "asymptote",
                "babka",
                "banoffee",
                "engender",
                "karpatka",
                "othellolagkage",
                "ptolemaic",
                "retrograde",
                "supplant",
                "undulate",
                "xenoepist"
            };
            const int expected = 0;
            TestImplementations(strings, expected);
        }
    }
}