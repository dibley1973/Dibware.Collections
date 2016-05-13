using Dibware.Collections.Resources;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dibware.Collections
{
    public class TreeNodeList<T> : IEnumerable, IEnumerable<TreeNode<T>>
    {
        private List<TreeNode<T>> _children;
        private readonly TreeNode<T> _owner;

        public TreeNodeList(TreeNode<T> owner)
            : this(owner, new List<TreeNode<T>>())
        { }

        public TreeNodeList(TreeNode<T> owner, List<TreeNode<T>> children)
        {
            if (owner == null) throw new ArgumentNullException("owner");
            if (children == null) throw new ArgumentNullException("children");

            _children = children;
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
        object this[int index]
        {
            get { return Children[index]; }
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

            Children.Add(node);
            return ChildCount - 1;
        }

        //private int AddInternal(TreeNode<T> node, int delta)
        //{
        //    if (node == null)  throw new ArgumentNullException("node");
        //    if (delta < 0) throw new ArgumentOutOfRangeException("delta");
        //    if (delta > ChildCount -1) throw new ArgumentOutOfRangeException("delta");

        //    if (delta == 0)
        //    {
        //        return AddInternal(node);
        //    }

        //    Children.Insert(delta, node);
        //    return delta;

        //    //if (node.handle != IntPtr.Zero)
        //    //{
        //    //    object[] text = new object[] { node.Text };
        //    //    throw new ArgumentException(SR.GetString("OnlyOneControl", text), "node");
        //    //}
        //    //TreeView treeView = this.owner.TreeView;
        //    //if (treeView != null && treeView.Sorted)
        //    //{
        //    //    return this.owner.AddSorted(node);
        //    //}
        //    //node.parent = this.owner;
        //    //int fixedIndex = this.owner.Nodes.FixedIndex;
        //    //if (fixedIndex == -1)
        //    //{
        //    //    this.owner.EnsureCapacity(1);
        //    //    node.index = this.owner.childCount;
        //    //}
        //    //else
        //    //{
        //    //    node.index = fixedIndex + delta;
        //    //}
        //    //this.owner.children[node.index] = node;
        //    //TreeNode treeNode = this.owner;
        //    //treeNode.childCount = treeNode.childCount + 1;
        //    //node.Realize(false);
        //    //if (treeView != null && node == treeView.selectedNode)
        //    //{
        //    //    treeView.SelectedNode = node;
        //    //}
        //    //if (treeView != null && treeView.TreeViewNodeSorter != null)
        //    //{
        //    //    treeView.Sort();
        //    //}
        //    //return node.index;

        //    return -1; // TODO Correct to something meaningful!
        //}

        public void AddRange(TreeNodeList<T> nodes)
        {
            if (nodes == null) throw new ArgumentNullException("nodes");
            if (nodes.ChildCount == 0) return;

            foreach (var node in nodes)
            {
                Children.Add((TreeNode<T>)node);
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

        public int ChildCount
        {
            get
            {
                return Children.Count;
            }
        }

        public List<TreeNode<T>> Children
        {
            get { return _children; }
        }

        public TreeNode<T> Owner
        {
            get { return _owner; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            for (int i = 0; i < ChildCount; i++)
            {
                yield return Children[i];
            }
        }
    }
}