using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Horizontally flip a binary tree given its root node.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/invert-binary-tree/
    /// </summary>
    public static class InvertBinaryTree
    {
        /// <summary>
        ///     Iterative. Breadth-first search traversal.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static BinaryNode<int> IterativeImplementation(BinaryNode<int> root)
        {
            if (root == null)
                return null;

            var queue = new Queue<BinaryNode<int>>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                (currentNode.Left, currentNode.Right) = (currentNode.Right, currentNode.Left);
            }

            return root;
        }

        /// <summary>
        ///     Recursive. Elegant. Breadth-first search traversal.
        ///     Time complexity: O(n).
        ///     Space complexity: O(1).
        /// </summary>
        public static BinaryNode<int> RecursiveImplementation(BinaryNode<int> root)
        {
            if (root == null)
                return null;

            (root.Left, root.Right) = (root.Right, root.Left);
            RecursiveImplementation(root.Left);
            RecursiveImplementation(root.Right);

            return root;
        }
    }
}