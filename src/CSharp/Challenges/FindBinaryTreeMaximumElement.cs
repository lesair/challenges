using System.Collections.Generic;
using System.Linq;
using CSharp.Library;
using CSharp.Library.Tree;

// ReSharper disable UnusedMember.Local

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: Qualcomm interview (Hayden Thériault).
    ///     Description: Write a function to get the maximum value on a binary tree. The tree is not a search tree, hence it is
    ///     unsorted.
    ///     https://docs.google.com/document/d/15WX_O-Thrqa3_7sc0DH4diy1MgoQAg4WeuS_boirvWo/edit
    ///     Source: GeeksforGeeks
    ///     https://www.geeksforgeeks.org/find-maximum-or-minimum-in-binary-tree/
    /// </summary>
    public static class FindBinaryTreeMaximumElement
    {
        /// <summary>
        ///     Depth-first search pre-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static int? RecursiveImplementation(BinaryNode<int> node)
        {
            if (node == null)
                return null;
            var childMaximumValue = Math.Max(RecursiveImplementation(node.Left), RecursiveImplementation(node.Right));

            return Math.Max(node.Data, childMaximumValue);
        }

        /// <summary>
        ///     Depth-first search pre-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static int? IterativeImplementation(BinaryNode<int> node)
        {
            if (node == null)
                return null;
            int? maximumElement = null;
            var stack = new Stack<BinaryNode<int>>();
            stack.Push(node);
            while (stack.Any())
            {
                node = stack.Pop();
                maximumElement = Math.Max(maximumElement, node.Data);
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }

            return maximumElement;
        }
    }
}