using Delegate.Dto;


namespace Delegate.Interfaces
{
    public interface IOrderService
    {
        public void CreateOrder(OrderDto orderDto);
    }
}
