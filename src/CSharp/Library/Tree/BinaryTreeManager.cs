using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A <see cref="BinaryTreeManager{TData}" /> constructor.
    /// </summary>
    public sealed class BinaryTreeManager
    {
        /// <summary>
        ///     Creates a <see cref="BinaryTreeManager{TData}" /> using an enumeration of nullable <see cref="TData" /> value-type
        ///     elements.
        /// </summary>
        /// <typeparam name="TData">The non-nullable value-type tree nodes data property data type.</typeparam>
        /// <param name="nodesData">
        ///     An enumeration of nullable value-type elements used to construct the binary tree. Null elements
        ///     are considered leaf nodes.
        /// </param>
        /// <returns>The created <see cref="BinaryTreeManager{TData}" /></returns>
        public static BinaryTreeManager<TData> Create<TData>(IEnumerable<TData?> nodesData) where TData : struct
        {
            var nodes = nodesData.Select(nodeData =>
            {
                var node = nodeData.HasValue ? new BinaryNode<TData>(nodeData.Value) : null;
                return node;
            });
            return ConnectNodes(nodes);
        }

        /// <summary>
        ///     Creates a <see cref="BinaryTreeManager{TData}" /> using an enumeration of <see cref="TData" /> reference-type
        ///     elements.
        /// </summary>
        /// <typeparam name="TData">The reference-type tree nodes data property data type.</typeparam>
        /// <param name="nodesData">
        ///     An enumeration of reference-type elements used to construct the binary tree. Null elements are considered leaf
        ///     nodes.
        /// </param>
        /// <returns>The created <see cref="BinaryTreeManager{TData}" /></returns>
        public static BinaryTreeManager<TData> Create<TData>(IEnumerable<TData> nodesData) where TData : class
        {
            var nodes = nodesData.Select(nodeData =>
            {
                var node = nodeData != null ? new BinaryNode<TData>(nodeData) : null;
                return node;
            });
            return ConnectNodes(nodes);
        }

        private static BinaryTreeManager<TData> ConnectNodes<TData>(IEnumerable<BinaryNode<TData>> nodes)
        {
            var binaryTreeManager = new BinaryTreeManager<TData>();
            var parentsQueue = new Queue<BinaryNode<TData>>();
            BinaryNode<TData> currentParent = null;
            var childCounter = 0;
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    binaryTreeManager.AddNode(node);
                    parentsQueue.Enqueue(node);
                }

                if (currentParent == null)
                    currentParent = parentsQueue.Dequeue();
                else
                    currentParent.Children[childCounter++] = node;

                if (childCounter <= 1) continue;

                currentParent = parentsQueue.Dequeue();
                childCounter = 0;
            }

            return binaryTreeManager;
        }
    }

    /// <summary>
    ///     Helper class for creating and manipulating binary trees.
    /// </summary>
    /// <typeparam name="TData">Nodes data property data type.</typeparam>
    public sealed class BinaryTreeManager<TData>
    {
        private readonly Dictionary<string, BinaryNode<TData>> _nodes = new Dictionary<string, BinaryNode<TData>>();

        internal BinaryTreeManager()
        {
        }

        public BinaryTreeManager(TData rootNodeData, string rootNodeName = null)
        {
            AddNode(rootNodeData, rootNodeName);
        }

        public BinaryNode<TData> Root => _nodes.First().Value;
        public BinaryNode<TData> this[string nodeName] => _nodes[nodeName];

        public void AddChildNodeToParent(string parentNodeName, BifurcationIndex index, TData nodeData,
            string nodeName = null)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));

            var parentNode = _nodes[parentNodeName];
            if (nodeData == null)
            {
                parentNode.Children[(int) index] = null;
            }
            else
            {
                var childNode = AddNode(nodeData, nodeName);
                parentNode.Children[(int) index] = childNode;
            }
        }

        public void AddChildrenNodesToParent(string parentNodeName, TData leftNodeData, TData rightNodeData,
            string leftNodeName = null, string rightNodeName = null)
        {
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Left, leftNodeData, leftNodeName);
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Right, rightNodeData, rightNodeName);
        }

        internal BinaryNode<TData> AddNode(TData nodeData, string nodeName = null)
        {
            nodeName = Helpers.GetValidNodeName(nodeData, nodeName, s => _nodes.ContainsKey(s));
            var node = new BinaryNode<TData>(nodeData);
            _nodes.Add(nodeName, node);
            return node;
        }

        internal void AddNode(BinaryNode<TData> node, string nodeName = null)
        {
            nodeName = Helpers.GetValidNodeName(node.Data, nodeName, s => _nodes.ContainsKey(s));
            _nodes.Add(nodeName, node);
        }
    }
}