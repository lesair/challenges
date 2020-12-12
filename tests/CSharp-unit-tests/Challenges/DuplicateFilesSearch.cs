using System.Linq;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    // TODO: Instead of unit tests, functional tests are required for this challenge.
    public class DuplicateFilesSearch
    {
        [Fact]
        public void CorrectlyReturnsTheDuplicatedFiles()
        {
            var rootPath = System.IO.Directory.GetCurrentDirectory();
            var actual = FindDuplicateFiles.GetDuplicates(rootPath).ToList();
            actual.ShouldNotBeEmpty();
        }
    }
}