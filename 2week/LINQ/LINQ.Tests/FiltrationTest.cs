using LINQ.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace LINQ.Tests
{
    public class FiltrationTest
    {
        [Fact]
        public void FilterByLinq_CreateAListAndGetTheListFromLinqFilter_TheBothListsShouldBeEqual()
        {
            //arrange
            DataSeed DataSeed = new DataSeed();
            Filtration filtration = new Filtration(DataSeed);
            List<string> expectedRes = new List<string>();
            expectedRes.Add("Korea AliBaba 800 05.04.1999");
            expectedRes.Add("USA Amazon 750 05.04.2000");

            //act
            var filters = filtration.FilterByLinq();

            //assert
            Assert.NotEmpty(filters);
            Assert.NotNull(filters);
            Assert.Equal(expectedRes, filters);
        }
        [Fact]
        public void FilterByLinq_SetAsAParameterAsANull_ThrowArgumentNullException()
        {
            //arrange
            DataSeed DataSeed = new DataSeed();
            Filtration filtration = new Filtration(null);
            Action testCode = () => filtration.FilterByLinq();

            //act
            var ex = Record.Exception(testCode);

            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}