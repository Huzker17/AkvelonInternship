using System;
using System.Linq;
using Task1.Models;
using Xunit;

namespace Task1.Tests
{
    public class DancerTest
    {
        [Fact]
        public void DancerDanceType_SetAsAMusicRock_ExpectedResultIsHeadForRock()
        {
            //Arrange
            Dancer dancer = new Dancer();
            string expectedRes = "Head for Rock";
            //Act
            dancer.Dance("Rock");

            //Assert
            Assert.NotNull(dancer.DanceType);
            Assert.Equal(expectedRes, dancer.DanceType.ToString());
        }
        [Fact]
        public void DancerDanceType_SetAsAMusicLatino_ExpectedResultIsHipsForLatino()
        {
            //Arrange
            Dancer dancer = new Dancer();
            string expectedRes = "Hips for Latino";
            //Act
            dancer.Dance("Latino");

            //Assert
            Assert.NotNull(dancer.DanceType);
            Assert.Equal(expectedRes, dancer.DanceType.ToString());
        }
        [Fact]
        public void DancerDanceType_SetAsAMusicHardbass_ExpectedResultIsElbowforHardbass()
        {
            //Arrange
            Dancer dancer = new Dancer();
            string expectedRes = "Elbow for Hardbass";
            //Act
            dancer.Dance("Hardbass");

            //Assert
            Assert.NotNull(dancer.DanceType);
            Assert.Equal(expectedRes, dancer.DanceType.ToString());
        }
        [Fact]
        public void DancerDanceType_SetAsAMusicNull_ReturnNull()
        {
            //Arrange
            Dancer dancer = new Dancer();
            //Act
            dancer.Dance(null); 

            //Assert
            Assert.Null(dancer.DanceType);
        }
        [Fact]
        public void DancerDanceType_SetAsAMusicIncorrectTypeOfMusic_ReturnNull()
        {
            //Arrange
            Dancer dancer = new Dancer();
            //Act
            dancer.Dance("Raggy"); 

            //Assert
            Assert.Null(dancer.DanceType);
        }

    }
}