using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Interfaces
{
    public interface IDataSeed
    {
        public IEnumerable<Consumer> Consumers();
        public IEnumerable<ConsumerDiscount> ConsumerDiscounts();
        public IEnumerable<Good> Goods();
        public IEnumerable<PriceOfGood> PriceOfGoods();
        public IEnumerable<Purchase> Purchases();
        public IEnumerable<Store> Stores();
    }
}
