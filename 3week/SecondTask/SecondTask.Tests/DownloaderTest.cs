using SecondTask.Models;
using System;
using Xunit;

namespace SecondTask.Tests
{
    public class DownloaderTest
    {
        [Fact]
        public void Read_PathToIsCorrect_TheTheLengthOfListInPhotosInDownloaderIs5000()
        {
            //Arrange
            Downloader donwloader = new Downloader("https://jsonplaceholder.typicode.com/photos");
            var expectedResult = 5000;
            donwloader.ReadAndDownload();

            //Act
            var length = donwloader.photos.Count;
            //Assert
            Assert.True(expectedResult == length);
            Assert.Equal(expectedResult, length);

        }
        [Fact]
        public void Read_WhenThePathToJsonApiIsNull_ThrowArgumentNullException()
        {
            //Arrange
            Downloader downloader = new Downloader(null);
            Action test = () => downloader.ReadAndDownload();

            //Act
            var result = Record.Exception(() => test());

            //Assert
            Assert.Throws<ArgumentNullException>(() => downloader.ReadAndDownload());
        }
    }
}