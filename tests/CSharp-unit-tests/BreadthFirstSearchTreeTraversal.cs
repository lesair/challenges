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
            _tree = new TreeManager<char?>('F');
            _tree.AddChildrenNodesToParent("F", new char?[] {'B', 'G'});
            _tree.AddChildrenNodesToParent("G", new char?[] {null, 'I'});
            _tree.AddChildrenNodesToParent("B", new char?[] {'A', 'D'});
            _tree.AddChildrenNodesToParent("D", new char?[] {'C', 'E'});
            _tree.AddChildNodeToParent("I", 'H');
        }

        private readonly TreeManager<char?> _tree;

        private static void TestImplementations(Node<char?> node, IList<char?> expectedTraversal,
            IEnumerable<Action<Node<char?>>> implementations)
        {
            foreach (var implementation in implementations)
            {
                var actualTraversal = new List<char?>();
                BreadthFirstSearchTreeTraversal<char?>.Visit = visitedNode => actualTraversal.Add(visitedNode.Data);
                BreadthFirstSearchTreeTraversal<char?>.LevelOrder(node, implementation);
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrder()
        {
            var expectedTraversal = new char?[] {'F', 'B', 'G', 'A', 'D', 'I', 'C', 'E', 'H'};
            TestImplementations(_tree["F"], expectedTraversal,
                BreadthFirstSearchTreeTraversal<char?>.Implementations);
        }
    }
}