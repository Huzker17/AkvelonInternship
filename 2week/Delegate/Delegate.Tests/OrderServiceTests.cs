using Delegate.Dto;
using Delegate.Services;
using System;
using Xunit;

namespace Delegate.Tests
{
    public class OrderServiceTests
    {
        [Fact]
        public void CreateOrder_CreateACorrectDtoAndAsAParameter_CreationOfOrder()
        {
            //arrange
            var OrderService = new OrderService();
            var OrderDto = new OrderDto()
            {
                CustomerId = 2,
                OrderDate = System.DateTime.Now,
                Amount = 1000
            };
            //act
            var order = OrderService.CreateOrder(OrderDto);
            //assert
            Assert.NotNull(order);
            Assert.Equal(OrderDto.Amount, order.Amount);
        } 
        [Fact]
        public void CreateOrder_GivingAsAParameterANull_CreationOfOrder()
        {
            //arrange
            var OrderService = new OrderService();
            Action testCode = () => OrderService.CreateOrder(null);
            //act
            var ex = Record.Exception(testCode);
            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}