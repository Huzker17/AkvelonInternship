using System;
using System.IO;
using Task2.Models;
using Xunit;

namespace Task2.Tests
{
    public class DownloaderTests
    {
        [Fact]
        public void DownloadingFile_WhenWeHaveCorrectUriAndCorrectPath_GetTheResultModel()
        {
            //Arrange
            string destinationFolder = @"D:\Akvelon\4week\Task2\Task2\Files";
            Downloader downloader = new Downloader();
            var expectRes = new ResultModel(@"D:\Akvelon\4week\Task2\Task2\Files\56a8c2", 2165, new TimeSpan(71), 5);

            //Act
            var result = downloader.Download("https://via.placeholder.com/600/56a8c2", destinationFolder, 5);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectRes.FilePath, result.FilePath);
            Assert.Equal(expectRes.Size, result.Size);
            Assert.Equal(expectRes.ParallelDownloads, result.ParallelDownloads);

        }
        [Fact]
        public void DownloadingFile_SetAsAParameterNull_ThrowArgumentNullException()
        {
            //Arrange
            Downloader downloader = new Downloader();

            //Act
            Action res = () => downloader.Download(null, null, 5);

            //Assert
            Assert.NotNull(res);
            Assert.Throws<ArgumentNullException>(res);

        }

    }
}