using CSharp.Library.SinglyLinkedList;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Reverses nodes in K-Group
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/reverse-nodes-in-k-group/
    /// </summary>
    public static class ReverseKGroup
    {
        /// <summary>
        ///     Recursive. Easy to follow.
        ///     Multiple pointers manipulation.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static Node<int> RecursiveImplementation(Node<int> head, int k)
        {
            Node<int> JumpNodes(Node<int> node, int jumps)
            {
                var counter = 1;
                do
                {
                    node = node?.Next;
                } while (++counter <= jumps && node != null);

                return node;
            }


            Node<int> Reverse(Node<int> previousNode, Node<int> currentNode, int nodesCounter = 1)
            {
                if (currentNode == null)
                    return null;

                var nextNode = currentNode.Next;
                currentNode.Next = previousNode;

                return nextNode != null && nodesCounter < k
                    ? Reverse(currentNode, nextNode, nodesCounter + 1)
                    : currentNode;
            }

            Node<int> newMainHead = null;
            Node<int> previousTail = null;

            var currentHead = head;

            while (JumpNodes(currentHead, k - 1) != null)
            {
                var nextHead = JumpNodes(currentHead, k);

                var newTail = currentHead;
                var newHead = Reverse(null, currentHead);
                if (previousTail != null)
                    previousTail.Next = newHead;
                newTail.Next = nextHead;
                newMainHead ??= newHead;
                previousTail = newTail;
                currentHead = JumpNodes(newHead, k);
            }

            return newMainHead ?? currentHead;
        }
    }
}