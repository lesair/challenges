﻿using System.Collections.Generic;
using System.Linq;

namespace CSharp.Library.SinglyLinkedList
{
    /// <summary>
    ///     Helper class for creating and manipulating singly linked lists.
    /// </summary>
    /// <typeparam name="TData">Nodes data property data type.</typeparam>
    public sealed class SinglyLinkedListManager<TData>
    {
        private readonly Dictionary<string, Node<TData>> _nodes = new Dictionary<string, Node<TData>>();
        public Node<TData> Head => _nodes.FirstOrDefault().Value;
        public Node<TData> this[string nodeName] => _nodes[nodeName];

        /// <summary>
        ///     Creates a singly linked list based on the nodes data.
        /// </summary>
        /// <param name="nodesData">Nodes data to use for each linked node.</param>
        /// <returns>The linked list head node, or null if <see cref="nodesData" /> is empty or null.</returns>
        public Node<TData> Create(IEnumerable<TData> nodesData)
        {
            if (nodesData == null)
                return null;

            Node<TData> previousNode = null;
            foreach (var nodeData in nodesData)
            {
                var node = new Node<TData>(nodeData);
                AddNode(node);
                if (previousNode != null)
                    previousNode.Next = node;
                previousNode = node;
            }

            return Head;
        }

        /// <summary>
        ///     Traverses the linked list to return an enumeration of the traversed nodes data.
        /// </summary>
        /// <param name="node">Linked list head node to start traversing on.</param>
        /// <returns>An enumeration of the collected nodes data.</returns>
        public static IEnumerable<TData> GetData(Node<TData> node)
        {
            while (node != null)
            {
                yield return node.Data;
                node = node.Next;
            }
        }

        internal void AddNode(Node<TData> node, string nodeName = null)
        {
            nodeName = Helpers.GetValidNodeName(node.Data, nodeName, s => _nodes.ContainsKey(s));
            _nodes.Add(nodeName, node);
        }
    }
}