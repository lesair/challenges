namespace CSharp.Library.SinglyLinkedList
{
    /// <summary>
    ///     A linked list node.
    /// </summary>
    /// <typeparam name="TData">Node data type.</typeparam>
    public sealed class Node<TData>
    {
        public Node()
        {
        }

        public Node(TData data)
        {
            Data = data;
        }

        public TData Data { get; set; }

        public Node<TData> Next { get; set; }

        public override string ToString()
        {
            var nextData = Next != null
                ? $" ({Next.Data})"
                : string.Empty;
            return $"{Data}{nextData}";
        }
    }
}