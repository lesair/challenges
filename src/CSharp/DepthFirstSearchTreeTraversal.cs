using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp
{
    public static class DepthFirstSearchTreeTraversal<T>
    {
        public static IEnumerable<Action<BinaryNode<T>>> InOrderImplementations
        {
            get
            {
                return new Action<BinaryNode<T>>[]
                {
                    // TODO: An iterative in-order implementation for DepthFirstSearchTreeTraversal.
                    InOrderRecursiveImplementation
                };
            }
        }

        public static IEnumerable<Action<BinaryNode<T>>> PreOrderImplementations
        {
            get
            {
                return new Action<BinaryNode<T>>[]
                {
                    PreOrderRecursiveImplementation,
                    PreOrderIterativeImplementation
                };
            }
        }

        public static IEnumerable<Action<BinaryNode<T>>> PostOrderImplementations
        {
            get
            {
                return new Action<BinaryNode<T>>[]
                {
                    // TODO: An iterative post-order implementation for DepthFirstSearchTreeTraversal.
                    PostOrderRecursiveImplementation
                };
            }
        }

        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        public static Action<BinaryNode<T>> Visit { get; set; }

        /// <summary>
        ///     Traverses the expression tree.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void Traverse(BinaryNode<T> node, Action<BinaryNode<T>> implementation = null)
        {
            if (implementation == null)
                implementation = PreOrderRecursiveImplementation;

            implementation(node);
        }

        /// <summary>
        ///     Pre-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void PreOrderRecursiveImplementation(BinaryNode<T> node)
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
        private static void PreOrderIterativeImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            var stack = new Stack<BinaryNode<T>>();
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
        private static void InOrderRecursiveImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            InOrderRecursiveImplementation(node.Left);
            Visit(node);
            InOrderRecursiveImplementation(node.Right);
        }

        /// <summary>
        ///     Post-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void PostOrderRecursiveImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;
            PostOrderRecursiveImplementation(node.Left);
            PostOrderRecursiveImplementation(node.Right);
            Visit(node);
        }
    }
}