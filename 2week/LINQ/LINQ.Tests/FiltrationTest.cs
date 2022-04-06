using LINQ.Models;
using LINQ.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
            List<ResultModel> expectedRes = new List<ResultModel>();
            expectedRes.Add(new ResultModel { Country = "Korea", Price = 40, Shop = "AliExpress", Year = "05.04.1999" });
            expectedRes.Add(new ResultModel { Country = "Tailand", Price = 30, Shop = "AliExpress", Year = "05.04.1999" });

            //act
            var filters = filtration.FilterByLinq().ToList();
            var equals = expectedRes.Zip(filters).All(item => item.First.Price == item.Second.Price);


            //assert
            Assert.NotEmpty(filters);
            Assert.NotNull(filters);
            Assert.True(equals);
            filters.Should().AllBeOfType(typeof(ResultModel));
            Assert.Contains(expectedRes, x => x.Year == filters[0].Year 
            && x.Country == filters[0].Country && x.Shop == filters[0].Shop && x.Price == filters[0].Price);
        }

    }
}