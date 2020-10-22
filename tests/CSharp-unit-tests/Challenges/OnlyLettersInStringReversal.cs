using CSharp.Challenges;
using Shouldly;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace CSharp
{
    public class OnlyLettersInStringReversal : BaseTest
    {
        public OnlyLettersInStringReversal()
        {
            TypeToTest = typeof(ReverseOnlyLettersInString);
        }

        private void TestImplementations(string s, string expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (string) implementation.Invoke(null, new object[] {s});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyReversesOnlyLettersTestCase01()
        {
            const string s = "ab-cd";
            const string expectedResult = "dc-ba";
            TestImplementations(s, expectedResult);
        }


        [Fact]
        public void CorrectlyReversesOnlyLettersTestCase02()
        {
            const string s = "a-bC-dEf-ghIj";
            const string expectedResult = "j-Ih-gfE-dCba";
            TestImplementations(s, expectedResult);
        }


        [Fact]
        public void CorrectlyReversesOnlyLettersTestCase03()
        {
            const string s = "Test1ng-Leet=code-Q!";
            const string expectedResult = "Qedo1ct-eeLg=ntse-T!";
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void DoesNotReverseStringWithoutAlphabeticChars()
        {
            const string s = "7_28]";
            const string expectedResult = "7_28]";
            TestImplementations(s, expectedResult);
        }
    }
}