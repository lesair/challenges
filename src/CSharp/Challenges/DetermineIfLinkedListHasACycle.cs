using CSharp.Library.SinglyLinkedList;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Given the head of a linked list, determine if the linked list has a cycle in it.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/linked-list-cycle/
    ///     Source: HackerRank
    ///     https://youtu.be/MFOAbpfrJ8g
    ///     Source: Alan Chávez
    ///     https://youtu.be/0fpcIuvcRI0?t=211
    /// </summary>
    public static class DetermineIfLinkedListHasACycle
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static bool Implementation(Node<int> head)
        {
            var fastTraverse = head?.Next;
            var slowTraverse = head;
            while (fastTraverse != null && slowTraverse != null)
            {
                if (fastTraverse == slowTraverse || fastTraverse.Next == slowTraverse)
                    return true;
                fastTraverse = fastTraverse.Next?.Next;
                slowTraverse = slowTraverse.Next;
            }

            return false;
        }
    }
}