using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinaryTreeMaximumElementsByLevelSearch : BaseTest
    {
        public BinaryTreeMaximumElementsByLevelSearch()
        {
            TypeToTest = typeof(FindBinaryTreeMaximumElementsByLevel);

            //           1
            //          / \
            //         /   \
            //        3     2
            //       / \     \
            //      5   3     9
            _binaryTree1 = BinaryTreeManager.Create(new int?[] {1, 3, 2, 5, 3, null, 9});

            //           3
            //          /
            //         4
            //          \
            //           5
            //          /
            //         2
            //          \
            //           1
            _binaryTree2 = BinaryTreeManager.Create(new int?[] {3, 4, null, null, 5, 2, null, null, 1});

            //           -9
            //           / \
            //          /   \
            //         /     \
            //       -6     -70
            //       / \     / \
            //     -15 -6  -2  -8
            //             /
            //           -3
            _binaryTree3 = BinaryTreeManager.Create(new int?[] {-9, -6, -70, -15, -6, -2, -8, -3, null});
        }

        private readonly BinaryTreeManager<int> _binaryTree1;
        private readonly BinaryTreeManager<int> _binaryTree2;
        private readonly BinaryTreeManager<int> _binaryTree3;

        private void TestImplementations(BinaryNode<int> node, ICollection<int> expectedMaximumElements)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualMaximumElements = (IEnumerable<int>) implementation.Invoke(null, new object[] {node});
                actualMaximumElements.ShouldBe(expectedMaximumElements);
            }
        }

        [Fact]
        public void ReturnsElementsOfALinkedListLikeTree()
        {
            var expectedMaximumElements = new[] {3, 4, 5, 2, 1};
            TestImplementations(_binaryTree2.Root, expectedMaximumElements);
        }

        [Fact]
        public void ReturnsEmptyWhenTheTreeIsNull()
        {
            var expectedMaximumElements = new int[0];
            TestImplementations(null, expectedMaximumElements);
        }

        [Fact]
        public void ReturnsMaximumElements()
        {
            var expectedMaximumElements = new[] {1, 3, 9};
            TestImplementations(_binaryTree1.Root, expectedMaximumElements);
        }

        [Fact]
        public void ReturnsMaximumElementsOfATreeWithNegativeElements()
        {
            var expectedMaximumElements = new[] {-9, -6, -2, -3};
            TestImplementations(_binaryTree3.Root, expectedMaximumElements);
        }
    }
}