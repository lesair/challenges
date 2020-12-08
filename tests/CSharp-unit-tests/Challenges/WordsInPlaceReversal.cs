using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class WordsInPlaceReversal : BaseTest
    {
        public WordsInPlaceReversal()
        {
            TypeToTest = typeof(ReverseWordsInPlace);
        }

        private void TestImplementations(char[] chars, string expected)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                implementation.Invoke(null, new object[] {chars});
                var actual = new string(chars);
                actual.ShouldBe(expected);
            }
        }

        [Fact]
        public void CorrectlyReversesWordsTestCase01()
        {
            var chars = new[] {'a', 'b', ' ', 'c', 'd'};
            const string expected = "cd ab";
            TestImplementations(chars, expected);
        }

        [Fact]
        public void CorrectlyReversesWordsTestCase02()
        {
            var chars = new[] {'c', 'a', 'k', 'e', ' ', 'p', 'o', 'u', 'n', 'd', ' ', 's', 't', 'e', 'a', 'l'};
            const string expected = "steal pound cake";
            TestImplementations(chars, expected);
        }

        [Fact]
        public void CorrectlyReversesASingleWord()
        {
            var chars = "Hello".ToCharArray();
            const string expected = "Hello";
            TestImplementations(chars, expected);
        }


        [Fact]
        public void CorrectlyReversesASingleChar()
        {
            var chars = new[] {'a'};
            const string expected = "a";
            TestImplementations(chars, expected);
        }

        [Fact]
        public void CorrectlyReversesAnEmptyCharArray()
        {
            var chars = new char[0];
            TestImplementations(chars, string.Empty);
        }
    }
}