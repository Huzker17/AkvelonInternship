using Delegate.Dto;
using Delegate.Models;

namespace Delegate.Interfaces
{
    public interface ICustomerService
    {
        public int CreateCustomer(CustomerDto customerDto);
        public void UpdateCustomer(UpdateCustomerDto customerDto);
        public double CalculateDicsount(OrderDto order);

    }
}
