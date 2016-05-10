using System;

namespace Dibware.Collections
{
    public class TreeNode<T>
    {
        private TreeNodeList<T> _children;
        private string _text;

        public TreeNodeList<T> Children
        {
            get
            {
                return _children ?? (_children = new TreeNodeList<T>(this));
            }
            private set { _children = value; }
        }

        public TreeNode()
        {
        }

        public TreeNode(string text)
            : this()
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentNullException("text");

            _text = text;
        }

        /// <summary>
        /// Gets or sets the {t} stored in the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public T Tag { get; set; }

        /// <summary>
        /// Gets or sets the text associated with this <see>
        /// <cref>TreeNode</cref></see>.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return _text ?? string.Empty; }
            set { _text = value; }
        }

        public void AppendChildren(TreeNodeList<T> children)
        {
            if (children == null) throw new ArgumentNullException("children");

            Children.AddRange(children);
        }

        public TreeNodeList<T> GetRecursiveNodes()
        {
            var result = new TreeNodeList<T>(null);

            foreach (var treeNode in Children)
            {
                result.Add(treeNode);
                result.AddRange(treeNode.GetRecursiveNodes());
            }

            return result;
        }

        public void ReplaceChildren(TreeNodeList<T> children)
        {
            if (children == null) throw new ArgumentNullException("children");

            Children = children;
        }
    }
}