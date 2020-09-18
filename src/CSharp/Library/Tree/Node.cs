using System.Collections.Generic;
using System.Linq;

namespace CSharp.Library.Tree
{
    public abstract class Node<TData, TNode> : INode<TData, TNode> where TNode : INode<TData, TNode>
    {
        public TData Data { get; set; }

        public abstract IList<TNode> Children { get; set; }

        public override string ToString()
        {
            var childrenData = Children != null
                ? $" ({string.Join(", ", Children.Select(child => child == null ? "null" : child.Data.ToString()))})"
                : string.Empty;
            return $"{Data}{childrenData}";
        }
    }
}