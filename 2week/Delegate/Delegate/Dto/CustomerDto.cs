using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Dto
{
    public class CustomerDto
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
