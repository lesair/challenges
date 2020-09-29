using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class MatchingParenthesesValidation : BaseTest
    {
        public MatchingParenthesesValidation()
        {
            TypeToTest = typeof(ValidateMatchingParentheses);
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
        public void ReturnsFalseForNonMatchingParenthesisTestCase01()
        {
            var s = "(]";
            const bool expectedResult = false;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsFalseForNonMatchingParenthesisTestCase02()
        {
            var s = "([)]";
            const bool expectedResult = false;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsFalseForNonMatchingParenthesisTestCase03()
        {
            var s = "{{{(([]))}}";
            const bool expectedResult = false;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForAnEmptyString()
        {
            var s = string.Empty;
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForValidMatchingParenthesisTestCase01()
        {
            var s = "()";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForValidMatchingParenthesisTestCase02()
        {
            var s = "()[]{}";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }


        [Fact]
        public void ReturnsTrueForValidMatchingParenthesisTestCase03()
        {
            var s = "{[]}";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void ReturnsTrueForValidMatchingParenthesisTestCase04()
        {
            var s = "[[({})]]{{{{((([[]])))}}}}([{}])";
            const bool expectedResult = true;
            TestImplementations(s, expectedResult);
        }
    }
}