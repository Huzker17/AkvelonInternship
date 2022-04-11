// See https://aka.ms/new-console-template for more information
using LINQ.Models;
using LINQ.Services;

Console.WriteLine("Hello, World!");

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
DataSeed dataSeed = new DataSeed(consumers,goods,priceOfGoods,purchases,stores,consumerDiscounts);
Filtration ft = new Filtration(dataSeed);
var result = ft.FilterByLinq();
Thread.Sleep(1000);