using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Extensions;
using CSharp.Library.Tree;

namespace CSharp
{
    public static class DepthFirstSearchTreeTraversal<T>
    {
        public static IEnumerable<Action<Node<T>>> PreOrderImplementations
        {
            get
            {
                return new Action<Node<T>>[]
                {
                    PreOrderRecursiveImplementation,
                    PreOrderIterativeImplementation
                };
            }
        }

        public static IEnumerable<Action<Node<T>>> InOrderImplementations
        {
            get
            {
                return new Action<Node<T>>[]
                {
                    InOrderRecursiveImplementation
                };
            }
        }

        public static IEnumerable<Action<Node<T>>> PostOrderImplementations
        {
            get
            {
                return new Action<Node<T>>[]
                {
                    PostOrderRecursiveImplementation
                };
            }
        }

        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        public static Action<Node<T>> Visit { get; set; }

        /// <summary>
        ///     Traverses the expression tree pre-orderly.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void PreOrder(Node<T> node, Action<Node<T>> implementation = null)
        {
            if (implementation == null)
                implementation = PreOrderRecursiveImplementation;

            implementation(node);
        }

        /// <summary>
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void PreOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            Visit(node);
            foreach (var child in node.Children) // From left to right.
                PreOrder(child);
        }

        /// <summary>
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        /// <param name="node"></param>
        private static void PreOrderIterativeImplementation(Node<T> node)
        {
            if (node == null)
                return;
            var stack = new Stack<Node<T>>();
            stack.Push(node);
            while (stack.Any())
            {
                node = stack.Pop();
                Visit(node);
                // Child nodes are pushed from right to left, so that they are processed from left to right.
                for (var i = node.Children.Count - 1; i >= 0; i--)
                    if (node.Children[i] != null)
                        stack.Push(node.Children[i]);
            }
        }

        /// <summary>
        ///     Traverses the expression tree in-orderly.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void InOrder(Node<T> node, Action<Node<T>> implementation = null)
        {
            if (implementation == null)
                implementation = InOrderRecursiveImplementation;

            implementation(node);
        }

        /// <summary>
        ///     Recursive.
        ///     Time complexity:
        ///     Space complexity:
        /// </summary>
        private static void InOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            var halfChildren = node.Children.Count.RoundUpDivideBy(2);
            var leftChildren = node.Children.Take(halfChildren);
            var rightChildren = node.Children.Skip(halfChildren);
            foreach (var child in leftChildren)
                InOrder(child);
            Visit(node);
            foreach (var child in rightChildren)
                InOrder(child);
        }

        /// <summary>
        ///     Traverses the expression tree post-orderly.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void PostOrder(Node<T> node, Action<Node<T>> implementation = null)
        {
            if (implementation == null)
                implementation = PostOrderRecursiveImplementation;

            implementation(node);
        }

        /// <summary>
        ///     Recursive.
        ///     Time complexity:
        ///     Space complexity:
        /// </summary>
        private static void PostOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            foreach (var child in node.Children) // From left to right.
                PostOrder(child);
            Visit(node);
        }
    }
}