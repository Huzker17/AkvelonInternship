using LINQ.Interfaces;
using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Services
{
    public class DataSeed : IDataSeed
    {
        public IEnumerable<Consumer> Consumers()
        {
            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer(1, DateTime.Now.AddYears(-20), "KR"),
                new Consumer(2, DateTime.Now.AddYears(-21), "Russia"),
                new Consumer(3, DateTime.Now.AddYears(-22), "KZ"),
                new Consumer(4, DateTime.Now.AddYears(-23), "USA"),
                new Consumer(5, DateTime.Now.AddYears(-20), "KR")
            };
            return consumers;
        }
        public IEnumerable<ConsumerDiscount> ConsumerDiscounts()
        {
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
            return consumerDiscounts;
        }
        public IEnumerable<Good> Goods()
        {
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
            return goods;
        }
        public IEnumerable<PriceOfGood> PriceOfGoods()
        {
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
            return priceOfGoods;
        }
        public IEnumerable<Purchase> Purchases()
        {
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
            return purchases;
        }
        public IEnumerable<Store> Stores()
        {
            List<Store> stores = new List<Store>()
            {
                new Store("Amazon"),
                new Store("AliBaba"),
                new Store("AliExpress")
            };
            return stores;
        }

    }
}
