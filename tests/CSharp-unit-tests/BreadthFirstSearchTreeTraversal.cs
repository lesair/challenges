using System;
using System.Collections.Generic;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BreadthFirstSearchTreeTraversal
    {
        public BreadthFirstSearchTreeTraversal()
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
            _genericTree = new GenericTreeManager<char?>('F');
            _genericTree.AddChildrenNodesToParent("F", new char?[] {'B', 'G'});
            _genericTree.AddChildrenNodesToParent("G", new char?[] {null, 'I'});
            _genericTree.AddChildrenNodesToParent("B", new char?[] {'A', 'D'});
            _genericTree.AddChildrenNodesToParent("D", new char?[] {'C', 'E'});
            _genericTree.AddChildNodeToParent("I", 'H');
        }

        private readonly GenericTreeManager<char?> _genericTree;

        private static void TestImplementations(Node<char?> genericNode, ICollection<char?> expectedTraversal,
            IEnumerable<Action<Node<char?>>> implementations)
        {
            foreach (var implementation in implementations)
            {
                var actualTraversal = new List<char?>();
                BreadthFirstSearchTreeTraversal<char?>.Visit = visitedNode => actualTraversal.Add(visitedNode.Data);
                BreadthFirstSearchTreeTraversal<char?>.LevelOrder(genericNode, implementation);
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrder()
        {
            var expectedTraversal = new char?[] {'F', 'B', 'G', 'A', 'D', 'I', 'C', 'E', 'H'};
            TestImplementations(_genericTree["F"], expectedTraversal,
                BreadthFirstSearchTreeTraversal<char?>.Implementations);
        }
    }
}