using Delegate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Models
{
    public class Customer
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        public CustomerType Type { get; private set; }

        public int Create(CustomerDto customerDto)
        {
            Random random = new Random();
            if(customerDto == null)
                throw new ArgumentNullException(nameof(customerDto));
            this.Address = customerDto.Address;
            this.Name = customerDto.Fullname;
            this.Type = customerDto.CustomerType;
            this.Id = this.Id = random.Next(1, 1000);
            return this.Id;
        }
        public void Update(UpdateCustomerDto updateCustomer)
        {
            this.Type = updateCustomer.CustomerType;
        }
    }

}
public enum CustomerType
{
    New,
    SmallPermanent,
    LargePermanent
}
