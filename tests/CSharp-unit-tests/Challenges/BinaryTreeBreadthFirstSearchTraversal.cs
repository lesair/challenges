using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinaryTreeBreadthFirstSearchTraversal : BaseTest
    {
        public BinaryTreeBreadthFirstSearchTraversal()
        {
            TypeToTest = typeof(TraverseBinaryTreeInBreadthFirstSearchWay<char>);

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

        private readonly BinaryTreeManager<char> _binaryTree;

        private void TestImplementations(BinaryNode<char> node, ICollection<char> expectedTraversal)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualTraversal = new List<char>();
                TraverseBinaryTreeInBreadthFirstSearchWay<char>.Visit =
                    visitedNode => actualTraversal.Add(visitedNode.Data);
                implementation.Invoke(null, new object[] {node});
                actualTraversal.ShouldBe(expectedTraversal);
            }
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrder()
        {
            var expectedTraversal = new[] {'F', 'B', 'G', 'A', 'D', 'I', 'C', 'E', 'H'};
            TestImplementations(_binaryTree.Root, expectedTraversal);
        }
    }
}