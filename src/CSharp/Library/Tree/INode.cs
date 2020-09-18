using System.Collections.Generic;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     An abstract tree node. A tree has a value (data) and children, and the children are themselves trees; the value and
    ///     children of the tree are interpreted as the value of the root node and the subtrees of the children of the root
    ///     node. To allow finite trees, the children collection is allowed to be either empty or having NULL values. Also, the
    ///     children collection can be of dynamic or fixed size (branching factor, especially 2 or "binary").
    ///     https://en.wikipedia.org/wiki/Tree_(data_structure)
    /// </summary>
    /// <typeparam name="TData">Node data type.</typeparam>
    /// <typeparam name="TNode">The node type.</typeparam>
    public interface INode<TData, TNode> where TNode : INode<TData, TNode>
    {
        /// <summary>
        ///     Node data.
        /// </summary>
        TData Data { get; set; }

        /// <summary>
        ///     Node children.
        /// </summary>
        IList<TNode> Children { get; set; }
    }
}