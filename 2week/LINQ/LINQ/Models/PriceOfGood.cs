using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class PriceOfGood
    {
        public string ArticleNumber { get; private set; }
        public string StoreName { get;private set; }
        public int Price { get;private set;}

        public PriceOfGood(string articleNumber, string storeName, int price)
        {
            ArticleNumber = articleNumber;
            StoreName = storeName;
            Price = price;
        }
    }
}
