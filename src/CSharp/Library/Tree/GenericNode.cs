using System.Collections.Generic;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A generic, non-binary tree node, with a dynamic branching factor.
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public sealed class GenericNode<T> : Node<T>
    {
        public GenericNode()
        {
        }

        public GenericNode(T data)
        {
            Data = data;
        }

        public override IList<Node<T>> Children { get; set; } = new List<Node<T>>();
    }
}