using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Services
{
    public class DataSeed 
    {
        public IEnumerable<Consumer> Consumers { get; private set; }
        public IEnumerable<Good> Goods { get; private set; }
        public IEnumerable<PriceOfGood> PriceOfGoods { get; private set; }
        public IEnumerable<Purchase> Purchases { get; private set; }
        public IEnumerable<Store> Stores { get; private set; }
        public IEnumerable<ConsumerDiscount> ConsumerDiscounts { get; private set; }

        public DataSeed(IEnumerable<Consumer> consumers, 
            IEnumerable<Good> goods, IEnumerable<PriceOfGood> priceOfGoods, 
            IEnumerable<Purchase> purchases, IEnumerable<Store> stores, 
            IEnumerable<ConsumerDiscount> consumerDiscounts)
        {
            Consumers = consumers;
            Goods = goods;
            PriceOfGoods = priceOfGoods;
            Purchases = purchases;
            Stores = stores;
            ConsumerDiscounts = consumerDiscounts;
        }


    }
}
