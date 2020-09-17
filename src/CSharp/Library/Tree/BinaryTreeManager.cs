using System.Collections.Generic;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    public sealed class BinaryTreeManager<T>
    {
        private readonly Dictionary<string, BinaryNode<T>> _nodes = new Dictionary<string, BinaryNode<T>>();

        public BinaryTreeManager(T rootNodeData, string rootNodeName = null)
        {
            if (rootNodeName == null)
                rootNodeName = rootNodeData.ToString();
            var rootNode = new BinaryNode<T>(rootNodeData);
            _nodes.Add(rootNodeName, rootNode);
        }

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
                if (nodeName == null)
                    nodeName = nodeData.ToString();
                var childNode = new BinaryNode<T>(nodeData);
                parentNode.Children[(int) index] = childNode;
                _nodes.Add(nodeName, childNode);
            }
        }

        public void AddChildrenNodesToParent(string parentNodeName, T leftNodeData, T rightNodeData,
            string leftNodeName = null, string rightNodeName = null)
        {
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Left, leftNodeData, leftNodeName);
            AddChildNodeToParent(parentNodeName, BifurcationIndex.Right, rightNodeData, rightNodeName);
        }
    }
}