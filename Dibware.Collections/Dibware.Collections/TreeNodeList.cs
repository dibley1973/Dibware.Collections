using Dibware.Collections.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dibware.Collections
{
    public class TreeNodeList<T> : ICollection, IEnumerable, IEnumerable<TreeNode<T>>
    {
        private readonly List<TreeNode<T>> _nodes;
        private readonly TreeNode<T> _owner;

        public TreeNodeList(TreeNode<T> owner)
            : this(owner, new List<TreeNode<T>>())
        { }

        public TreeNodeList(TreeNode<T> owner, List<TreeNode<T>> nodes)
        {
            if (owner == null) throw new ArgumentNullException("owner");
            if (nodes == null) throw new ArgumentNullException("nodes");

            _nodes = nodes;
            _owner = owner;
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        /// <param name="index">
        /// The zero-based index of the element to get or set. 
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// <paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />. 
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The property is set and the <see cref="T:System.Collections.IList" /> is read-only. 
        /// </exception>
        /// <filterpriority>2</filterpriority>
        public object this[int index]
        {
            get { return Nodes[index]; }
            set
            {
                if (!(value is TreeNode<T>))
                {
                    throw new ArgumentException(ExceptionMessages.CannotSetIncorrectTreeNodeType, "value");
                }
                this[index] = (TreeNode<T>)value;
            }
        }

        public int Add(TreeNode<T> node)
        {
            if (node == null) throw new ArgumentNullException("node");

            Nodes.Add(node);
            return Count - 1;
        }

        public void AddRange(TreeNodeList<T> nodes)
        {
            if (nodes == null) throw new ArgumentNullException("nodes");
            if (nodes.Count == 0) return;

            foreach (var node in nodes)
            {
                Nodes.Add((TreeNode<T>)node);
            }

        }

        public void AddRange(TreeNode<T>[] nodes)
        {
            if (nodes == null) throw new ArgumentNullException("nodes");
            if (nodes.Length == 0) return;

            foreach (var node in nodes)
            {
                Add(node);
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return Nodes.Count; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        protected internal List<TreeNode<T>> Nodes
        {
            get { return _nodes; }
        }

        protected internal TreeNode<T> Owner
        {
            get { return _owner; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return Nodes[i];
            }
        }

        public TreeNode<T>[] ToTreeNodeArray()
        {
            return Nodes.ToArray();
        }
    }
}