using System;
using System.Linq;
using Task1.Models;
using Xunit;

namespace Task1.Tests
{
    public class DanceHallTests
    {
        [Fact]
        public void PlayMusicAndDance_DancersAndPlayListAreNotNull_EverybodyAreDancing_GetChangedValueForDanceType()
        {
            //Arrange
            DataSeed seed = new DataSeed();
            var playList = seed.PlayList();
            var dancers = seed.DancerList();
            var dancerStyle = dancers.First().DanceType;
            DanceHall danceHall = new DanceHall(dancers.ToList(), playList.ToList());

            //Act
            danceHall.PlayMusicAndDance();
            var newStyle = dancers.First().DanceType;

            //Assert
            Assert.NotNull(danceHall.Dancers);
            Assert.NotNull(danceHall.Music);
            Assert.NotEqual(dancerStyle, newStyle);
        }

        [Fact]
        public void PlayMusicAndDance_DancersAndPlayListAreNull_ThrowArgumentNullException()
        {
            //Arrange
            DanceHall danceHall = new DanceHall(null, null);
            Action testCode = () => danceHall.PlayMusicAndDance();
            //act
            var ex = Record.Exception(testCode);
            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void PlayMusicAndDance_OneArgumentIsNull_ThrowArgumentNullException()
        {
            //Arrange
            DataSeed seed = new DataSeed();
            DanceHall danceHall = new DanceHall(null, seed.PlayList().ToList());
            Action testCode = () => danceHall.PlayMusicAndDance();
            //act
            var ex = Record.Exception(testCode);
            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}