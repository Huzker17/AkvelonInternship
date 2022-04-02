using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Consumer
    {
        public int ConsumerCode { get; private set; }
        public DateTime YearOfBirth { get;private set; }
        public string Address { get; private set; }

        public Consumer(int consumerCode, DateTime yearOfBirth, string address)
        {
            ConsumerCode = consumerCode;
            YearOfBirth = yearOfBirth;
            Address = address;
        }
    }
}
