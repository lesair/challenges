using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Traverses the expression tree in level-order.
    ///     https://en.wikipedia.org/wiki/Tree_traversal
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TraverseBinaryTreeInBreadthFirstSearchWay<T>
    {
        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        /// <typeparam name="T">Node data type.</typeparam>
        public static Action<BinaryNode<T>> Visit { get; set; }

        /// <summary>
        ///     Iterative. Queue.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static void IterativeImplementation(BinaryNode<T> node)
        {
            if (node == null)
                return;

            var queue = new Queue<BinaryNode<T>>();
            queue.Enqueue(node);
            while (queue.Any())
            {
                node = queue.Dequeue();
                Visit(node);
                if (node == null)
                    continue;
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
        }

        /// <summary>
        ///     Recursive. LINQ.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        private static void RecursiveImplementation(IReadOnlyCollection<BinaryNode<T>> levelNodes)
        {
            if (!levelNodes.Any())
                return;

            var nextLevelNodes = new List<BinaryNode<T>>();
            foreach (var node in levelNodes) // From left to right.
            {
                Visit(node);
                if (node == null)
                    continue;
                nextLevelNodes.AddRange(node.Children);
            }

            RecursiveImplementation(nextLevelNodes);
        }

        public static void RecursiveImplementation(BinaryNode<T> rootNode)
        {
            if (rootNode == null)
                return;

            RecursiveImplementation(new[] {rootNode});
        }
    }
}