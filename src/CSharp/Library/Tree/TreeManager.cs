using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    public class TreeManager<T>
    {
        private readonly Dictionary<string, Node<T>> _nodes = new Dictionary<string, Node<T>>();

        public TreeManager(T rootNodeData, string rootNodeName = null)
        {
            if (rootNodeName == null)
                rootNodeName = rootNodeData.ToString();
            var rootNode = new Node<T>(rootNodeData);
            _nodes.Add(rootNodeName, rootNode);
        }

        public Node<T> this[string nodeName] => _nodes[nodeName];

        public void AddChildNodeToParent(string parentNodeName, T nodeData, string nodeName = null)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));

            if (nodeName == null)
                nodeName = nodeData.ToString();
            var parentNode = _nodes[parentNodeName];
            var childNode = new Node<T>(nodeData);
            _nodes.Add(nodeName, childNode);
            parentNode.Children = parentNode.Children.Append(childNode);
        }

        public void AddChildrenNodesToParent(string parentNodeName, IList<(T nodeData, string nodeName)> nodesData)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));
            Guard.Against.Null(nodesData, nameof(nodesData));

            var parentNode = _nodes[parentNodeName];
            var newChildNodes = new List<Node<T>>();
            foreach (var (nodeData, nodeName) in nodesData)
            {
                var childNode = new Node<T>(nodeData);
                _nodes.Add(nodeName, childNode);
                newChildNodes.Add(childNode);
            }

            parentNode.Children = parentNode.Children.Concat(newChildNodes);
        }

        public void AddChildrenNodesToParent(string parentNodeName, IList<T> dataItems)
        {
            var nodesData = dataItems.Select(d => (d, d.ToString())).ToList();
            AddChildrenNodesToParent(parentNodeName, nodesData);
        }
    }
}