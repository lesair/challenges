using CSharp.Library.SinglyLinkedList;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Reverses a singly linked list.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    public static class ReverseSinglyLinkedList<TData>
    {
        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static Node<TData> IterativeImplementation(Node<TData> currentNode)
        {
            Node<TData> previousNode = null;
            var nextNode = currentNode?.Next;

            while (currentNode != null)
            {
                currentNode.Next = previousNode;

                previousNode = currentNode;
                currentNode = nextNode;
                nextNode = currentNode?.Next;
            }

            return previousNode;
        }

        /// <summary>
        ///     Recursive. Elegant.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static Node<TData> ReverseList(Node<TData> currentNode)
        {
            if (currentNode?.Next == null)
                return currentNode;

            var tailNode = ReverseList(currentNode.Next);
            currentNode.Next.Next = currentNode;
            currentNode.Next = null;

            return tailNode;
        }
    }
}