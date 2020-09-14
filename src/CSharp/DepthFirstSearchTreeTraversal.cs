using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CSharp.Library.Extensions;
using CSharp.Library.Tree;

namespace CSharp
{
    public static class DepthFirstSearchTreeTraversal<T>
    {
        public static IEnumerable<Action<Node<T>>> InOrderImplementations
        {
            get
            {
                return new Action<Node<T>>[]
                {
                    InOrderRecursiveImplementation,
                    InOrderIterativeImplementation
                };
            }
        }

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
        ///     Traverses the expression tree.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void Traverse(Node<T> node, Action<Node<T>> implementation = null)
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
        private static void PreOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            Visit(node);
            foreach (var child in node.Children) // From left to right.
                PreOrderRecursiveImplementation(child);
        }

        /// <summary>
        ///     Pre-orderly traversal.
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
        ///     In-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void InOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            var halfChildren = node.Children.Count.RoundUpDivideBy(2);
            var leftChildren = node.Children.Take(halfChildren);
            var rightChildren = node.Children.Skip(halfChildren);
            foreach (var child in leftChildren)
                InOrderRecursiveImplementation(child);
            Visit(node);
            foreach (var child in rightChildren)
                InOrderRecursiveImplementation(child);
        }

        /// <summary>
        ///     In-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void InOrderIterativeImplementation(Node<T> node)
        {
            var stack = new Stack<Node<T>>();
            while (stack.Any() || node != null)
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Children.Any() ? node.Children.First() : null;
                }
                else
                {
                    node = stack.Pop();
                    Visit(node);
                    node = node.Children.Count > 1 ? node.Children.Last() : null;
                }
        }

        /// <summary>
        ///     Post-orderly traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void PostOrderRecursiveImplementation(Node<T> node)
        {
            if (node == null)
                return;
            foreach (var child in node.Children) // From left to right.
                PostOrderRecursiveImplementation(child);
            Visit(node);
        }

        /// <summary>
        ///     Post-orderly traversal.
        ///     Iterative. Stack.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        [SuppressMessage("ReSharper", "HeuristicUnreachableCode")]
        // ReSharper disable once UnusedMember.Local
        private static void PostOrderIterativeImplementation(Node<T> node)
        {
            throw new NotImplementedException(); // TODO: PostOrderIterativeImplementation needs more work.

#pragma warning disable 162
            var stack = new Stack<Node<T>>();
            var last = node;
            while (stack.Any() || node != null)
                if (node != null)
                {
                    // If `last` is right child of `node`, then the right branch is traversed.
                    // Visit `node` and continue with `node`'s parent.
                    if (node.Children.Count > 1 && node.Children.Last() == last)
                    {
                        Visit(node);
                        last = node;
                        node = stack.Pop();
                    }
                    else
                    {
                        stack.Push(node);
                        // If `last` is left child of `node`, then the left branch is traversed.
                        // Continue with `node`'s right branch.
                        if (node.Children.Any() && node.Children.First() == last)
                        {
                            last = node;
                            node = node.Children.Last();
                        }
                        else
                        {
                            last = node;
                            node = node.Children.Any() ? node.Children.First() : null;
                        }
                    }
                }
                else
                {
                    last = node;
                    node = stack.Pop();
                }
#pragma warning restore 162
        }
    }
}