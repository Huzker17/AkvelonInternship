using NUnit.Framework;
using SemanticComparison;

namespace Fraction.Tests
{
    public class FractionClassTests
    {
        [Test]
        public void Sum_OldFractionClass_NewFractionClass()
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

        }
    }
}