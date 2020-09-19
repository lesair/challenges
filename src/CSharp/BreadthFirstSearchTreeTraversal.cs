using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp
{
    public class BreadthFirstSearchTreeTraversal<T>
    {
        public static IEnumerable<Action<GenericNode<T>>> Implementations
        {
            get
            {
                return new Action<GenericNode<T>>[]
                {
                    LevelOrderIterativeImplementation,
                    LevelOrderRecursiveImplementation
                };
            }
        }

        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        public static Action<GenericNode<T>> Visit { get; set; }

        /// <summary>
        ///     Traverses the expression tree in level-order.
        /// </summary>
        /// <param name="node">Tree's root node start.</param>
        /// <param name="implementation">Algorithm implementation to use.</param>
        public static void LevelOrder(GenericNode<T> node, Action<GenericNode<T>> implementation = null)
        {
            if (implementation == null)
                implementation = LevelOrderIterativeImplementation;

            implementation(node);
        }

        /// <summary>
        ///     Iterative. Queue.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void LevelOrderIterativeImplementation(GenericNode<T> node)
        {
            var queue = new Queue<GenericNode<T>>();
            queue.Enqueue(node);
            while (queue.Any())
            {
                node = queue.Dequeue();
                Visit(node);
                foreach (var child in node.Children) // From left to right.
                    if (child != null)
                        queue.Enqueue(child);
            }
        }

        /// <summary>
        ///     Recursive. LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void LevelOrderRecursiveImplementation(ICollection<GenericNode<T>> levelNodes)
        {
            if (!levelNodes.Any())
                return;

            var nextLevelNodes = new List<GenericNode<T>>();
            foreach (var node in levelNodes) // From left to right.
            {
                Visit(node);
                nextLevelNodes.AddRange(node.Children.Where(child => child != null));
            }

            LevelOrderRecursiveImplementation(nextLevelNodes);
        }

        private static void LevelOrderRecursiveImplementation(GenericNode<T> rootNode)
        {
            LevelOrderRecursiveImplementation(new[] {rootNode});
        }
    }
}