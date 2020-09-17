using System.Collections.Generic;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A binary tree node, with a branching factor bounded to two.
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public class BinaryNode<T> : Node<T>
    {
        public BinaryNode()
        {
        }

        public BinaryNode(T data)
        {
            Data = data;
        }

        public override IList<Node<T>> Children { get; set; } = new Node<T>[2];
        public BinaryNode<T> Left => (BinaryNode<T>) Children[(int) BifurcationIndex.Left];
        public BinaryNode<T> Right => (BinaryNode<T>) Children[(int) BifurcationIndex.Right];
    }

    public enum BifurcationIndex
    {
        Left = 0,
        Right = 1
    }
}