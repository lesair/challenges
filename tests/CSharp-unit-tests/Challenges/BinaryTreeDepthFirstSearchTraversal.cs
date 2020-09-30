using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    /// <summary>
    ///     Visits (checking and/or updating) each node in a tree data structure, exactly once.
    ///     https://en.wikipedia.org/wiki/Tree_traversal
    /// </summary>
    public class BinaryTreeDepthFirstSearchTraversal : BaseTest
    {
        public BinaryTreeDepthFirstSearchTraversal()
        {
            TypeToTest = typeof(TraverseBinaryTreeInDepthFirstSearchWay<char>);

            //           F
            //          / \
            //         /   \
            //        /     \
            //       B       G
            //      / \       \
            //     A   D       I
            //        / \     /
            //       C   E   H
            _binaryTree = BinaryTreeManager.Create(new char?[]
                {'F', 'B', 'G', 'A', 'D', null, 'I', null, null, 'C', 'E', 'H', null});
        }

        private void TestImplementations(BinaryNode<char> node, ICollection<char> expectedTraversal,
            string methodsToTestPrefix)
        {
            ImplementationMethodsPrefix = methodsToTestPrefix;
            foreach (var implementation in ImplementationsToTest())
            {
                var actualTraversal = new List<char>();
                TraverseBinaryTreeInDepthFirstSearchWay<char>.Visit =
                    visitedNode => actualTraversal.Add(visitedNode.Data);
                implementation.Invoke(null, new object[] {node});
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        private readonly BinaryTreeManager<char> _binaryTree;

        [Fact]
        public void IsCorrectlyDoneInInOrder()
        {
            var expectedTraversal = new[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'};
            TestImplementations(_binaryTree.Root, expectedTraversal, "InOrder");
        }

        [Fact]
        public void IsCorrectlyDoneInPostOrder()
        {
            var expectedTraversal = new[] {'A', 'C', 'E', 'D', 'B', 'H', 'I', 'G', 'F'};
            TestImplementations(_binaryTree.Root, expectedTraversal, "PostOrder");
        }

        [Fact]
        public void IsCorrectlyDoneInPreOrder()
        {
            var expectedTraversal = new[] {'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H'};
            TestImplementations(_binaryTree.Root, expectedTraversal, "PreOrder");
        }
    }
}