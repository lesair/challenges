using System.Diagnostics.CodeAnalysis;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class StringPalindromicValidation : BaseTest
    {
        public StringPalindromicValidation()
        {
            TypeToTest = typeof(DetermineIfStringIsPalindrome);
        }

        private void TestImplementations(string s, bool expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (bool) implementation.Invoke(null, new object[] {s});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsFalseForNonPalindromicMixedString()
        {
            const string s = "NelEl3n";
            const bool expectedResult = false;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsFalseForNonPalindromicString()
        {
            const string s = "Madam, I'm Adam Corolla.";
            const bool expectedResult = false;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForPalindromicMixedString()
        {
            const string s = "Nel3len";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForPalindromicNumericString()
        {
            const string s = "757";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForPalindromicStringTestCase01()
        {
            const string s = "Eva, can I stab bats in a cave?";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForPalindromicStringTestCase02()
        {
            const string s = "A man, a plan, a canal. Panama!";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForPalindromicStringTestCase03()
        {
            const string s = "Anita lava la tina.";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void ReturnsTrueForPalindromicStringTestCase04()
        {
            const string s =
                "A man, a plan, a canoe, pasta, heros, rajahs, a coloratura, maps, snipe, percale, macaroni, a gag, a banana bag, a tan, a tag, a banana bag again (or a camel), a crepe, pins, Spam, a rut, a Rolo, cash, a jar, sore hats, a peon, a canal >> __Panama__";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForSingleCharacterString()
        {
            const string s = "H";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact(Skip = "For the moment, testing for Unicode code points is out of scope.")]
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        public void ReturnsTrueForTheCodePointsTest()
        {
            const string s = "Les Mise\u0301rables selbarésim sel";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact(Skip = "For the moment, the Turkish test is out of scope.")]
        public void ReturnsTrueForTheTurkishTest()
        {
            const string s = "Ilı";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }
    }
}