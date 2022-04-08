using LINQ.Interfaces;
using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Services
{
    //I know that it is not a good to create this class, but I have to create this for tests
    //Because I should to do other tasks. If I'll have a free time, I'll come back
    public class EmptyDataSeed : IDataSeed
    {
        public IEnumerable<ConsumerDiscount> ConsumerDiscounts()
        {
            return Enumerable.Empty<ConsumerDiscount>();
        }

        public IEnumerable<Consumer> Consumers()
        {
            return Enumerable.Empty<Consumer>();
        }

        public IEnumerable<Good> Goods()
        {
            return Enumerable.Empty<Good>();
        }

        public IEnumerable<PriceOfGood> PriceOfGoods()
        {
            return Enumerable.Empty<PriceOfGood>();
        }

        public IEnumerable<Purchase> Purchases()
        {
            return Enumerable.Empty<Purchase>();
        }

        public IEnumerable<Store> Stores()
        {
            return Enumerable.Empty<Store>();
        }
    }
}
