using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Services
{
    public class Filtration
    {
        private readonly DataSeed dataseed;
        public Filtration(DataSeed dataSeed)
        {
            dataseed = dataSeed;
        }
        public IEnumerable<ResultModel>? FilterByLinq()
        {
            if(this.dataseed == null)
                throw new ArgumentNullException();
            var consumers = dataseed.Consumers;
            var consumersDiscounts = dataseed.ConsumerDiscounts;
            var goods = dataseed.Goods;
            var priceOfGoods = dataseed.PriceOfGoods;
            var purchases = dataseed.Purchases;
            var stores = dataseed.Stores;
            if (consumers.Count() == 0 || stores.Count() == 0 || goods.Count() == 0)
                return null;
            List<ResultModel> result = purchases.Join(consumers, purchase
                                => purchase.ConsumerCode, consumer => consumer.ConsumerCode,
                                (purchase, consumer) => new
                                {
                                    YearOfBirth = consumer.YearOfBirth,
                                    ArticleNumber = purchase.ArticleNumber,
                                    StoreName = purchase.StoreName,
                                    ConsumerCode = consumer.ConsumerCode
                                })
                                .OrderBy(x => x.YearOfBirth).GroupBy(x => x.ConsumerCode).Take(1).
                                SelectMany(x => x.Select(x => new 
                                {
                                    YearOfBirth = x.YearOfBirth,
                                    ArticleNumber = x.ArticleNumber,
                                    StoreName = x.StoreName,
                                    ConsumerCode = x.ConsumerCode
                                }))
                                .Join(priceOfGoods, purchase => purchase.ArticleNumber, price => price.ArticleNumber,
                                (purchase, price) => new
                                {
                                    storeName = purchase.StoreName,
                                    year = purchase.YearOfBirth,
                                    Article = purchase.ArticleNumber,
                                    Price = price.Price,
                                    ConsumerCode = purchase.ConsumerCode
                                }).
                                Join(goods, data => data.Article, good => good.ArticleNumber,
                                (data, good) => new 
                                {
                                    ConsumerCode = data.ConsumerCode,
                                    Country = good.CountryOfOrigin,
                                    Shop = data.storeName,
                                    Year = data.year.ToShortDateString(),
                                    Price = data.Price
                                }).Join(consumersDiscounts, resultModel => resultModel.ConsumerCode, discount => discount.ConsumerCode,
                                (model, discount) => new ResultModel
                                {
                                    Country = model.Country,
                                    Shop = model.Shop,
                                    Year = model.Year,
                                    Price = (model.Price * discount.Discount) / 100
                                }).OrderBy(x => x.Country).ToList();
            return result;

        }
    }
}
