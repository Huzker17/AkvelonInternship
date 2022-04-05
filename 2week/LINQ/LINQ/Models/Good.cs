using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            ArticleNumber = CheckTheArticle(articleNumber);
            Category = category;
            CountryOfOrigin = countryOfOrigin;
        }
        private string CheckTheArticle(string aricleNumber)
        {
            string pattern = @"[^0-9a-zA-Z:,]+";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            if (string.IsNullOrEmpty(aricleNumber))
                throw new ArgumentNullException(nameof(aricleNumber));
            if(rg.IsMatch(aricleNumber))
                return aricleNumber;
            throw new ArgumentException();

        }
    }
}
