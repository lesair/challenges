using CSharp.Challenges;
using CSharp.Library.Tree;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class BinarySearchTreeKthSmallestElementSearch : BaseTest
    {
        public BinarySearchTreeKthSmallestElementSearch()
        {
            TypeToTest = typeof(FindBinarySearchTreeKthSmallestElement);

            //           50
            //          /  \
            //         /    \
            //        /      \
            //       25      100
            //      /          \
            //     12          200
            //      \         /
            //      18      150
            //     /  \     /  \
            //    15  21  125  175
            _bigTree = BinaryTreeManager.Create(new int?[]
                {50, 25, 100, 12, null, null, 200, null, 18, 150, null, 15, 21, 125, 175});
        }

        private readonly BinaryTreeManager<int> _bigTree;

        private void TestImplementations(BinaryNode<int> node, int k, int? expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (int?) implementation.Invoke(null, new object[] {node, k});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsEighthSmallestElementOfABigTree()
        {
            const int k = 8;
            const int expectedResult = 125;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsEleventhSmallestElementOfABigTree()
        {
            const int k = 11;
            const int expectedResult = 200;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsFifthSmallestElementOfABigTree()
        {
            const int k = 5;
            const int expectedResult = 25;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsFirstSmallestElementOfABigTree()
        {
            const int k = 1;
            const int expectedResult = 12;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsFirstSmallestElementOfASingleNodeTree()
        {
            //           2
            var binarySearchTree = BinaryTreeManager.Create(new int?[] {2});

            const int k = 1;
            const int expectedResult = 2;

            TestImplementations(binarySearchTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsFourthSmallestElementOfABigTree()
        {
            const int k = 4;
            const int expectedResult = 21;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsNinthSmallestElementOfABigTree()
        {
            const int k = 9;
            const int expectedResult = 150;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsNullWhenKExceedsNumberOfNodes()
        {
            const int k = 12;

            TestImplementations(_bigTree.Root, k, null);
        }

        [Fact]
        public void ReturnsSecondSmallestElementOfABigTree()
        {
            const int k = 2;
            const int expectedResult = 15;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsSeventhSmallestElementOfABigTree()
        {
            const int k = 7;
            const int expectedResult = 100;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsSixthSmallestElementOfABigTree()
        {
            const int k = 6;
            const int expectedResult = 50;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsTenthSmallestElementOfABigTree()
        {
            const int k = 10;
            const int expectedResult = 175;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }

        [Fact]
        public void ReturnsThirdSmallestElementOfABigTree()
        {
            const int k = 3;
            const int expectedResult = 18;

            TestImplementations(_bigTree.Root, k, expectedResult);
        }
    }
}