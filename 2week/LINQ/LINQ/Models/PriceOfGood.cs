using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class PriceOfGood
    {
        public string ArticleNumner { get; private set; }
        public string StoreName { get;private set; }
        public int Price { get;private set;}

        public PriceOfGood(string articleNumner, string storeName, int price)
        {
            ArticleNumner = articleNumner;
            StoreName = storeName;
            Price = price;
        }
    }
}
