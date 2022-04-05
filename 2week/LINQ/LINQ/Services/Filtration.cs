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
        private DataSeed dataseed;
        public Filtration(DataSeed dataSeed)
        {
            dataseed = dataSeed;
        }
        public void FilterByLinq()
        {
            var consumers = dataseed.Consumers();
            var consumersDiscounts = dataseed.ConsumerDiscounts();
            var goods = dataseed.Goods();
            var priceOfGoods = dataseed.PriceOfGoods();
            var purchases = dataseed.Purchases();
            var stores = dataseed.Stores();
            var oldest = consumers.OrderBy(x => x.YearOfBirth).Take(1);
            var filteredData = purchases.Where(c => oldest.Any(x => x.ConsumerCode.Equals(c.ConsumerCode)));
            var newfilterData = priceOfGoods.Where(c => filteredData.Any(x => x.ArticleNumber.Equals(c.ArticleNumber)));
            var extraNewFilterData = goods.Where(d => newfilterData.Any(x => x.ArticleNumber.Equals(d.ArticleNumber)));
            var zip1 = oldest.Zip(newfilterData, (first, second) => first.YearOfBirth.ToShortDateString() + " " + second.StoreName +" " + second.Price);
            var zip2 = zip1.Zip(extraNewFilterData, (first, second) => first+" "+ second.CountryOfOrigin);

            var sds = "";
        }
    }
}
