using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Traverses the expression tree in a depth first search way. For the tree being a binary tree, there are three
    ///     traversal orderings possible: pre-order, in-order and post-order.
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public static class TraverseBinaryTreeInDepthFirstSearchWay<T>
    {
        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        public static Action<BinaryNode<T>> Visit { get; set; }

        /// <summary>
        ///     Pre-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static void PreOrderRecursiveImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            Visit(node);
            PreOrderRecursiveImplementation(node.Left);
            PreOrderRecursiveImplementation(node.Right);
        }

        /// <summary>
        ///     Pre-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        /// <param name="node"></param>
        public static void PreOrderIterativeImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            var
                stack = new Stack<BinaryNode<T>>();
            stack.Push(node);
            while (stack.Any())
            {
                node = stack.Pop();
                Visit(node);
                // Child nodes are pushed from right to left, so that they are processed from left to right.
                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);
            }
        }

        /// <summary>
        ///     In-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static void InOrderRecursiveImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            InOrderRecursiveImplementation(node.Left);
            Visit(node);
            InOrderRecursiveImplementation(node.Right);
        }

        /// <summary>
        ///     In-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(h).
        /// </summary>
        public static void InOrderIterativeImplementation(BinaryNode<T> node)
        {
            var stack = new Stack<BinaryNode<T>>();
            while (stack.Any() || node != null)
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    Visit(node);
                    node = node.Right;
                }
        }

        /// <summary>
        ///     Post-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static void PostOrderRecursiveImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            PostOrderRecursiveImplementation(node.Left);
            PostOrderRecursiveImplementation(node.Right);
            Visit(node);
        }

        /// <summary>
        ///     Post-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(h).
        /// </summary>
        public static void PostOrderIterativeImplementation(BinaryNode<T> node)
        {
            var stack = new Stack<BinaryNode<T>>();
            BinaryNode<T> lastNodeVisited = null;
            while (stack.Any() || node != null)
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    // if right child exists and traversing node
                    // from left child, then move right
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        Visit(peekNode);
                        lastNodeVisited = stack.Pop();
                    }
                }
        }
    }
}