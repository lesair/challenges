using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Find the kth smallest element in a binary search tree.
    ///     Source: Leet Code.
    ///     https://leetcode.com/problems/kth-smallest-element-in-a-bst/
    /// </summary>
    public static class FindBinarySearchTreeKthSmallestElement
    {
        /// <summary>
        ///     Recursive.
        ///     In-orderly traversal.
        ///     Time complexity: O(k).
        ///     Space complexity: O(k) (space in the call stack due to recursion).
        /// </summary>
        public static int? RecursiveImplementation(BinaryNode<int> node, int k)
        {
            int? result = null;

            void TraverseInOrder(BinaryNode<int> currentNode)
            {
                if (currentNode == null)
                    return;
                TraverseInOrder(currentNode.Left);
                if (k < 0) return;
                if (--k == 0)
                {
                    result = currentNode.Data;
                    return;
                }

                TraverseInOrder(currentNode.Right);
            }

            TraverseInOrder(node);
            return result;
        }

        /// <summary>
        ///     Iterative. Stack.
        ///     In-orderly traversal.
        ///     Time complexity: O(k).
        ///     Space complexity: O(k).
        /// </summary>
        public static int? IterativeImplementation(BinaryNode<int> node, int k)
        {
            int? result = null;
            var stack = new Stack<BinaryNode<int>>();
            while (k > 0 && (stack.Any() || node != null))
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    if (--k == 0) result = node.Data;

                    node = node.Right;
                }

            return result;
        }
    }
}