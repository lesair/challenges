using CSharp.Library.Tree;

namespace CSharp.Challenges
{
    /// <summary>
    ///     If exists, return the 2nd largest element in a binary search tree, or NULL otherwise.
    ///     Source: Interview Cake.
    ///     https://www.interviewcake.com/question/csharp/second-largest-item-in-bst
    /// </summary>
    public static class FindBinarySearchTreeSecondLargestElement
    {
        /// <summary>
        ///     Recursive.
        ///     Time complexity: O(h) (O(lg n) if the tree is balanced, O(n) otherwise).
        ///     Space complexity: O(h) (space in the call stack due to recursion).
        /// </summary>
        public static int? RecursiveImplementation(BinaryNode<int> node)
        {
            BinaryNode<int> largestNodeParent = null;

            BinaryNode<int> FindLargest(BinaryNode<int> currentNode)
            {
                if (currentNode.Right == null)
                    return currentNode;
                largestNodeParent = currentNode;
                currentNode = FindLargest(currentNode.Right);

                return currentNode;
            }

            var largestNode = FindLargest(node);
            return largestNode.Left == null
                ? largestNodeParent?.Data
                : FindLargest(largestNode.Left).Data;
        }

        /// <summary>
        ///     Iterative.
        ///     Time complexity: O(h) (O(lg n) if the tree is balanced, O(n) otherwise).
        ///     Space complexity: O(1).
        /// </summary>
        public static int? IterativeImplementation(BinaryNode<int> node)
        {
            static (BinaryNode<int> largestNode, BinaryNode<int>parent) FindLargest(BinaryNode<int> currentNode)
            {
                BinaryNode<int> parent = null;
                while (currentNode.Right != null)
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                }

                return (currentNode, parent);
            }

            var (largestNode, largestNodeParent) = FindLargest(node);
            return largestNode.Left == null
                ? largestNodeParent?.Data
                : FindLargest(largestNode.Left).largestNode.Data;
        }
    }
}