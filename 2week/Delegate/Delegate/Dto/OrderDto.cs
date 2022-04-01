using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Dto
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public double Amount { get; set; }
    }
}
