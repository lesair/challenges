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
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/csharp/linked-list-cycles
    /// </summary>
    public static class DetectCycleInLinkedList
    {
        /// <summary>
        ///     Author: Robert W. Floyd
        ///     https://en.wikipedia.org/wiki/Cycle_detection#Floyd's_Tortoise_and_Hare
        ///     Iterative.
        ///     Time complexity: O(λ + μ).
        ///     Space complexity: O(1).
        /// </summary>
        // ReSharper disable once IdentifierTypo
        public static bool FloydsTortoiseAndHareImplementation(Node<int> head)
        {
            var hare = head?.Next;
            var tortoise = head;
            while (hare != null && tortoise != null)
            {
                if (hare == tortoise || hare.Next == tortoise)
                    return true;
                hare = hare.Next?.Next;
                tortoise = tortoise.Next;
            }

            return false;
        }
    }
}