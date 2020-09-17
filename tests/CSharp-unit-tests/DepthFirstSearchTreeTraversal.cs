using System;
using System.Collections.Generic;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    /// <summary>
    ///     Visits (checking and/or updating) each node in a tree data structure, exactly once.
    ///     https://en.wikipedia.org/wiki/Tree_traversal
    /// </summary>
    public class DepthFirstSearchTreeTraversal
    {
        public DepthFirstSearchTreeTraversal()
        {
            //           F
            //          / \
            //         /   \
            //        /     \
            //       B       G
            //      / \       \
            //     A   D       I
            //        / \     /
            //       C   E   H
            _binaryTree = new BinaryTreeManager<char?>('F');
            _binaryTree.AddChildrenNodesToParent("F", 'B', 'G');
            _binaryTree.AddChildrenNodesToParent("G", null, 'I');
            _binaryTree.AddChildrenNodesToParent("B", 'A', 'D');
            _binaryTree.AddChildrenNodesToParent("D", 'C', 'E');
            _binaryTree.AddChildNodeToParent("I", BifurcationIndex.Left, 'H');
        }

        private static void TestImplementations(BinaryNode<char?> node, ICollection<char?> expectedTraversal,
            IEnumerable<Action<BinaryNode<char?>>> implementations)
        {
            foreach (var implementation in implementations)
            {
                var actualTraversal = new List<char?>();
                DepthFirstSearchTreeTraversal<char?>.Visit = visitedNode => actualTraversal.Add(visitedNode.Data);
                DepthFirstSearchTreeTraversal<char?>.Traverse(node, implementation);
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        private readonly BinaryTreeManager<char?> _binaryTree;

        [Fact]
        public void IsCorrectlyDoneInInOrder()
        {
            var expectedTraversal = new char?[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'};
            TestImplementations(_binaryTree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.InOrderImplementations);
        }

        [Fact]
        public void IsCorrectlyDoneInPostOrder()
        {
            var expectedTraversal = new char?[] {'A', 'C', 'E', 'D', 'B', 'H', 'I', 'G', 'F'};
            TestImplementations(_binaryTree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.PostOrderImplementations);
        }

        [Fact]
        public void IsCorrectlyDoneInPreOrder()
        {
            var expectedTraversal = new char?[] {'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H'};
            TestImplementations(_binaryTree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.PreOrderImplementations);
        }
    }
}