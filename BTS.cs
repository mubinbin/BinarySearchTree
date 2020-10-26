using System;
using System.Collections.Generic;

namespace binarySearchTree
{
    public class BST
    {
        //Setup
        public BNode root {get;set;}
        public BST()
        {
            root = null;
        }

        //How do I add nodes to the BST
        public void AddNode(BNode NewNode)
        {
            if(root == null){
                root = NewNode;
            }else{

                BNode pointer = root;
                while(pointer != null)
                {
                    if (NewNode.value > pointer.value)
                    {
                        if(pointer.right == null)
                        {
                            pointer.right = NewNode;
                            break;
                        }else{
                            pointer = pointer.right;
                        }
                    }else if (NewNode.value < pointer.value){
                        if(pointer.left == null){
                            pointer.left = NewNode;
                            break;
                        }else{
                            pointer = pointer.left;
                        }
                    }
                }
            }
        }
        // How do I find the min or max in the BST
        public int? FindMin()
        {
            if (root == null)
            {
                return null;
            }
            BNode pointer = root;
            while(pointer.left != null)
            {
                pointer = pointer.left;
            }
            return pointer.value;
        }

        public int? FindMax()
        {
            if (root == null)
            {
                return null;
            }
            BNode pointer = root;
            while(pointer.right != null)
            {
                pointer = pointer.right;
            }
            return pointer.value;
        }


        public bool Contains(int num)
        {
            BNode pointer = root;
            while(pointer != null)
            {
                if (pointer.value == num)
                {
                    return true;
                }else if (num < pointer.value)
                {
                    pointer=pointer.left;
                }else{
                    pointer=pointer.right;
                }
            }
            return false;
        }

        public int BSTsize(BNode node) 
        {
            if(node == null) 
            {
                return (0);
            }else{

                return(BSTsize(node.left)+ 1 +BSTsize(node.right));
            }
        }

        public int Height(BNode node)
        {
            if(node == null)
            {
                return 0;
            }else{

                int leftHeight = Height(node.left);
                int rightHeight = Height(node.right);

                if(leftHeight >= rightHeight)
                {
                    return (leftHeight +1);
                }else{
                    return (rightHeight +1);
                }
            }
        }

        public bool IsBalanced()
        {
            if(root == null)
                return false;
            
            if(root.left == null && root.right == null)
            {
                return true;
            }else{
                int leftHeight = Height(root.left);
                Console.WriteLine($"Left height is {leftHeight}");
                
                int rightHeight = Height(root.right);
                Console.WriteLine($"Right height is {rightHeight}");


                if(Math.Abs(leftHeight-rightHeight) >1)
                    return false;

                return true;
            }
        }

        public bool IsFull(BNode node)
        {
            if(node == null) return false; 

            if(node.left == null && node.right == null){
                return true;
            }else if(node.left != null && node.right != null){
                if(IsFull(node.left) != IsFull(node.right)) 
                    return false;
            }else{
                return false;
            }

            return true;
        }

        public void Remove(int num)
        {
            if(!Contains(num))
            {
                Console.WriteLine("value is not in the tree");
                return;
            }else{
                root = remove(root, num);
            }
        }

        public BNode remove(BNode node, int num)
        {
            if(num < node.value)
            {
                node.left = remove(node.left, num);
            }else if(num > node.value)
            {
                node.right = remove(node.right, num);
            }else{
                if(node.right == null)
                {
                    return node.left;
                }else if(node.left == null)
                {
                    return node.right;
                }else{
                    BNode temp = iop(node.left);
                    node.value = temp.value;
                    node.left = remove(node.left, temp.value);
                }
            }
            return node;
        }
        //     BNode pointer = root;
        //     while(root != null)
        //     {
        //         if(root.value == num)
        //         {
        //             break;
        //         }else if(num < root.value)
        //         {
        //             root = root.left;
        //         }else{
        //             root = root.right;
        //         }
        //     }
            

        //     Console.WriteLine(root.value);
        //     if(root.left == null && root.right == null)
        //     {
        //         // no children
        //         root = null;
        //     }else if(pointer.left != null && pointer.right == null){
        //         // one child left
        //         BNode NodeDeleted = pointer;
        //         pointer = pointer.left;
        //         return;
        //     }else if (pointer.left == null && pointer.right!=null){
        //         // one child right
        //         BNode NodeDeleted = pointer;
        //         pointer = pointer.right;
        //         return;
        //     }else{
        //         //  two children
        //         BNode NodeDeleted = pointer;
        //         iop(NodeDeleted);
        //         int temp = pointer.value;
        //         pointer.value = NodeDeleted.value;
        //         NodeDeleted.value = temp;
        //         NodeDeleted = null;
        //         return;
        //     }
        // }
        private void Find(BNode node, int num)
        {
            while(node != null)
            {
                if(node.value == num)
                {
                    break;
                }else if(num < node.value)
                {
                    node = node.left;
                }else{
                    node = node.right;
                }
            }
            // return;
        }

        // rightmost node of input node 
        public BNode iop(BNode node)
        {   
            if(node == null) return null;

            BNode ans = node;
            BNode right = iop(node.right);
            
            return right !=null ? right:ans;
        } 
    }
}

