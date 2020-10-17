using System;

namespace binarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BST tree = new BST();

            tree.AddNode(new BNode(100));
            // left height is 2
            tree.AddNode(new BNode(50));
            tree.AddNode(new BNode(25));
            tree.AddNode(new BNode(90));
            // right height is 2
            tree.AddNode(new BNode(115));
            tree.AddNode(new BNode(105));
            tree.AddNode(new BNode(125));


            tree.AddNode(new BNode(124));
            tree.AddNode(new BNode(126));
            tree.AddNode(new BNode(123));
            
            tree.AddNode(new BNode(24));
            tree.AddNode(new BNode(23));
            tree.AddNode(new BNode(21));
            tree.AddNode(new BNode(20));
            tree.AddNode(new BNode(122));
            tree.AddNode(new BNode(127));
            tree.AddNode(new BNode(128));

            // Console.WriteLine($"root is {tree.root.value}");
            // Console.WriteLine($"root.left is {tree.root.left.value}");
            // Console.WriteLine($"root.left.right is {tree.root.left.right.value}");
            // Console.WriteLine($"root.right is {tree.root.right.value}");
            // Console.WriteLine($"root.right.right is {tree.root.right.right.value}");
            // Console.WriteLine($"root.right.left is {tree.root.right.left.value}");

            // Console.WriteLine($"Max is {tree.FindMax()}");
            // Console.WriteLine($"Min is {tree.FindMin()}");

            // Console.WriteLine(tree.Contains(-11)); // false
            // Console.WriteLine(tree.Contains(100)); // true
            // Console.WriteLine(tree.Contains(190)); // false
            // Console.WriteLine(tree.Contains(90)); // true
            // Console.WriteLine(tree.BSTsize(tree.root));
            // Console.WriteLine(tree.Height(tree.root));
            tree.Remove(20);
            tree.Remove(20);
            
        }
    }
}
