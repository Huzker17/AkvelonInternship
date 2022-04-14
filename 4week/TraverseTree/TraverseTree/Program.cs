// See https://aka.ms/new-console-template for more information
using TraverseTree;

Console.WriteLine("Hello, World!");
Tree<MyClass> tree = new Tree<MyClass>();
Action<MyClass> myAction = x => Console.WriteLine($"{ x.Name}  {x.Number}");
tree.DoTree(tree, myAction);
