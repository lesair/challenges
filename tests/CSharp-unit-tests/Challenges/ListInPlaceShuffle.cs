using System.Collections.Generic;
using System.Linq;
using CSharp.Challenges;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class ListInPlaceShuffle : BaseTest
    {
        public ListInPlaceShuffle()
        {
            TypeToTest = typeof(ShuffleAListInPlace);
        }

        private void TestImplementations(IList<int> originalList)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var list = new List<int>(originalList);
                implementation.Invoke(null, new object[] {list});
                list.Count.ShouldBe(originalList.Count);
                list.ShouldNotBe(originalList);
            }
        }

        [Fact]
        public void ReturnsAUniformlyShuffledList()
        {
            var list = Enumerable.Range(1, 100).ToArray();
            TestImplementations(list);
        }
    }
}