using System.Collections.Generic;
using System.Linq;
using Ardalis.GuardClauses;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     Helper class for creating and manipulating generic trees.
    /// </summary>
    /// <typeparam name="TData">Nodes data property data type.</typeparam>
    public sealed class GenericTreeManager<TData>
    {
        private readonly Dictionary<string, GenericNode<TData>> _nodes = new Dictionary<string, GenericNode<TData>>();

        public GenericTreeManager(TData rootNodeData, string rootNodeName = null)
        {
            if (rootNodeName == null)
                rootNodeName = rootNodeData.ToString();
            var rootNode = new GenericNode<TData>(rootNodeData);
            _nodes.Add(rootNodeName, rootNode);
        }

        public GenericNode<TData> Root => _nodes.First().Value;
        public GenericNode<TData> this[string nodeName] => _nodes[nodeName];

        public void AddChildNodeToParent(string parentNodeName, TData nodeData, string nodeName = null)
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
                var childNode = new GenericNode<TData>(nodeData);
                parentNode.Children.Add(childNode);
                _nodes.Add(nodeName, childNode);
            }
        }

        public void AddChildrenNodesToParent(string parentNodeName,
            ICollection<(TData nodeData, string nodeName)> nodesData)
        {
            Guard.Against.Null(parentNodeName, nameof(parentNodeName));
            Guard.Against.Null(nodesData, nameof(nodesData));

            foreach (var (nodeData, nodeName) in nodesData)
                AddChildNodeToParent(parentNodeName, nodeData, nodeName);
        }

        public void AddChildrenNodesToParent(string parentNodeName, ICollection<TData> dataItems)
        {
            var nodesData = dataItems.Select(d => (d, (string) null)).ToList();
            AddChildrenNodesToParent(parentNodeName, nodesData);
        }
    }
}