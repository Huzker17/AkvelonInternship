using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class ResultModel
    {
        public string Country { get; set; }
        public string Shop { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as ResultModel;

            if (item == null)
            {
                return false;
            }

            return this.Country.Equals(item.Country) && this.Year.Equals(item.Year) && this.Price.Equals(Price) && this.Shop.Equals(item.Shop);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + this.Country.GetHashCode();
                hash = hash * 23 + this.Price.GetHashCode();
                hash = hash * 23 + this.Shop.GetHashCode();
                hash = hash * 23 + this.Year.GetHashCode();
                return hash;
            }
        }
    }
}
