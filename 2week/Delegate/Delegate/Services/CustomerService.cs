using Delegate.Dto;
using Delegate.Models;
using Delegate.Interfaces;

namespace Delegate.Services
{
    //Delegate
    public delegate double CountDiscount(OrderDto order);


    public class CustomerService : ICustomerService
    {
        //This a field, because we don't have a DataLayer
        //For work only with certain Customer
        private Customer customer;
        public int CreateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null)
                throw new ArgumentNullException();
            this.customer = new Customer();
            return customer.Create(customerDto);
        }
        public void UpdateCustomer(UpdateCustomerDto updateCustomer)
        {
            if(updateCustomer == null)
                throw new ArgumentNullException(nameof(updateCustomer));
            customer.Update(updateCustomer);
        }
        public double CalculateDicsount(OrderDto order)
        {
            double dicsount = 0;
            if (order == null)
                throw new ArgumentNullException(nameof(order));
            if(customer.Type == CustomerType.New)
                dicsount = 0;
            if (customer.Type == CustomerType.SmallPermanent)
                dicsount = 5;
            if(customer.Type == CustomerType.LargePermanent)
            {
                if (order.Amount < 10000)
                    dicsount = 10;
                if (order.Amount > 10000)
                    dicsount = 15;
            }
            return dicsount;
        }
    }
}
