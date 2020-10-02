using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.SinglyLinkedList;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class LinkedListReversal : BaseTest
    {
        public LinkedListReversal()
        {
            TypeToTest = typeof(ReverseLinkedList<int>);
        }

        private void TestImplementations(IReadOnlyCollection<int> linkedListData,
            IReadOnlyCollection<int> expectedReversedListData)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var headNode = new SinglyLinkedListManager<int>().Create(linkedListData);
                var reversedListHeadNode = (Node<int>) implementation.Invoke(null, new object[] {headNode});
                var actualReversedListData = SinglyLinkedListManager<int>.GetData(reversedListHeadNode);
                actualReversedListData.ShouldBe(expectedReversedListData);
            }
        }

        [Fact]
        public void CorrectlyReversesALinkedList()
        {
            var linkedListData = new[] {1, 2, 3, 4, 5};
            var expectedReversedListData = new[] {5, 4, 3, 2, 1};
            TestImplementations(linkedListData, expectedReversedListData);
        }

        [Fact]
        public void CorrectlyReversesASingleNodeList()
        {
            var linkedListData = new[] {100};
            var expectedReversedListData = new[] {100};
            TestImplementations(linkedListData, expectedReversedListData);
        }

        [Fact]
        public void ReturnsNullWhenProvidedANullHeadNode()
        {
            var linkedListData = new int[] { };
            var expectedReversedListData = new int[] { };
            TestImplementations(linkedListData, expectedReversedListData);
        }
    }
}