using System;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Count the number of good nodes in the binary tree.
    ///     A node X in the tree is named good if in the path from root to X there are no nodes with a value greater than X.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/count-good-nodes-in-binary-tree/submissions/
    /// </summary>
    public static class CountBinaryTreeGoodNodes
    {
        /// <summary>
        ///     Recursive. Pre-orderly binary tree traversal.
        ///     Time complexity: O(n).
        ///     Space complexity: O(h).
        /// </summary>
        public static int RecursiveImplementation(BinaryNode<int> tree)
        {
            var counter = 0;

            void TraverseTree(BinaryNode<int> node, int max)
            {
                if (node == null)
                    return;

                if (node.Data >= max)
                {
                    counter++;
                    max = Math.Max(max, node.Data);
                }

                TraverseTree(node.Left, max);
                TraverseTree(node.Right, max);
            }

            TraverseTree(tree, tree.Data);

            return counter;
        }

        // TODO: Iterative implementation.
    }
}