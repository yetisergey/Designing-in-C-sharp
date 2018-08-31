namespace Generics.BinaryTrees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] items) where T : IComparable
        {
            var tree = new BinaryTree<T>();
            foreach (T item in items)
                tree.Add(item);
            return tree;
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        public BinaryTree<T> Left;
        public BinaryTree<T> Right;
        public T Value;
        private bool IsAdded = false;

        public void Add(T item)
        {
            SetValue(this, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Left != null)
                foreach (var i in Left)
                    yield return i;
            if (!IsAdded)
                yield break;
            else
                yield return Value;

            if (Right != null)
                foreach (var i in Right)
                    yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var r = GetEnumerator();
            return r;
        }

        private void SetValue(BinaryTree<T> tree, T item)
        {
            if (tree.Value.CompareTo(default(T)) == 0 && tree.IsAdded == false)
            {
                tree.Value = item;
                tree.IsAdded = true;
                return;
            }

            if (item.CompareTo(tree.Value) <= 0)
            {
                if (tree.Left == null)
                    tree.Left = new BinaryTree<T>();
                SetValue(tree.Left, item);
            }
            else
            {
                if (tree.Right == null)
                    tree.Right = new BinaryTree<T>();
                SetValue(tree.Right, item);
            }
        }
    }
}