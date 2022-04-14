using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraverseTree
{
    public class Tree<T>
    {
        public Tree<T> Left;
        public Tree<T> Right;
        public T Data;
        public void DoTree<T>(Tree<T> tree, Action<T> action)
        {
            if (tree == null) 
                throw new NullReferenceException();
            Parallel.Invoke(
                () => DoTree(tree.Left, action),
                () => DoTree(tree.Right, action),
                () => action(tree.Data)
            );
        }
    }
}
