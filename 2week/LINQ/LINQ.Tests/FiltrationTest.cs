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
            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer(1, DateTime.Now.AddYears(-20), "KR"),
                new Consumer(2, DateTime.Now.AddYears(-21), "Russia"),
                new Consumer(3, DateTime.Now.AddYears(-22), "KZ"),
                new Consumer(4, DateTime.Now.AddYears(-23), "USA"),
                new Consumer(5, DateTime.Now.AddYears(-20), "KR")
            };

            List<ConsumerDiscount> consumerDiscounts = new List<ConsumerDiscount>()
            {
                new ConsumerDiscount(1, "Amazon", 12),
                new ConsumerDiscount(2, "AliBaba", 20),
                new ConsumerDiscount(2, "AliExpress", 15),
                new ConsumerDiscount(3, "Amazon", 3),
                new ConsumerDiscount(3, "AliExpress", 15),
                new ConsumerDiscount(4, "AliExpress", 5),
                new ConsumerDiscount(5, "Amazon", 12),
            };

            List<Good> goods = new List<Good>()
            {
                new Good("AA12-1212", "Laptop", "China"),
                new Good("QA14-1115", "GPU", "Korea"),
                new Good("OP32-1231", "CPU", "USA"),
                new Good("LP12-5412", "Laptop", "China"),
                new Good("PC42-3412", "PC", "USA"),
                new Good("QA14-1111", "GPU", "Korea"),
                new Good("MN72-6782", "Monitor", "Tailand"),
            };

            List<PriceOfGood> priceOfGoods = new List<PriceOfGood>()
            {
                new PriceOfGood("AA12-1212", "Amazon",1200),
                new PriceOfGood("QA14-1115", "AliBaba",800),
                new PriceOfGood("OP32-1231", "AliExpress",900),
                new PriceOfGood("LP12-5412", "AliBaba",1000),
                new PriceOfGood("PC42-3412", "Amazon",750),
                new PriceOfGood("QA14-1111", "AliExpress",800),
                new PriceOfGood("MN72-6782", "AliExpress",600),
            };
            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase(1,"AA12-1212", "Amazon"),
                new Purchase(3,"QA14-1115", "AliBaba"),
                new Purchase(2,"OP32-1231", "AliExpress"),
                new Purchase(1,"LP12-5412", "AliBaba"),
                new Purchase(3,"PC42-3412", "Amazon"),
                new Purchase(4,"QA14-1111", "AliExpress"),
                new Purchase(4,"MN72-6782", "AliExpress"),
            };
            List<Store> stores = new List<Store>()
            {
                new Store("Amazon"),
                new Store("AliBaba"),
                new Store("AliExpress")
            };
            DataSeed DataSeed = new DataSeed(consumers,goods,priceOfGoods,purchases,stores,consumerDiscounts);
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
        }

        [Fact]
        public void FilterByLinq_SetANullInsteadOfDataSeed_ThrowArgumentNullException()
        {
            //arrange
            List<Consumer> consumers = new List<Consumer>();

            List<ConsumerDiscount> consumerDiscounts = new List<ConsumerDiscount>()
            {
                new ConsumerDiscount(1, "Amazon", 12),
                new ConsumerDiscount(2, "AliBaba", 20),
                new ConsumerDiscount(2, "AliExpress", 15),
                new ConsumerDiscount(3, "Amazon", 3),
                new ConsumerDiscount(3, "AliExpress", 15),
                new ConsumerDiscount(4, "AliExpress", 5),
                new ConsumerDiscount(5, "Amazon", 12),
            };

            List<Good> goods = new List<Good>()
            {
                new Good("AA12-1212", "Laptop", "China"),
                new Good("QA14-1115", "GPU", "Korea"),
                new Good("OP32-1231", "CPU", "USA"),
                new Good("LP12-5412", "Laptop", "China"),
                new Good("PC42-3412", "PC", "USA"),
                new Good("QA14-1111", "GPU", "Korea"),
                new Good("MN72-6782", "Monitor", "Tailand"),
            };

            List<PriceOfGood> priceOfGoods = new List<PriceOfGood>()
            {
                new PriceOfGood("AA12-1212", "Amazon",1200),
                new PriceOfGood("QA14-1115", "AliBaba",800),
                new PriceOfGood("OP32-1231", "AliExpress",900),
                new PriceOfGood("LP12-5412", "AliBaba",1000),
                new PriceOfGood("PC42-3412", "Amazon",750),
                new PriceOfGood("QA14-1111", "AliExpress",800),
                new PriceOfGood("MN72-6782", "AliExpress",600),
            };
            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase(1,"AA12-1212", "Amazon"),
                new Purchase(3,"QA14-1115", "AliBaba"),
                new Purchase(2,"OP32-1231", "AliExpress"),
                new Purchase(1,"LP12-5412", "AliBaba"),
                new Purchase(3,"PC42-3412", "Amazon"),
                new Purchase(4,"QA14-1111", "AliExpress"),
                new Purchase(4,"MN72-6782", "AliExpress"),
            };
            List<Store> stores = new List<Store>()
            {
                new Store("Amazon"),
                new Store("AliBaba"),
                new Store("AliExpress")
            };
            DataSeed seed = new DataSeed(consumers,goods,priceOfGoods,purchases,stores,consumerDiscounts);
            Filtration filtration = new Filtration(seed);

            //act
            var result = filtration.FilterByLinq();

            //asert
            Assert.Null(result);
        }
        [Fact]
        public void FilterByLinq_SetANullConsumersOfDataSeed_ReturnNull()
        {
            //arrange
            Filtration filtration = new Filtration(null);
            Action result = () => filtration.FilterByLinq();

            //act
            var ex = Record.Exception(result);

            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void FilterByLinq_SetAsAParameterEmptyDataSeed_ReturnNull()
        {
            //Arrange
            var consumers = new List<Consumer>();
            var goods = new List<Good>();
            var purchases = new List<Purchase>();
            var discounts = new List<ConsumerDiscount>();
            var stores = new List<Store>();
            var priceOfGoods = new List<PriceOfGood>();
            DataSeed seed = new DataSeed(consumers, goods, priceOfGoods, purchases, stores, discounts);
            Filtration filtration = new Filtration(seed);

            //Act
            var result = filtration.FilterByLinq();
            
            //Assert
            Assert.Null(result);

        }

        [Fact]
        public void FilterByLinq_FillToConsumerPurchasesTwoTimeOneItem_ReturnNull()
        {
            //Arrange
            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer(1, DateTime.Now.AddYears(-20), "KR"),
                new Consumer(2, DateTime.Now.AddYears(-21), "Russia"),
                new Consumer(3, DateTime.Now.AddYears(-22), "KZ"),
                new Consumer(4, DateTime.Now.AddYears(-23), "USA"),
                new Consumer(5, DateTime.Now.AddYears(-20), "KR")
            };

            List<ConsumerDiscount> consumerDiscounts = new List<ConsumerDiscount>()
            {
                new ConsumerDiscount(1, "Amazon", 12),
                new ConsumerDiscount(2, "AliBaba", 20),
                new ConsumerDiscount(2, "AliExpress", 15),
                new ConsumerDiscount(3, "Amazon", 3),
                new ConsumerDiscount(3, "AliExpress", 15),
                new ConsumerDiscount(4, "AliExpress", 5),
                new ConsumerDiscount(5, "Amazon", 12),
            };

            List<Good> goods = new List<Good>()
            {
                new Good("AA12-1212", "Laptop", "China"),
                new Good("QA14-1115", "GPU", "Korea"),
                new Good("OP32-1231", "CPU", "USA"),
                new Good("LP12-5412", "Laptop", "China"),
                new Good("PC42-3412", "PC", "USA"),
                new Good("QA14-1111", "GPU", "Korea"),
                new Good("MN72-6782", "Monitor", "Tailand"),
            };

            List<PriceOfGood> priceOfGoods = new List<PriceOfGood>()
            {
                new PriceOfGood("AA12-1212", "Amazon",1200),
                new PriceOfGood("QA14-1115", "AliBaba",800),
                new PriceOfGood("OP32-1231", "AliExpress",900),
                new PriceOfGood("LP12-5412", "AliBaba",1000),
                new PriceOfGood("PC42-3412", "Amazon",750),
                new PriceOfGood("QA14-1111", "AliExpress",800),
                new PriceOfGood("MN72-6782", "AliExpress",600),
            };
            List<Purchase> purchases = new List<Purchase>()
            {
                new Purchase(1,"AA12-1212", "Amazon"),
                new Purchase(3,"QA14-1115", "AliBaba"),
                new Purchase(2,"OP32-1231", "AliExpress"),
                new Purchase(1,"LP12-5412", "AliBaba"),
                new Purchase(3,"PC42-3412", "Amazon"),
                new Purchase(4,"QA14-1111", "AliExpress"),
                new Purchase(4,"QA14-1111", "AliExpress"),
                new Purchase(4,"MN72-6782", "AliExpress"),
            };
            List<Store> stores = new List<Store>()
            {
                new Store("Amazon"),
                new Store("AliBaba"),
                new Store("AliExpress")
            };
            DataSeed seed = new DataSeed(consumers, goods, priceOfGoods, purchases, stores, consumerDiscounts);
            Filtration filtration = new Filtration(seed);
            List<ResultModel> expectedRes = new List<ResultModel>();
            expectedRes.Add(new ResultModel { Country = "Korea", Price = 40, Shop = "AliExpress", Year = "05.04.1999" });
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
        }

    }
}