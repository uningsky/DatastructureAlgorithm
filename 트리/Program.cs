using System;

namespace 트리
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleBinaryTreeTest();
            TreeTest();
        }

        static void TreeTest()
        {
            Tree<int> tree = new Tree<int>(1);

            TreeNode<int> treeNode2 = new TreeNode<int>(2, tree.Root);
            tree.AddNode(treeNode2);

            TreeNode<int> treeNode3 = new TreeNode<int>(3, tree.Root);
            tree.AddNode(treeNode3);

            TreeNode<int> treeNode4 = new TreeNode<int>(4, treeNode2);
            tree.AddNode(treeNode4);

            TreeNode<int> treeNode5 = new TreeNode<int>(5, treeNode3);
            tree.AddNode(treeNode5);

            Console.WriteLine(tree.ToString()); 
        }

        static void SimpleBinaryTreeTest()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();

            binaryTree.Root = new BinaryTreeNode<int>(1);
            binaryTree.Root.Left = new BinaryTreeNode<int>(2);
            binaryTree.Root.Right = new BinaryTreeNode<int>(3);
            binaryTree.Root.Left.Left = new BinaryTreeNode<int>(4);
            binaryTree.Root.Left.Right = new BinaryTreeNode<int>(5);

            Console.WriteLine("In Order Traversal");
            binaryTree.InOrderTraversal(binaryTree.Root);

            Console.WriteLine("Pre Order Traversal");
            binaryTree.PreOrderTraversal(binaryTree.Root);

            Console.WriteLine("Post Order Traversal");
            binaryTree.PostOrderTraversal(binaryTree.Root);
        }
    }
}
