using System.Collections.Generic;
using System.Linq;

namespace CSharp.Library.Tree
{
    /// <summary>
    ///     An abstract tree node. A tree has a value (data) and children, and the children are themselves trees; the value and
    ///     children of the tree are interpreted as the value of the root node and the subtrees of the children of the root
    ///     node. To allow finite trees, the children collection is allowed to be either empty or having NULL values. Also, the
    ///     children collection can be of dynamic or fixed size (branching factor, especially 2 or "binary").
    ///     https://en.wikipedia.org/wiki/Tree_(data_structure)
    /// </summary>
    /// <typeparam name="T">Node data type.</typeparam>
    public abstract class Node<T>
    {
        /// <summary>
        ///     Node data.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        ///     Node children.
        /// </summary>
        public virtual IList<Node<T>> Children { get; set; }

        public override string ToString()
        {
            var childrenData = Children != null
                ? $" ({string.Join(", ", Children.Select(child => child == null ? "null" : child.Data.ToString()))})"
                : string.Empty;
            return $"{Data}{childrenData}";
        }
    }
}