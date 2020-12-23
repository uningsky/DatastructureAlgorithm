using System;
using System.Collections.Generic;
using System.Text;

namespace 트리
{
    public class Tree<T>
    {
        public TreeNode<T> Root { get; private set; } = null;
        private List<TreeNode<T>> _nodes = new List<TreeNode<T>>(); 
        public int Count { get => _nodes.Count; }

        public Tree(T value)
        {
            Root = new TreeNode<T>(value, null);
            _nodes.Add(Root);
        }

        private void Clear()
        {
            foreach (TreeNode<T> node in _nodes)
            {
                node.Parent = null;
                node.RemoveAllChildren(); 
            }

            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                _nodes.RemoveAt(i);
            }

            Root = null; 
        }

        public bool AddNode(TreeNode<T> node)
        {
            if (node == null || node.Parent == null || _nodes.Contains(node.Parent) == false)
            {
                return false; 
            }
            else if (node.Parent.Children.Contains(node))
            {
                return false; 
            }
            else
            {
                _nodes.Add(node);
                return node.Parent.AddChild(node);
            }
        }

        public bool RemoveNode(TreeNode<T> removeNode)
        {
            if (removeNode == null)
            {
                return false; 
            }
            else if (removeNode == Root)
            {
                Clear();
                return true; 
            }
            else
            {
                bool success = removeNode.Parent.RemoveChild(removeNode);
                if (!success)
                {
                    return false; 
                }

                success = _nodes.Remove(removeNode);
                if (!success)
                {
                    return false; 
                }

                if (removeNode.Children.Count > 0)
                {
                    IList<TreeNode<T>> children = removeNode.Children;
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        RemoveNode(children[i]);
                    }
                }
            }

            return true; 
        }

        public TreeNode<T> Find(T value)
        {
            foreach (TreeNode<T> node in _nodes)
            {
                if (node.Value.Equals(value))
                {
                    return node; 
                }
            }
            return null; 
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Root: ");
            if (Root != null)
            {
                builder.Append(Root.Value + " ");
            }
            else
            {
                builder.Append("null");
            }

            for (int i = 0; i < Count; i++)
            {
                builder.Append(_nodes[i].ToString());
                if (i < Count - 1)
                {
                    builder.Append(", ");
                }
            }
            
            return builder.ToString(); 
        }
    }
}
