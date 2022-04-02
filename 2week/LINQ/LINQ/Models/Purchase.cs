using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Purchase
    {
        public int ConsumerCode { get; private set; }
        public string ArticleNumber { get; private set; }
        public string StoreName { get;private set; }

        public Purchase(int consumerCode, string articleNumber, string storeName)
        {
            ConsumerCode = consumerCode;
            ArticleNumber = articleNumber;
            StoreName = storeName;
        }
    }
}
