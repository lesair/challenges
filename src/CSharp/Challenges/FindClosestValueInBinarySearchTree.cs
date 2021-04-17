using System;
using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Source: GeeksforGeeks.
    ///     https://www.geeksforgeeks.org/find-closest-element-binary-search-tree/
    /// </summary>
    public static class FindClosestValueInBinarySearchTree
    {
        /// <summary>
        ///     Recursive.
        ///     Time complexity: O(h).
        ///     Space complexity: O(h) (space in the call stack due to recursion).
        /// </summary>
        public static int RecursiveImplementation(BinaryNode<int> root, int target)
        {
            int FindClosestValue(BinaryNode<int> node, int? closestValueSoFar)
            {
                switch (node)
                {
                    case null when closestValueSoFar == null:
                        throw new InvalidOperationException();
                    case null:
                        return closestValueSoFar.Value;
                }

                if (node.Data == target)
                    return node.Data;

                var nodeDifference = Math.Abs(node.Data - target);
                if (closestValueSoFar.HasValue)
                {
                    var closestDifferenceSoFar = Math.Abs(closestValueSoFar.Value - target);
                    closestValueSoFar = nodeDifference < closestDifferenceSoFar ? node.Data : closestValueSoFar.Value;
                }
                else
                {
                    closestValueSoFar = node.Data;
                }

                return FindClosestValue(target < node.Data ? node.Left : node.Right, closestValueSoFar);
            }

            return FindClosestValue(root, null);
        }
    }
}