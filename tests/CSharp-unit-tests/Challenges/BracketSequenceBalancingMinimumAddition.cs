using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BracketSequenceBalancingMinimumAddition : BaseTest
    {
        public BracketSequenceBalancingMinimumAddition()
        {
            TypeToTest = typeof(AddMinimumToBalanceBracketSequence);
        }

        private void TestImplementations(string s, (int minToAdd, string balanced) expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var (actualMinToAdd, actualBalanced) =
                    ((int minToAdd, string balanced)) implementation.Invoke(null, new object[] {s});
                actualMinToAdd.ShouldBe(expectedResult.minToAdd);
                actualBalanced.ShouldBe(expectedResult.balanced);
            }
        }

        [Fact]
        public void AddsTheMinimumNumberOfParenthesesToBalanceTheSequenceTestCase01()
        {
            var s = "())";
            var expectedResult = (minToAdd: 1, balanced: "(())");
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void AddsTheMinimumNumberOfParenthesesToBalanceTheSequenceTestCase02()
        {
            var s = "(((";
            var expectedResult = (minToAdd: 3, balanced: "((()))");
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void AddsTheMinimumNumberOfParenthesesToBalanceTheSequenceTestCase03()
        {
            var s = "()))((";
            var expectedResult = (minToAdd: 4, balanced: "((()))(())");
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void AddsTheMinimumNumberOfParenthesesToBalanceTheSequenceTestCase04()
        {
            var s = ")(";
            var expectedResult = (minToAdd: 2, balanced: "()()");
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void AddsTheMinimumNumberOfParenthesesToBalanceTheSequenceTestCase05()
        {
            var s = "()()(()()()";
            var expectedResult = (minToAdd: 1, balanced: "()()(()()())");
            TestImplementations(s, expectedResult);
        }

        [Fact]
        public void DoesNotAddToAnAlreadyBalancedSequence()
        {
            var s = "()";
            var expectedResult = (minToAdd: 0, balanced: "()");
            TestImplementations(s, expectedResult);
        }
    }
}