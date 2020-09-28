using System;
using CSharp.Library.Extensions;
using Shouldly;
using Xunit;

// ReSharper disable StringLiteralTypo

namespace CSharp
{
    public class HasRepeatedCharactersExtension : BaseTest
    {
        public HasRepeatedCharactersExtension()
        {
            TypeToTest = typeof(StringExtensions);
        }

        private void TestImplementations(string s, bool expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (bool) implementation.Invoke(null, new object[] {s});
                actualResult.ShouldBe(expectedResult);
            }
        }

        private void TestImplementationsThrow<T>(string s) where T : Exception
        {
            foreach (var implementation in ImplementationsToTest())
                Assert.Throws<T>(() => (bool) implementation.Invoke(null, new object[] {s}));
        }

        [Fact]
        public void ReturnsFalseBecauseIsNotCaseSensitive()
        {
            const bool expected = false;
            TestImplementations("abcdefghiIjkmnlopqrstuvwxyz", expected);
        }

        [Fact]
        public void ReturnsFalseWithEmptyStrings()
        {
            const bool expected = false;
            TestImplementations("", expected);
        }

        [Fact]
        public void ReturnsFalseWithoutDuplicatedCharacters()
        {
            const bool expected = false;
            TestImplementations("abcdefghijkmnlopqrstuvwxyz", expected);
        }

        [Fact]
        public void ReturnsTrueWithDuplicatedCharacters()
        {
            const bool expected = true;
            TestImplementations("abcdefghijkmnlopqrstuvwxybz", expected);
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenStringIsNull()
        {
            TestImplementationsThrow<ArgumentNullException>(null);
        }
    }
}