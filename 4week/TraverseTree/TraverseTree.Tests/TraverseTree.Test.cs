using System;
using Xunit;

namespace TraverseTree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DoTree_WhenTreeIsNotNull_CreateANewTreeWithBranches()
        {
            //Arrange
            Tree<MyClass> tree = new Tree<MyClass>();
            tree.Right = new Tree<MyClass>();
            tree.Right.Right = new Tree<MyClass>();
            tree.Right.Left = new Tree<MyClass>();
            tree.Right.Data = new MyClass("name", 32);
            tree.Left = new Tree<MyClass>();
            tree.Left.Right = new Tree<MyClass>();
            tree.Left.Left = new Tree<MyClass>();
            tree.Left.Data = new MyClass("name", 33);
            tree.Data = new MyClass("name", 3);
            Func<MyClass, string> myAction = x => $"{ x.Name}  {x.Number}";

            //Act
            Action test = () => tree.DoTree(tree, myAction);

            //Assert
            Assert.NotNull(test);
        }
        [Fact]
        public void DoTree_PassingAsArgumentToFunctionNull_ThrowNullReferenceException()
        {
            //Arrange
            Tree<MyClass> tree = new Tree<MyClass>();
            Func<MyClass, string> myAction = x => $"{ x.Name}  {x.Number}";

            //Act
            Action test = () => tree.DoTree(tree, myAction);
            //Assert
            Assert.Throws<ArgumentNullException>(test);
        }
    }
}