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

        // given a number(data) return the node
        public BNode Find(int num)
        {
            BNode res = root;
            while(res != null)
            {
                if(res.value == num)
                {
                    return res;
                }else if(num < res.value)
                {
                    res = res.left;
                }else{
                    res = res.right;
                }
            }
                return null;
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

        // public void Remove(int num)
        // {
        //     BNode NodeToRemove = Find(num);
        //     if(NodeToRemove == null)
        //     {
        //         Console.WriteLine("there is no such a node to remove");
        //     }else if(NodeToRemove.left == null && NodeToRemove.right == null)
        //     {
        //         // no child
        //         Console.WriteLine("function leads to here no child");
        //         NodeToRemove = null;
        //     }else if(NodeToRemove.left != null && NodeToRemove.right == null)
        //     {
        //         // one child left
        //         Console.WriteLine("function leads to here one child left side");
        //         NodeToRemove = NodeToRemove.left;
    
        //     }else if(NodeToRemove.left == null && NodeToRemove.right != null)
        //     {
        //         // one child right
        //         Console.WriteLine("function leads to here one child right side");
        //         NodeToRemove = NodeToRemove.right;
            
        //     }else
        //     {
        //         // two children (need to find iop of Node(num))
        //         Console.WriteLine("function leads to here two children");
        //         BNode ReplaceNode = iop(NodeToRemove.left);
        //         BNode temp = NodeToRemove;
        //         NodeToRemove = ReplaceNode;
        //         ReplaceNode = null;

        //     }
        // }

        public BNode iop(BNode node)
        {
            if(node == null) return null;
            BNode left = iop(node.left);
            BNode ans =  node;
            BNode right = iop(node.right);
            if(right !=null)
            {
                return right;
            }else{
                return ans;
            }
        } 

    }
}

