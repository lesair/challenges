using System.Collections.Generic;
using CSharp.Challenges;
using CSharp.Library.SinglyLinkedList;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class KGroupReversal : BaseTest
    {
        public KGroupReversal()
        {
            TypeToTest = typeof(ReverseKGroup);
        }

        private void TestImplementations(int k, IReadOnlyCollection<int> linkedListData,
            IReadOnlyCollection<int> expectedReversedListData)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var headNode = new SinglyLinkedListManager<int>().Create(linkedListData);
                var reversedListHeadNode = (Node<int>)implementation.Invoke(null, new object[] { headNode, k });
                var actualReversedListData = SinglyLinkedListManager<int>.GetData(reversedListHeadNode);
                actualReversedListData.ShouldBe(expectedReversedListData);
            }
        }

        [Fact]
        public void DoesNotReverseBecauseKLargerThanList()
        {
            const int k = 5;
            var linkedListData = new[] { 1, 2, 3 };
            var expectedReversedListData = new[] { 1, 2, 3 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void DoesNotReverseBecauseKIsOne()
        {
            const int k = 1;
            var linkedListData = new[] { 1, 2, 3, 4, 5 };
            var expectedReversedListData = new[] { 1, 2, 3, 4, 5 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void DoesNotReverseBecauseListHasOneNode()
        {
            const int k = 1;
            var linkedListData = new[] { 5 };
            var expectedReversedListData = new[] { 5 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void CorrectlyReversesALinkedListForKEqualsToListLength()
        {
            const int k = 5;
            var linkedListData = new[] { 1, 2, 3, 4, 5 };
            var expectedReversedListData = new[] { 5, 4, 3, 2, 1 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void CorrectlyReversesALinkedListKFitsOnce()
        {
            const int k = 3;
            var linkedListData = new[] { 1, 2, 3, 4, 5 };
            var expectedReversedListData = new[] { 3, 2, 1, 4, 5 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void CorrectlyReversesALinkedListKFitsTwice()
        {
            const int k = 2;
            var linkedListData = new[] { 1, 2, 3, 4, 5 };
            var expectedReversedListData = new[] { 2, 1, 4, 3, 5 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }

        [Fact]
        public void CorrectlyReversesALinkedListManyTimes()
        {
            const int k = 3;
            var linkedListData = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var expectedReversedListData = new[] { 3, 2, 1, 6, 5, 4, 9, 8, 7, 12, 11, 10 };
            TestImplementations(k, linkedListData, expectedReversedListData);
        }
    }
}