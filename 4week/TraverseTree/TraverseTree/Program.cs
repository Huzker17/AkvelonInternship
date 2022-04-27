// See https://aka.ms/new-console-template for more information
using TraverseTree;

Console.WriteLine("Hello, World!");
Tree<MyClass> tree = new Tree<MyClass>();
//tree.Data = new MyClass("name", 3);
//tree.Right = new Tree<MyClass>();
//tree.Right.Right = new Tree<MyClass>();
//tree.Right.Left = new Tree<MyClass>();
//tree.Right.Data = new MyClass("name", 32);
//tree.Left = new Tree<MyClass>();
//tree.Left.Right = new Tree<MyClass>();
//tree.Left.Left = new Tree<MyClass>();
//tree.Left.Data = new MyClass("name", 33);
Action<MyClass> myAction = x => Console.WriteLine($"{x.Name} : {x.Number}");
DoTree(tree, myAction);
Console.WriteLine("  ");


static void DoTree<T>(Tree<T> tree, Action<T> action)
{
    if (tree == null) return;
    var left = Task.Factory.StartNew(() => DoTree(tree.Left, action));
    var right = Task.Factory.StartNew(() => DoTree(tree.Right, action));
    action(tree.Data);

    try
    {
        Task.WaitAll(left, right);
    }
    catch (AggregateException ex)
    {
        Console.WriteLine(ex.InnerExceptions.First());
    }
}