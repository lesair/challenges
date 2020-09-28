using System.Collections.Generic;
using System.Linq;
using CSharp.Library;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/find-largest-value-in-each-tree-row/
    /// </summary>
    public static class FindBinaryTreeMaximumElementsByLevel
    {
        /// <summary>
        ///     Breadth-first search level-order traversal.
        ///     Iterative. Queue.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<int> IterativeImplementation(BinaryNode<int> node)
        {
            var queue = new Queue<BinaryNode<int>>();
            queue.Enqueue(node);
            var currentLevelSize = 1;
            var nextLevelSize = 0;
            int? levelMaximumElement = null;
            while (queue.Any())
            {
                node = queue.Dequeue();
                currentLevelSize--;
                if (node != null)
                {
                    levelMaximumElement = Math.Max(levelMaximumElement, node.Data);
                    queue.Enqueue(node.Left);
                    queue.Enqueue(node.Right);
                    nextLevelSize += 2;
                }

                if (currentLevelSize >= 1) continue;

                if (levelMaximumElement.HasValue)
                    yield return levelMaximumElement.Value;
                currentLevelSize = nextLevelSize;
                nextLevelSize = 0;
                levelMaximumElement = null;
            }
        }

        /// <summary>
        ///     Breadth-first search level-order traversal.
        ///     Recursive.
        ///     Time complexity: O(n).
        ///     Space complexity: O(n).
        /// </summary>
        public static IEnumerable<int> RecursiveImplementation(BinaryNode<int> node)
        {
            var maximumElements = new List<int>();

            void FindMaximumElements(ICollection<BinaryNode<int>> levelNodes)
            {
                if (!levelNodes.Any())
                    return;

                var nextLevelNodes = new List<BinaryNode<int>>();

                int? maximumElement = null;
                foreach (var levelNode in levelNodes)
                {
                    if (levelNode == null)
                        continue;
                    maximumElement = Math.Max(maximumElement, levelNode.Data);
                    if (levelNode.Left != null) nextLevelNodes.Add(levelNode.Left);
                    if (levelNode.Right != null) nextLevelNodes.Add(levelNode.Right);
                }

                if (maximumElement.HasValue)
                    maximumElements.Add(maximumElement.Value);
                FindMaximumElements(nextLevelNodes);
            }

            FindMaximumElements(new[] {node});
            return maximumElements;
        }
    }
}