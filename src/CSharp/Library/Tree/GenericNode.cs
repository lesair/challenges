using System.Collections.Generic;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A generic, non-binary tree node, with a dynamic branching factor.
    /// </summary>
    /// <typeparam name="TData">Node data type.</typeparam>
    public sealed class GenericNode<TData> : Node<TData, GenericNode<TData>>
    {
        public GenericNode()
        {
        }

        public GenericNode(TData data)
        {
            Data = data;
        }

        public override IList<GenericNode<TData>> Children { get; set; } = new List<GenericNode<TData>>();
    }
}