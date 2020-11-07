using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinarySearchTreeSecondMaximumElementSearch : BaseTest
    {
        public BinarySearchTreeSecondMaximumElementSearch()
        {
            TypeToTest = typeof(FindBinarySearchTreeSecondLargestElement);
        }

        private void TestImplementations(BinaryNode<int> node, int? expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int?) implementation.Invoke(null, new object[] {node});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsNullTestCase01()
        {
            //           2
            var binarySearchTree = BinaryTreeManager.Create(new int?[] {2});

            TestImplementations(binarySearchTree.Root, null);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase01()
        {
            //           2
            //          / \
            //         /   \
            //       -2     5
            //             / \
            //            3   7
            var binarySearchTree = BinaryTreeManager.Create(new int?[] {2, -2, 5, null, null, 3, 7});

            const int expectedResult = 5;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase02()
        {
            //           2
            //          / \
            //         /   \
            //       -2     5
            var binarySearchTree = BinaryTreeManager.Create(new int?[] {2, -2, 5});

            const int expectedResult = 2;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase03()
        {
            //           5
            //          / \
            //         /   \
            //        3     8
            //       / \   / \
            //      1   4 7   12
            //               /
            //              10
            //             /  \
            //            9   11
            var binarySearchTree = BinaryTreeManager.Create(new int?[]
                {5, 3, 8, 1, 4, 7, 12, null, null, null, null, null, null, 10, null, 9, 11});

            const int expectedResult = 11;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase04()
        {
            //           50
            //          /
            //         25
            //        /
            //       12
            //         \
            //          24
            var binarySearchTree = BinaryTreeManager.Create(new int?[]
                {50, 25, null, 12, null, null, 24});

            const int expectedResult = 25;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase05()
        {
            //           50
            //          /
            //         25
            //        /  \
            //       12  37
            //          /  \
            //         27  49
            //        /  \
            //       26  36
            var binarySearchTree = BinaryTreeManager.Create(new int?[]
                {50, 25, null, 12, 37, null, null, 27, 49, 26, 36});

            const int expectedResult = 49;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase06()
        {
            //           25
            //             \
            //             50
            //            /
            //           37
            var binarySearchTree = BinaryTreeManager.Create(new int?[]
                {25, null, 50, 37, null});

            const int expectedResult = 37;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }

        [Fact]
        public void ReturnsSecondMaximumElementTestCase07()
        {
            //          -2
            //          / \
            //         /   \
            //       -4    -1
            var binarySearchTree = BinaryTreeManager.Create(new int?[] {-2, -4, -1});

            const int expectedResult = -2;
            TestImplementations(binarySearchTree.Root, expectedResult);
        }
    }
}