using System;
using System.Collections.Generic;
using System.Text;

namespace 트리
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            this.Data = data;
        }
    }

    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            Console.WriteLine(node.Data);
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }

        public void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            InOrderTraversal(node.Left);
            Console.WriteLine(node.Data);
            InOrderTraversal(node.Right);
        }

        public void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node == null) return;

            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.WriteLine(node.Data);
        }
    }
}
