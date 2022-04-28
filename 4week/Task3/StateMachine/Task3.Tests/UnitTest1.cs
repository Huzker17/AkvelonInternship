using StateMachine.Models;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TypeMock.ArrangeActAssert;
using Xunit;

namespace Task3.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PhotoDownloading_SetCorrectIncomingParamaters_ReturningTasksCompletionAsTrue()
        {
            //Arrange
            Photo photo = new Photo();
            var webClient = new WebClient();
            //Act
            var res = photo.Download("https://via.placeholder.com/600/56a8c2", webClient).GetAwaiter();
            //Add this, cuz the main program's lifetime is short
            Thread.Sleep(2000);
            //Assert
            Assert.True(res.IsCompleted);
        }
        [Fact]
        public void PhotoDownloading_SetIncorrectParams_ReturningTaskCompletionAsFalse()
        {
            //Arrange
            Photo photo = new Photo();

            //Act
            Action res = async () => { await photo.Download(null,null); };

            //Assert
            Assert.Throws<ArgumentNullException>(res);
            Assert.Equal(null, res);
        }
    }
}