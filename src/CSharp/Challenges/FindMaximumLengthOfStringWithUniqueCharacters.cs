﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Library.Extensions;

namespace CSharp.Challenges
{
    /// <summary>
    ///     Gets the maximum length of a string that results from the concatenation of a sub-sequence of strings which have
    ///     unique characters.
    ///     Source: LeetCode
    ///     https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/
    ///     Source: Kevin Naughton Jr.
    ///     https://youtu.be/pD3cHFNyW2I
    /// </summary>
    public static class FindMaximumLengthOfStringWithUniqueCharacters
    {
        /// <summary>
        ///     Recursive. Depth-first search.
        ///     The recursion tree is a bifurcating arborescence. The left child traverses a string concatenation that is based on
        ///     the current string node plus the next node, while the right child traverses concatenations based on the current
        ///     node without the next node.
        ///     TODO: Calculate MaxLengthRecursiveBinaryTreeImplementation time and space complexities.
        ///     Time complexity: Θ(?).
        ///     Space complexity: Θ(?).
        /// </summary>
        public static int RecursiveBinaryTreeImplementation(ICollection<string> strings)
        {
            static int MaxLength(string node, ICollection<string> children)
            {
                if (node.HasRepeatedCharacters())
                    return 0;
                if (!children.Any())
                    return node.Length;

                var nextChildren = new List<string>(children);
                var nextNode = children.First();
                nextChildren.Remove(nextNode);

                var leftMaxLength = MaxLength(node + nextNode, nextChildren);
                var rightMaxLength = MaxLength(node, nextChildren);

                return Math.Max(leftMaxLength, rightMaxLength);
            }

            return MaxLength(string.Empty, strings);
        }

        /// <summary>
        ///     Recursive. Depth-first search.
        ///     The recursion tree considers the current string (which is a concatenation of successful string combinations) as the
        ///     current node, and the rest of the strings as its children, therefore one node may have many children.
        ///     TODO: Calculate MaxLengthRecursiveTreeImplementation time and space complexities.
        ///     Time complexity: Θ(?).
        ///     Space complexity: Θ(?).
        /// </summary>
        public static int RecursiveGenericTreeImplementation(ICollection<string> strings)
        {
            static int MaxLength(string node, ICollection<string> children)
            {
                if (node.HasRepeatedCharacters())
                    return 0;
                if (!children.Any())
                    return node.Length;

                var lengths = new List<int> {node.Length};

                var nextChildren = new List<string>(children);
                foreach (var child in children)
                {
                    nextChildren.Remove(child);
                    lengths.Add(MaxLength(node + child, nextChildren));
                }

                return lengths.Max();
            }

            return MaxLength(string.Empty, strings);
        }
    }
}