using System.Collections.Generic;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A binary tree node, with a branching factor bounded to two.
    /// </summary>
    /// <typeparam name="TData">Node data type.</typeparam>
    public sealed class BinaryNode<TData> : Node<TData, BinaryNode<TData>>
    {
        public BinaryNode()
        {
        }

        public BinaryNode(TData data)
        {
            Data = data;
        }

        public override IList<BinaryNode<TData>> Children { get; set; } = new BinaryNode<TData>[2];

        public BinaryNode<TData> Left
        {
            get => Children[(int) BifurcationIndex.Left];
            set => Children[(int) BifurcationIndex.Left] = value;
        }

        public BinaryNode<TData> Right
        {
            get => Children[(int) BifurcationIndex.Right];
            set => Children[(int) BifurcationIndex.Right] = value;
        }
    }

    public enum BifurcationIndex
    {
        Left = 0,
        Right = 1
    }
}