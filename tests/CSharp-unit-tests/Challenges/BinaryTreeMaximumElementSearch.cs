using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinaryTreeMaximumElementSearch : BaseTest
    {
        public BinaryTreeMaximumElementSearch()
        {
            TypeToTest = typeof(FindBinaryTreeMaximumElement);

            //           5
            //          / \
            //         /   \
            //        4     7
            //         \     \
            //         18     8
            _binaryTree1 = BinaryTreeManager.Create(new int?[] {5, 4, 7, null, 18, null, 8});

            //           -9
            //           / \
            //          /   \
            //         /     \
            //       -6     -70
            //       / \     / \
            //     -15 -6  -2  -8
            //             /
            //           -3
            _binaryTree2 = BinaryTreeManager.Create(new int?[] {-9, -6, -70, -15, -6, -2, -8, -3, null});
        }

        private readonly BinaryTreeManager<int> _binaryTree1;
        private readonly BinaryTreeManager<int> _binaryTree2;

        private void TestImplementations(BinaryNode<int> node, int? expectedMaximumElement)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualMaximumElement = (int?) implementation.Invoke(null, new object[] {node});
                actualMaximumElement.ShouldBe(expectedMaximumElement);
            }
        }

        [Fact]
        public void ReturnsMaximumElement()
        {
            const int expectedMaximumElement = 18;
            TestImplementations(_binaryTree1.Root, expectedMaximumElement);
        }

        [Fact]
        public void ReturnsMaximumElementOfATreeWithNegativeElements()
        {
            const int expectedMaximumElement = -2;
            TestImplementations(_binaryTree2.Root, expectedMaximumElement);
        }

        [Fact]
        public void ReturnsNullWhenTheTreeIsNull()
        {
            TestImplementations(null, null);
        }
    }
}