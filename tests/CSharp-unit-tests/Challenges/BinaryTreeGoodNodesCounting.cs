using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinaryTreeGoodNodesCounting : BaseTest
    {
        public BinaryTreeGoodNodesCounting()
        {
            TypeToTest = typeof(CountBinaryTreeGoodNodes);
        }

        private void TestImplementations(BinaryNode<int> rootNode, int expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int?) implementation.Invoke(null, new object[] {rootNode});
                actualResult.ShouldNotBeNull();
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void CorrectlyCountsGoodNodesTestCase01()
        {
            const int expectedResult = 4;
            var binaryTree = BinaryTreeManager.Create(new int?[] {5, 3, 10, 20, 21, 1, null});
            TestImplementations(binaryTree.Root, expectedResult);
        }

        [Fact]
        public void CorrectlyCountsGoodNodesTestCase02()
        {
            const int expectedResult = 2;
            var binaryTree = BinaryTreeManager.Create(new int?[] {8, 2, 6, 8, 7});
            TestImplementations(binaryTree.Root, expectedResult);
        }
    }
}