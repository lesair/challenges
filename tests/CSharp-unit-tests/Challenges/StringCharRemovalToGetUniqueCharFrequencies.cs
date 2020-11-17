using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class StringCharRemovalToGetUniqueCharFrequencies : BaseTest
    {
        public StringCharRemovalToGetUniqueCharFrequencies()
        {
            TypeToTest = typeof(RemoveMinimumCharsFromStringToGetUniqueCharFrequencies);
        }

        private void TestImplementations(string s, int expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int) implementation.Invoke(null, new object[] {s});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyReturnsMinimumCharsNumberToRemoveTestCase01()
        {
            var s = "aaabbbcc";
            var expectedResult = 2;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void CorrectlyReturnsMinimumCharsNumberToRemoveTestCase02()
        {
            var s = "ceabaacb";
            var expectedResult = 2;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void CorrectlyReturnsMinimumCharsNumberToRemoveTestCase03()
        {
            var s = "zzzzxxxxyyyywwww";
            var expectedResult = 6;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void CorrectlyReturnsMinimumCharsNumberToRemoveTestCase04()
        {
            var s = "qwertyuiop";
            var expectedResult = 9;
            TestImplementations(s, expectedResult);
        }


        [Fact]
        public void CorrectlyReturnsMinimumCharsNumberToRemoveTestCase05()
        {
            var s = "aaaabbbcccdde";
            var expectedResult = 3;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsZeroForStringsWithUniqueCharFrequenciesTestCase01()
        {
            var s = "aab";
            var expectedResult = 0;
            TestImplementations(s, expectedResult);
        }
    }
}