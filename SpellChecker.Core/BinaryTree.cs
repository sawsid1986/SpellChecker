using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker.Core
{
    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeItem<T> Root { get; set; }

        public void Insert(T item)
        {
            if (Root == null)
            {
                Root = new BinaryTreeItem<T>(item);
            }
            else if (Root.Value.CompareTo(item) > 0)
            {
                if (Root.LeftNode == null)
                {
                    Root.LeftNode = new BinaryTree<T>();
                }
                Root.LeftNode.Insert(item);
            }
            else if (Root.Value.CompareTo(item) < 0)
            {
                if (Root.RightNode == null)
                {
                    Root.RightNode = new BinaryTree<T>();
                }
                Root.RightNode.Insert(item);
            }
        }

        public bool Find(T item)
        {
            if (Root == null)
            {
                return false;
            }
            else if (Root.Value.CompareTo(item) == 0)
            {
                return true;
            }
            else if (Root.Value.CompareTo(item) > 0)
            {
                if (Root.LeftNode == null) return false;
                return Root.LeftNode.Find(item);
            }
            else
            {
                if (Root.RightNode == null) return false;
                return Root.RightNode.Find(item);
            }
        }

        public void InsertFromArray(T[] array)
        {
            foreach(var item in array)
            {
                Insert(item);
            }
        }
    }
}
