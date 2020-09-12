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
            _tree = new TreeManager<char?>('F');
            _tree.AddChildrenNodesToParent("F", new char?[] {'B', 'G'});
            _tree.AddChildrenNodesToParent("G", new char?[] {null, 'I'});
            _tree.AddChildrenNodesToParent("B", new char?[] {'A', 'D'});
            _tree.AddChildrenNodesToParent("D", new char?[] {'C', 'E'});
            _tree.AddChildNodeToParent("I", 'H');
        }

        private static void TestImplementations(Node<char?> node, IList<char?> expectedTraversal,
            IEnumerable<Action<Node<char?>>> implementations)
        {
            foreach (var implementation in implementations)
            {
                var actualTraversal = new List<char?>();
                DepthFirstSearchTreeTraversal<char?>.Visit = node => actualTraversal.Add(node.Data);
                implementation(node);
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        private readonly TreeManager<char?> _tree;

        [Fact]
        public void IsCorrectlyDoneInInOrder()
        {
            var expectedTraversal = new char?[] {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'};
            TestImplementations(_tree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.InOrderImplementations);
        }

        [Fact]
        public void IsCorrectlyDoneInPostOrder()
        {
            var expectedTraversal = new char?[] {'A', 'C', 'E', 'D', 'B', 'H', 'I', 'G', 'F'};
            TestImplementations(_tree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.PostOrderImplementations);
        }

        [Fact]
        public void IsCorrectlyDoneInPreOrder()
        {
            var expectedTraversal = new char?[] {'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H'};
            TestImplementations(_tree["F"], expectedTraversal,
                DepthFirstSearchTreeTraversal<char?>.PreOrderImplementations);
        }
    }
}