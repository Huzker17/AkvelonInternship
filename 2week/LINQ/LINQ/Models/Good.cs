using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Good
    {
        public string ArticleNumber { get; private set; }
        public string Category { get; private set; }
        public string CountryOfOrigin { get; private set; }

        public Good(string articleNumber, string category, string countryOfOrigin)
        {
            ArticleNumber = articleNumber;
            Category = category;
            CountryOfOrigin = countryOfOrigin;
        }
    }
}
