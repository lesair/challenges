﻿using System;
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
                    PreOrderRecursiveImplementation
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
        ///     Method that represents a node visit.
        /// </summary>
        public static Action<T> OutputCallback { get; set; }

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
        ///     Time complexity:
        ///     Space complexity:
        /// </summary>
        private static void PreOrderRecursiveImplementation(Node<T> node)
        {
            if (node.Data == null)
                return;
            OutputCallback(node.Data);
            foreach (var child in node.Children) // From left to right.
                PreOrder(child);
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
            if (node.Data == null)
                return;
            var halfChildren = node.Children.Count().RoundUpDivideBy(2);
            var leftChildren = node.Children.Take(halfChildren);
            var rightChildren = node.Children.Skip(halfChildren);
            foreach (var child in leftChildren)
                InOrder(child);
            OutputCallback(node.Data);
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
            if (node.Data == null)
                return;
            foreach (var child in node.Children) // From left to right.
                PostOrder(child);
            OutputCallback(node.Data);
        }
    }
}