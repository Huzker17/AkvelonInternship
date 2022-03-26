using Newtonsoft.Json;
using Xunit;

namespace Fraction.Tests
{
    public class FractionItemClassTests
    {
        [Fact]
        public void Sum_Of_OldFractionClass_And_NewFractionClass()
        {
            //arrange
            var oldFraction = new FractionItem(1, 2);
            var newFraction = new FractionItem(1, 2);
            var expectedFraction = new FractionItem(2, 2);
            var expectedResult = JsonConvert.SerializeObject(expectedFraction);
            //act
            var result = oldFraction + newFraction;
            var actualResult = JsonConvert.SerializeObject(result);
            //assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotNull(oldFraction);
            Assert.NotNull(newFraction);
            Assert.NotNull(result);
        }
        [Fact]
        public void Divide_OldFractionClass_To_NewFractionClass()
        {
            //arrange
            var oldFraction = new FractionItem(1, 2);
            var newFraction = new FractionItem(1, 2);
            var expectedFraction = new FractionItem(2, 2);
            var expectedResult = JsonConvert.SerializeObject(expectedFraction);
            //act
            var result = oldFraction / newFraction;
            var actualResult = JsonConvert.SerializeObject(result);

            //assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotNull(oldFraction);
            Assert.NotNull(newFraction);
            Assert.NotNull(result);
        }
        [Fact]
        public void Substraction_From_OldFractionClass_A_NewFractionClass()
        {
            //arrange
            var oldFraction = new FractionItem(1, 2);
            var newFraction = new FractionItem(1, 2);
            var expectedFraction = new FractionItem(0, 2);
            var expectedResult = JsonConvert.SerializeObject(expectedFraction);

            //act
            var result = oldFraction - newFraction;
            var actualResult = JsonConvert.SerializeObject(result);

            //assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotNull(oldFraction);
            Assert.NotNull(newFraction);
            Assert.NotNull(result);
        }
        [Fact]
        public void Multiplying_OldFractionClass_To_NewFractionClass()
        {
            //arrange
            var oldFraction = new FractionItem(1, 2);
            var newFraction = new FractionItem(1, 2);
            var expectedFraction = new FractionItem(1, 4);
            var expectedResult = JsonConvert.SerializeObject(expectedFraction);
            //act
            var result = oldFraction * newFraction;
            var actualResult = JsonConvert.SerializeObject(result);

            //assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotNull(oldFraction);
            Assert.NotNull(newFraction);
            Assert.NotNull(result);
        }
        [Fact]
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
            Assert.Equal(firstHashCode, secondHashCode);
            Assert.NotEqual(firstHashCode, thirdHashCode);
            Assert.NotEqual(secondHashCode, thirdHashCode);
            Assert.True(firstHashCode == secondHashCode);
            Assert.False(firstHashCode == thirdHashCode);
            Assert.False(thirdHashCode == secondHashCode);
        }
        [Fact]
        public void Comparing_TwoFractionItem_With_Overrided_Equal()
        {
            //arrange
            var firstFraction = new FractionItem(1, 2);
            var secondFraction = new FractionItem(1, 2);
            var thirdFraction = new FractionItem(1, 4);
            //act
            var EqualsBtwFirstFractionAndSecondFraction = firstFraction.Equals(secondFraction);
            var notEqualsBtwSecondFractionAndThirdFraction = secondFraction.Equals(thirdFraction);
            var notEqualsBtwFirstFractionAndThirdFraction = thirdFraction.Equals(firstFraction);
            //assert
            Assert.True(EqualsBtwFirstFractionAndSecondFraction);
            Assert.False(notEqualsBtwFirstFractionAndThirdFraction);
            Assert.False(notEqualsBtwSecondFractionAndThirdFraction);
        }
    }
}