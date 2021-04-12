using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.Extensions;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinaryTreeInversion : BaseTest
    {
        public BinaryTreeInversion()
        {
            TypeToTest = typeof(InvertBinaryTree);
        }

        private void TestImplementations(IReadOnlyCollection<int?> nodesData, IReadOnlyCollection<int?> expectedResults)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var binaryTree = BinaryTreeManager.Create(nodesData);
                var nodeActualResult = (BinaryNode<int>) implementation.Invoke(null, new object[] {binaryTree.Root});
                var actualResults = new List<int?>();
                TraverseBinaryTreeInBreadthFirstSearchWay<int>.Visit = node => actualResults.Add(node?.Data);
                TraverseBinaryTreeInBreadthFirstSearchWay<int>.IterativeImplementation(nodeActualResult);
                actualResults.TrimTrailingNulls().ShouldBe(expectedResults);
            }
        }

        [Fact]
        public void CorrectlyInvertsABinaryTreeTestCase01()
        {
            var nodesData = new int?[] {4, 2, 7, 1, 3, 6, 9};
            var expectedResults = new int?[] {4, 7, 2, 9, 6, 3, 1};
            TestImplementations(nodesData, expectedResults);
        }

        [Fact]
        public void CorrectlyInvertsABinaryTreeTestCase02()
        {
            var nodesData = new int?[] {2, 1, 3};
            var expectedResults = new int?[] {2, 3, 1};
            TestImplementations(nodesData, expectedResults);
        }

        [Fact]
        public void CorrectlyInvertsABinaryTreeTestCase03()
        {
            var nodesData = new int?[] {2, null, 3};
            var expectedResults = new int?[] {2, 3};
            TestImplementations(nodesData, expectedResults);
        }

        [Fact]
        public void CorrectlyInvertsABinaryTreeTestCase04()
        {
            var nodesData = new int?[] {2, 1};
            var expectedResults = new int?[] {2, null, 1};
            TestImplementations(nodesData, expectedResults);
        }

        [Fact]
        public void CorrectlyInvertsABinaryTreeTestCase05()
        {
            var nodesData = new int?[] {4, 2, null, 1};
            var expectedResults = new int?[] {4, null, 2, null, 1};
            TestImplementations(nodesData, expectedResults);
        }

        [Fact]
        public void CorrectlyInvertsAnEmptyBinaryTree()
        {
            var nodesData = new int?[0];
            var expectedResults = new int?[0];
            TestImplementations(nodesData, expectedResults);
        }
    }
}