using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    public sealed class GenericTreeManager<T>
    {
        private readonly Dictionary<string, Node<T>> _nodes = new Dictionary<string, Node<T>>();

        public GenericTreeManager(T rootNodeData, string rootNodeName = null)
        {
            if (rootNodeName == null)
                rootNodeName = rootNodeData.ToString();
            var rootNode = new GenericNode<T>(rootNodeData);
            _nodes.Add(rootNodeName, rootNode);
        }

        public Node<T> this[string nodeName] => _nodes[nodeName];

        public void AddChildNodeToParent(string parentNodeName, T nodeData, string nodeName = null)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));

            var parentNode = _nodes[parentNodeName];
            if (nodeData == null)
            {
                parentNode.Children.Add(null);
            }
            else
            {
                if (nodeName == null)
                    nodeName = nodeData.ToString();
                var childNode = new GenericNode<T>(nodeData);
                parentNode.Children.Add(childNode);
                _nodes.Add(nodeName, childNode);
            }
        }

        public void AddChildrenNodesToParent(string parentNodeName,
            ICollection<(T nodeData, string nodeName)> nodesData)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));
            Guard.Against.Null(nodesData, nameof(nodesData));

            foreach (var (nodeData, nodeName) in nodesData)
                AddChildNodeToParent(parentNodeName, nodeData, nodeName);
        }

        public void AddChildrenNodesToParent(string parentNodeName, ICollection<T> dataItems)
        {
            var nodesData = dataItems.Select(d => (d, (string) null)).ToList();
            AddChildrenNodesToParent(parentNodeName, nodesData);
        }
    }
}