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

        private BNode remove(BNode node, int num)
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

        public void remove2 (int num)
        {
            if(!Contains(num))
            {
                Console.WriteLine("value is not in the tree");
                return;
            }
                BNode pointer = root;
                BNode parent = root; // need a parent pointer so that root and pointer can be linked
                while(pointer != null)
                {   
                    if(num < pointer.value)
                    {
                        parent = pointer;
                        pointer = pointer.left;
                    }else if(num > pointer.value)
                    {
                        parent = pointer;
                        pointer = pointer.right;
                    }else{
                        break;
                    }
                }

                if(pointer.left == null && pointer.right == null)
                {
                    // no children
                    if(pointer == root)
                    {
                        root = null;
                    }else if(parent.left.value == pointer.value)
                    {
                        parent.left = null;
                    }else if(parent.right.value == pointer.value){
                        parent.right = null;
                    }
                    pointer = null;
                }else if(pointer.left != null && pointer.right == null){
                    // one child left
                    if(pointer == root)
                    {
                        root = pointer.left;
                    }else if(parent.left.value == pointer.value)
                    {
                        parent.left = pointer.left;
                    }else if(parent.right.value == pointer.value){
                        parent.right = pointer.left;
                    }
                    pointer = null;
                }else if (pointer.left == null && pointer.right!=null){
                    // one child right
                    if(pointer == root)
                    {
                        root = pointer.right;
                    }else if(parent.left.value == pointer.value)
                    {
                        parent.left = pointer.right;
                    }else if(parent.right.value == pointer.value){
                        parent.right = pointer.right;
                    }
                    pointer = null;
                }else{
                    //  two children
                    // swap value with rightmost node of left subtree
                    BNode RightMostOfLeft = iop(pointer.left);
                    if(pointer == root)
                    {
                        root.value = RightMostOfLeft.value;
                    }else if(parent.left.value == pointer.value)
                    {
                        parent.left.value = RightMostOfLeft.value;
                    }else if(parent.right.value == pointer.value){
                        parent.right.value = RightMostOfLeft.value;
                    }
                    // traverse to the parent node of the rightmost node
                    parent = pointer;
                    pointer = pointer.left;
                    while(pointer.right != null && pointer.right.right != null)
                    {
                        pointer = pointer.right;
                    }
                    // remove rightmost node
                    if(pointer.right != null)
                    {
                        pointer.right = pointer.right.left;
                    }else{
                        parent.left = pointer.left;
                    }
                }
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

