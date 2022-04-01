using Delegate.Dto;
using Delegate.Models;
using Delegate.Interfaces;


namespace Delegate.Services
{
    public class OrderService : IOrderService
    {
        public void CreateOrder(OrderDto orderDto)
        {
            Order order1 = new Order();
            order1.Create(orderDto);
        }
    }
}
