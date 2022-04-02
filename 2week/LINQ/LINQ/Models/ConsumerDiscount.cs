using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class ConsumerDiscount
    {
        public int ConsumerCode { get;private set; }
        public string StoreName { get;private set; }
        public double Discount { get;private set; }

        public ConsumerDiscount(int consumerCode, string storeName, double discount)
        {
            ConsumerCode = consumerCode;
            StoreName = storeName;
            Discount = discount;
        }
    }
}
