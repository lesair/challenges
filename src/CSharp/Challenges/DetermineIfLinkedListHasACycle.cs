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
            var fastTraverse = head;
            var slowTraverse = head;
            var timing = 0;
            while (fastTraverse != null && slowTraverse != null)
            {
                fastTraverse = fastTraverse.Next;
                if (timing > 0 && timing % 2 == 0)
                {
                    slowTraverse = slowTraverse.Next;
                    if (fastTraverse == slowTraverse)
                        return true;
                }

                timing++;
            }

            return false;
        }
    }
}