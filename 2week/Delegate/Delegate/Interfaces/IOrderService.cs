using Delegate.Dto;
using Delegate.Models;

namespace Delegate.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(OrderDto orderDto);
    }
}
