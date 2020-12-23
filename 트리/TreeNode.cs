using System;
using System.Collections.Generic;
using System.Text;

namespace 트리
{
    public class TreeNode<T>
    {
        public T Value { get; private set; }
        public TreeNode<T> Parent { get; set; }

        private List<TreeNode<T>> _children;

        public IList<TreeNode<T>> Children
        {
            get
            {
                return _children.AsReadOnly();
            }
        }

        public TreeNode(T value, TreeNode<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
            _children = new List<TreeNode<T>>();
        }

        public bool AddChild(TreeNode<T> child)
        {
            if (_children.Contains(child) == true)
            {
                return false;
            }
            else if (child == this)
            {
                return false;
            }
            else
            {
                _children.Add(child);
                child.Parent = this;
                return true;
            }
        }

        public bool RemoveChild(TreeNode<T> child)
        {
            if (_children.Contains(child) == true)
            {
                child.Parent = null;
                return _children.Remove(child);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveAllChildren()
        {
            for (int i = _children.Count - 1; i >= 0; i--)
            {
                _children[i].Parent = null;
                _children.RemoveAt(i);
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("[ Node Value: {0}", Value);

            builder.Append(", Parent: ");
            if (Parent != null)
            {
                builder.Append(Parent.Value);
            }
            else
            {
                builder.Append("null");
            }

            builder.Append(", Children: [");
            for (int i = 0; i < _children.Count; i++)
            {
                builder.Append(Children[i].Value + " ");
            }

            builder.Append("] ]");

            return builder.ToString();
        }
    }

}
