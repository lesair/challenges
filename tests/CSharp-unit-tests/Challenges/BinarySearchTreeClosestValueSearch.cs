using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinarySearchTreeClosestValueSearch : BaseTest
    {
        public BinarySearchTreeClosestValueSearch()
        {
            TypeToTest = typeof(FindClosestValueInBinarySearchTree);
        }

        private void TestImplementations(BinaryNode<int> node, int target, int expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var invocationResult = (int?)implementation.Invoke(null, new object[] { node, target });
                invocationResult.ShouldNotBe(null);
                var actualResult = invocationResult.Value;
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsClosestValueTestCase01()
        {
            //           9
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 9 });
            const int target = 100;
            const int expectedResult = 9;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase02()
        {
            //           9
            //          / \
            //         /   \
            //        4     17
            //       / \     \
            //      3   6     22
            //         / \   /
            //        5   7 20
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 9, 4, 17, 3, 6, null, 22, null, null, 5, 7, 20 });
            const int target = 4;
            const int expectedResult = 4;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase03()
        {
            //           9
            //          / \
            //         /   \
            //        4     17
            //       / \     \
            //      3   6     22
            //         / \   /
            //        5   7 20
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 9, 4, 17, 3, 6, null, 22, null, null, 5, 7, 20 });
            const int target = 18;
            const int expectedResult = 17;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase04()
        {
            //           9
            //          / \
            //         /   \
            //        4     17
            //       / \     \
            //      3   6     22
            //         / \   /
            //        5   7 20
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 9, 4, 17, 3, 6, null, 22, null, null, 5, 7, 20 });
            const int target = 12;
            const int expectedResult = 9;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase05()
        {
            //           10
            //          /  \
            //         /    \
            //        5     15
            //       / \   /  \
            //      2   5 13  22
            //     /        \
            //    1         14
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 10, 5, 15, 2, 5, 13, 22, 1, null, null, 14 });
            const int target = 12;
            const int expectedResult = 13;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase06()
        {
            //           10
            //          /  \
            //         /    \
            //        5     15
            //       / \   /  \
            //      2   5 13  22
            //     /        \
            //    1         14
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 10, 5, 15, 2, 5, 13, 22, 1, null, null, 14 });
            const int target = 8;
            const int expectedResult = 10;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase07()
        {
            //           10
            //          /  \
            //         /    \
            //        5     15
            //       / \   /  \
            //      2   5 13  22
            //     /        \
            //    1         14
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 10, 5, 15, 2, 5, 13, 22, 1, null, null, 14 });
            const int target = 7;
            const int expectedResult = 5;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }

        [Fact]
        public void ReturnsClosestValueTestCase08()
        {
            //           10
            //          /  \
            //         /    \
            //        3     15
            //       / \   /  \
            //      2   6 13  22
            //     /        \
            //    1         14
            var binarySearchTree = BinaryTreeManager.Create(new int?[] { 10, 3, 15, 2, 6, 13, 22, 1, null, null, 14 });
            const int target = 7;
            const int expectedResult = 6;
            TestImplementations(binarySearchTree.Root, target, expectedResult);
        }
    }
}