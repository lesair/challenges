using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.Extensions;
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
        }

        private void TestImplementations(BinaryNode<char> node, IReadOnlyCollection<char?> expectedTraversal)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualTraversal = new List<char?>();
                TraverseBinaryTreeInBreadthFirstSearchWay<char>.Visit =
                    visitedNode => actualTraversal.Add(visitedNode?.Data);
                implementation.Invoke(null, new object[] {node});
                actualTraversal.TrimTrailingNulls().ShouldBe(expectedTraversal);
            }
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase01()
        {
            var binaryTree = BinaryTreeManager.Create(new char?[0]);
            var expectedTraversal = new char?[0];
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase02()
        {
            //           F
            var binaryTree = BinaryTreeManager.Create(new char?[] {'F'});
            var expectedTraversal = new char?[] {'F'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase03()
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
            var binaryTree = BinaryTreeManager.Create(new char?[]
                {'F', 'B', 'G', 'A', 'D', null, 'I', null, null, 'C', 'E', 'H', null});
            var expectedTraversal = new char?[] {'F', 'B', 'G', 'A', 'D', null, 'I', null, null, 'C', 'E', 'H'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase04()
        {
            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //      / \     / \
            //     A   C   E   G
            var binaryTree = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C', 'E', 'G'});
            var expectedTraversal = new char?[] {'D', 'B', 'F', 'A', 'C', 'E', 'G'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase05()
        {
            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //        \     / \
            //         C   E   G
            var binaryTree = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', null, 'C', 'E', 'G'});
            var expectedTraversal = new char?[] {'D', 'B', 'F', null, 'C', 'E', 'G'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase06()
        {
            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //              / \
            //             E   G
            var binaryTree = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', null, null, 'E', 'G'});
            var expectedTraversal = new char?[] {'D', 'B', 'F', null, null, 'E', 'G'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase07()
        {
            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //                \
            //                 G
            var binaryTree = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', null, null, null, 'G'});
            var expectedTraversal = new char?[] {'D', 'B', 'F', null, null, null, 'G'};
            TestImplementations(binaryTree.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase08()
        {
            var expectedTraversal = new char?[] {'D', 'B', 'F', 'A', 'C', 'E'};

            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //      / \     /
            //     A   C   E
            var binaryTree1 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C', 'E'});
            TestImplementations(binaryTree1.Root, expectedTraversal);

            var binaryTree2 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C', 'E', null});
            TestImplementations(binaryTree2.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase09()
        {
            var expectedTraversal = new char?[] {'D', 'B', 'F', 'A', 'C'};

            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //      / \
            //     A   C
            var binaryTree1 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C'});
            TestImplementations(binaryTree1.Root, expectedTraversal);

            var binaryTree2 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C', null});
            TestImplementations(binaryTree2.Root, expectedTraversal);

            var binaryTree3 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', 'C', null, null});
            TestImplementations(binaryTree3.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase10()
        {
            var expectedTraversal = new char?[] {'D', 'B', 'F', 'A'};

            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //      /
            //     A
            var binaryTree1 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A'});
            TestImplementations(binaryTree1.Root, expectedTraversal);

            var binaryTree2 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', null});
            TestImplementations(binaryTree2.Root, expectedTraversal);

            var binaryTree3 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', null, null});
            TestImplementations(binaryTree3.Root, expectedTraversal);

            var binaryTree4 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', 'A', null, null, null});
            TestImplementations(binaryTree4.Root, expectedTraversal);
        }

        [Fact]
        public void IsCorrectlyDoneInLevelOrderTestCase11()
        {
            var expectedTraversal = new char?[] {'D', 'B', 'F', null, null, 'E'};

            //           D
            //          / \
            //         /   \
            //        /     \
            //       B       F
            //              /
            //             E
            var binaryTree1 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', null, null, 'E'});
            TestImplementations(binaryTree1.Root, expectedTraversal);

            var binaryTree2 = BinaryTreeManager.Create(new char?[] {'D', 'B', 'F', null, null, 'E', null});
            TestImplementations(binaryTree2.Root, expectedTraversal);
        }
    }
}