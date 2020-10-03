using CSharp.Challenges;
using CSharp.Library.SinglyLinkedList;
using Shouldly;
using Xunit;

namespace CSharp
{
    public class LinkedListCycleSearch : BaseTest
    {
        public LinkedListCycleSearch()
        {
            TypeToTest = typeof(DetermineIfLinkedListHasACycle);
        }

        private void TestImplementations(Node<int> head, bool expectedResult)
        {
            foreach (var implementation in ImplementationsToTest())
            {
                var actualResult = (bool) implementation.Invoke(null, new object[] {head});
                actualResult.ShouldBe(expectedResult);
            }
        }

        [Fact]
        public void ReturnsFalseForASingleNodeLinkedList()
        {
            var linkedListManager = new SinglyLinkedListManager<int>();
            var headNode = linkedListManager.Create(new[] {1});
            const bool expectedResult = false;
            TestImplementations(headNode, expectedResult);
        }

        [Fact]
        public void ReturnsFalseWhenLinkedListIsNull()
        {
            const bool expectedResult = false;
            TestImplementations(null, expectedResult);
        }


        [Fact]
        public void ReturnsFalseWhenThereAreNoCycles()
        {
            var linkedListManager = new SinglyLinkedListManager<int>();
            var headNode = linkedListManager.Create(new[] {3, 2, 0, -4});
            const bool expectedResult = false;
            TestImplementations(headNode, expectedResult);
        }

        [Fact]
        public void ReturnsTrueWhenThereIsACycle()
        {
            var linkedListManager = new SinglyLinkedListManager<int>();
            var headNode = linkedListManager.Create(new[] {3, 2, 0, -4});
            linkedListManager["-4"].Next = linkedListManager["2"];
            const bool expectedResult = true;
            TestImplementations(headNode, expectedResult);
        }
    }
}