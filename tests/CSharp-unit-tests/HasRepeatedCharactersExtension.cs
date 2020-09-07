using System;
using CSharp.Library.Extensions;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class HasRepeatedCharactersExtension
    {
        private static void TestImplementations(string s, bool expected)
        {
            foreach (var implementation in StringExtensions.Implementations)
                s.HasRepeatedCharacters(implementation).ShouldBe(expected);
        }

        private static void TestImplementationsThrow<T>(string s) where T : Exception
        {
            foreach (var implementation in StringExtensions.Implementations)
                Assert.Throws<T>(() => s.HasRepeatedCharacters(implementation));
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