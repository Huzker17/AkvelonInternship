using Delegate.Dto;
using Delegate.Models;
using Delegate.Interfaces;


namespace Delegate.Services
{
    public class OrderService : IOrderService
    {
        public Order CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));
            Order order1 = new Order();
            order1.Create(orderDto);
            return order1;
        }
    }
}
