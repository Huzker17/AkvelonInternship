using NUnit.Framework;
using SemanticComparison;

namespace Fraction.Tests
{
    public class FractionClassTests
    {
        [Test]
        public void Sum_Of_OldFractionClass_And_NewFractionClass()
        {
            //arrange
            var oldFraction=new FractionItem(1,2);
            var newFraction=new FractionItem(1,2);
            var expectedFraction = new FractionItem(2,2);
            var expectedResult= new Likeness<FractionItem,FractionItem>(expectedFraction);
            //act
            var result=oldFraction+newFraction;
            //assert
            Assert.AreEqual(expectedResult, result);
            Assert.NotZero(oldFraction.Denominator);
            Assert.NotZero(newFraction.Denominator);
            Assert.IsNotNull(oldFraction);
            Assert.IsNotNull(newFraction);
            Assert.IsNotNull(result);
            Has.Exactly(newFraction.Denominator);
            Has.Exactly(oldFraction.Denominator);
        } 
        [Test]
        public void Divide_OldFractionClass_To_NewFractionClass()
        {
            //arrange
            var oldFraction=new FractionItem(1,2);
            var newFraction=new FractionItem(1,2);
            var expectedFraction = new FractionItem(2,2);
            var expectedResult= new Likeness<FractionItem,FractionItem>(expectedFraction);
            //act
            var result=oldFraction / newFraction;
            //assert
            Assert.AreEqual(expectedResult, result);
            Assert.NotZero(oldFraction.Denominator);
            Assert.NotZero(newFraction.Denominator);
            Assert.IsNotNull(oldFraction);
            Assert.IsNotNull(newFraction);
            Assert.IsNotNull(result);
            Has.Exactly(newFraction.Denominator);
            Has.Exactly(oldFraction.Denominator);
        }
        [Test]
        public void Substraction_From_OldFractionClass_A_NewFractionClass()
        {
            //arrange
            var oldFraction=new FractionItem(1,2);
            var newFraction=new FractionItem(1,2);
            var expectedFraction = new FractionItem(0,2);
            var expectedResult= new Likeness<FractionItem,FractionItem>(expectedFraction);
            //act
            var result=oldFraction - newFraction;
            //assert
            Assert.AreEqual(expectedResult, result);
            Assert.NotZero(oldFraction.Denominator);
            Assert.NotZero(newFraction.Denominator);
            Assert.IsNotNull(oldFraction);
            Assert.IsNotNull(newFraction);
            Assert.IsNotNull(result);
            Has.Exactly(newFraction.Denominator);
            Has.Exactly(oldFraction.Denominator);
        }
        [Test]
        public void Multiplying_OldFractionClass_To_NewFractionClass()
        {
            //arrange
            var oldFraction=new FractionItem(1,2);
            var newFraction=new FractionItem(1,2);
            var expectedFraction = new FractionItem(1,4);
            var expectedResult= new Likeness<FractionItem,FractionItem>(expectedFraction);
            //act
            var result=oldFraction * newFraction;
            //assert
            Assert.AreEqual(expectedResult, result);
            Assert.NotZero(oldFraction.Denominator);
            Assert.NotZero(newFraction.Denominator);
            Assert.IsNotNull(oldFraction);
            Assert.IsNotNull(newFraction);
            Assert.IsNotNull(result);
            Has.Exactly(newFraction.Denominator);
            Has.Exactly(oldFraction.Denominator);
        }
        [Test]
        public void GetHashCode_Overrided_Fucntion()
        {
            //arrange
            var firstFraction = new FractionItem(1, 2);
            var secondFraction = new FractionItem(1, 2);
            var thirdFraction = new FractionItem(1, 4);
            //act
            var firstHashCode = firstFraction.GetHashCode();
            var secondHashCode = secondFraction.GetHashCode();  
            var thirdHashCode = thirdFraction.GetHashCode();
            //assert
            Assert.AreEqual(firstHashCode, secondHashCode);
            Assert.AreNotEqual(firstHashCode, thirdHashCode);
            Assert.AreNotEqual(secondHashCode, thirdHashCode);
            Assert.IsTrue(firstHashCode == secondHashCode);
            Assert.IsFalse(firstHashCode == thirdHashCode);
            Assert.IsFalse(thirdHashCode == secondHashCode);
        }
    }
}