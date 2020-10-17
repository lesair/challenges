using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.SinglyLinkedList;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class LinkedListNthNodeFromEndRemoval : BaseTest
    {
        public LinkedListNthNodeFromEndRemoval()
        {
            TypeToTest = typeof(RemoveNthNodeFromEndOfLinkedList<int>);
        }

        private void TestImplementations(IReadOnlyCollection<int> inputData, int n,
            IReadOnlyCollection<int> expectedResultData)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var headNode = new SinglyLinkedListManager<int>().Create(inputData);
                var reducedListHeadNode = (Node<int>) implementation.Invoke(null, new object[] {headNode, n});
                var actualResultData = SinglyLinkedListManager<int>.GetData(reducedListHeadNode);
                actualResultData.ShouldBe(expectedResultData);
            }
        }

        [Fact]
        public void CorrectlyRemovesTheExpectedNodeFromTheListTestCase01()
        {
            var inputData = new[] {1, 2, 3, 4, 5};
            const int n = 2;
            var expectedResultData = new[] {1, 2, 3, 5};
            TestImplementations(inputData, n, expectedResultData);
        }

        [Fact]
        public void CorrectlyRemovesTheExpectedNodeFromTheListTestCase02()
        {
            var inputData = new[] {1, 2, 3, 4, 5};
            const int n = 4;
            var expectedResultData = new[] {1, 3, 4, 5};
            TestImplementations(inputData, n, expectedResultData);
        }

        [Fact]
        public void CorrectlyRemovesTheFirstNodeFromTheList()
        {
            var inputData = new[] {1, 2, 3, 4, 5};
            const int n = 5;
            var expectedResultData = new[] {2, 3, 4, 5};
            TestImplementations(inputData, n, expectedResultData);
        }

        [Fact]
        public void CorrectlyRemovesTheLastNodeFromTheList()
        {
            var inputData = new[] {1, 2, 3, 4, 5};
            const int n = 1;
            var expectedResultData = new[] {1, 2, 3, 4};
            TestImplementations(inputData, n, expectedResultData);
        }

        [Fact]
        public void CorrectlyReturnsAnEmptyList()
        {
            var inputData = new[] {1};
            const int n = 1;
            var expectedResultData = new int[0];
            TestImplementations(inputData, n, expectedResultData);
        }
    }
}