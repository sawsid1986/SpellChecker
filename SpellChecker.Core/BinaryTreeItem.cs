using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Core
{
    public class BinaryTreeItem<T> where T : IComparable
    {
        public BinaryTreeItem(T value)
        {
            Value = value;
        }

        public T Value { get; set; }        
        public BinaryTree<T> LeftNode { get; set; }
        public BinaryTree<T> RightNode { get; set; }
    }
}
