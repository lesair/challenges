using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class StringCharsInPlaceReversal : BaseTest
    {
        public StringCharsInPlaceReversal()
        {
            TypeToTest = typeof(ReverseStringCharsInPlace);
        }

        private void TestImplementations(string originalString, string expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var s = new string(originalString);
                implementation.Invoke(null, new object[] {s});
                s.ShouldBe(expectedResult);
                s.ShouldNotBe(originalString);
            }
        }

        [Fact]
        public void ReturnsAUniformlyShuffledList()
        {
            var s = "steal pound cake";
            const string expected = "ekac dnuop laets";
            TestImplementations(s, expected);
        }
    }
}