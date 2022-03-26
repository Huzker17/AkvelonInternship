using Newtonsoft.Json;
using Xunit;


namespace Fraction.Tests
{
    public class MathStuffClassTest
    {
        [Fact]
        public void Common_Divider_Of_15_And_3_Result_()
        {
            //arrange
            var firstDigit = 15;
            var secondDigit = 3;
            var expectedResult = 3;
            
            //act
            var result = MathStuff.GCD(firstDigit, secondDigit);
            //assert
            Assert.Equal(expectedResult, result);
        }
    }
}
