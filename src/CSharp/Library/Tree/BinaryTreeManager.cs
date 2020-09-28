using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    public sealed class BinaryTreeManager
    {
        public static BinaryTreeManager<T> Create<T>(IEnumerable<T?> nodesData) where T : struct
        {
            var nodes = nodesData.Select(nodeData =>
            {
                var node = nodeData.HasValue ? new BinaryNode<T>(nodeData.Value) : null;
                return node;
            });
            return ConnectNodes(nodes);
        }

        public static BinaryTreeManager<T> Create<T>(IEnumerable<T> nodesData) where T : class
        {
            var nodes = nodesData.Select(nodeData =>
            {
                var node = nodeData != null ? new BinaryNode<T>(nodeData) : null;
                return node;
            });
            return ConnectNodes(nodes);
        }

        private static BinaryTreeManager<T> ConnectNodes<T>(IEnumerable<BinaryNode<T>> nodes)
        {
            var binaryTreeManager = new BinaryTreeManager<T>();
            var parentsQueue = new Queue<BinaryNode<T>>();
            BinaryNode<T> currentParent = null;
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

    public sealed class BinaryTreeManager<T>
    {
        private readonly Dictionary<string, BinaryNode<T>> _nodes = new Dictionary<string, BinaryNode<T>>();

        internal BinaryTreeManager()
        {
        }

        public BinaryTreeManager(T rootNodeData, string rootNodeName = null)
        {
            AddNode(rootNodeData, rootNodeName);
        }

        public BinaryNode<T> Root => _nodes.First().Value;
        public BinaryNode<T> this[string nodeName] => _nodes[nodeName];

        public void AddChildNodeToParent(string parentNodeName, BifurcationIndex index, T nodeData,
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

        public void AddChildrenNodesToParent(string parentNodeName, T leftNodeData, T rightNodeData,
            string leftNodeName = null, string rightNodeName = null)
        {
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Left, leftNodeData, leftNodeName);
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Right, rightNodeData, rightNodeName);
        }

        internal BinaryNode<T> AddNode(T nodeData, string nodeName = null)
        {
            nodeName = GetValidNodeName(nodeName, nodeData);
            var node = new BinaryNode<T>(nodeData);
            _nodes.Add(nodeName, node);
            return node;
        }

        internal void AddNode(BinaryNode<T> node, string nodeName = null)
        {
            nodeName = GetValidNodeName(nodeName, node.Data);
            _nodes.Add(nodeName, node);
        }

        private string GetValidNodeName(string nodeName, T nodeData)
        {
            if (string.IsNullOrEmpty(nodeName))
                nodeName = nodeData.ToString();
            var n = 0;
            var newNodeName = nodeName;
            while (_nodes.ContainsKey(newNodeName))
                newNodeName = $"{nodeName}({++n})";
            return newNodeName;
        }
    }
}