using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Traverses the expression tree in level-order.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TraverseBinaryTreeInBreadthFirstSearchWay<T>
    {
        /// <summary>
        ///     Action to execute when a node is visited.
        /// </summary>
        /// <typeparam name="T">Node data type.</typeparam>
        public static Action<GenericNode<T>> Visit { get; set; }

        /// <summary>
        ///     Iterative. Queue.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static void IterativeImplementation(GenericNode<T> node)
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
        public static void RecursiveImplementation(ICollection<GenericNode<T>> levelNodes)
        {
            if (!levelNodes.Any())
                return;

            var nextLevelNodes = new List<GenericNode<T>>();
            foreach (var node in levelNodes) // From left to right.
            {
                Visit(node);
                nextLevelNodes.AddRange(node.Children.Where(child => child != null));
            }

            RecursiveImplementation(nextLevelNodes);
        }

        public static void RecursiveImplementation(GenericNode<T> rootNode)
        {
            RecursiveImplementation(new[] {rootNode});
        }
    }
}