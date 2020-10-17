using System.Collections.Generic;
using CSharp.Library.SinglyLinkedList;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Removes the Nth node from the end of a linked list.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/reverse-linked-list/
    ///     Source: Interview Cake
    ///     https://www.interviewcake.com/question/csharp/kth-to-last-node-in-singly-linked-list
    /// </summary>
    public static class RemoveNthNodeFromEndOfLinkedList<TData>
    {
        /// <summary>
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n) (taking O(n) space on the call stack due to recursion).
        /// </summary>
        public static Node<TData> RecursiveImplementation(Node<TData> head, int n)
        {
            int index;

            void Traverse(Node<TData> currentNode)
            {
                if (currentNode.Next == null)
                {
                    index = 1;
                    return;
                }

                Traverse(currentNode.Next);
                index++;
                if (index == n + 1)
                    currentNode.Next = currentNode.Next.Next;
            }

            Traverse(head);
            return n < index ? head : head.Next;
        }

        /// <summary>
        ///     Iterative.
        ///     Queue.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static Node<TData> IterativeImplementation(Node<TData> head, int n)
        {
            var checkpointsHead = -n;
            var checkpointsQueue = new Queue<Node<TData>>();
            var currentNode = head;

            while (currentNode != null)
            {
                ++checkpointsHead;

                checkpointsQueue.Enqueue(currentNode);
                if (checkpointsHead > 1)
                    checkpointsQueue.Dequeue();

                currentNode = currentNode.Next;
            }

            if (checkpointsHead < 1)
                return head.Next;

            currentNode = checkpointsQueue.Dequeue();
            currentNode.Next = currentNode.Next.Next;

            return head;
        }
    }
}