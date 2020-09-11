using System.Collections.Generic;
using System.Linq;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     A generic tree node. A tree has a value and children, and the children are themselves trees; the value and children
    ///     of the tree are interpreted as the value of the root node and the subtrees of the children of the root node. To
    ///     allow finite trees, the list of children is allowed to be either empty (in which case trees can be required
    ///     to be non-empty, an "empty tree" instead being represented by a forest of zero trees), or allow trees to be empty,
    ///     in which case the list of children can be of fixed size (branching factor, especially 2 or "binary"), if desired.
    ///     https://en.wikipedia.org/wiki/Tree_(data_structure)
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public class Node<T>
    {
        public Node()
        {
            Children = new List<Node<T>>();
        }

        public Node(T data)
        {
            Data = data;
            Children = new List<Node<T>>();
        }

        public Node(T data, IEnumerable<Node<T>> children)
        {
            Data = data;
            Children = children;
        }

        /// <summary>
        ///     Node data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///     Node children.
        /// </summary>
        public IEnumerable<Node<T>> Children { get; set; }

        public override string ToString()
        {
            var childrenData = Children != null
                ? $" ({string.Join(", ", Children.Select(child => child == null ? "null" : child.Data.ToString()))})"
                : string.Empty;
            return $"{Data}{childrenData}";
        }
    }
}