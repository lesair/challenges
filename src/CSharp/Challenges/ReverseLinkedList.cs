using CSharp.Library.SinglyLinkedList;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Reverses a singly linked list.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
    public static class ReverseLinkedList<TData>
    {
        /// <summary>
        ///     Iterative.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
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
        ///     Recursive. Compact. Elegant.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static Node<TData> RecursiveCompactImplementation(Node<TData> currentNode)
        {
            if (currentNode?.Next == null)
                return currentNode;

            var tailNode = RecursiveCompactImplementation(currentNode.Next);
            currentNode.Next.Next = currentNode;
            currentNode.Next = null;

            return tailNode;
        }

        /// <summary>
        ///     Recursive. Easy to follow.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static Node<TData> RecursiveEasyImplementation(Node<TData> head)
        {
            static Node<TData> Traverse(Node<TData> previousNode, Node<TData> currentNode)
            {
                if (currentNode == null)
                    return null;

                var nextNode = currentNode.Next;
                currentNode.Next = previousNode;

                return nextNode != null ? Traverse(currentNode, nextNode) : currentNode;
            }

            return Traverse(null, head);
        }
    }
}