using Delegate.Dto;
using Delegate.Services;
using System;
using Xunit;

namespace Delegate.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void CreateCutomer_CreateACorrectDtoAndAsAParameter_CreationOfCustomer()
        {
            //arrange
            var customerService = new CustomerService();
            var Customer = new CustomerDto()
            {
                Fullname = "John Doe",
                Address = "Kazakhstan",
                CustomerType = CustomerType.New
            };
            //act
            var customerId = customerService.CreateCustomer(Customer);
            //assert
            Assert.NotNull(Customer);
            Assert.Equal(12, customerId);
        } 
        [Fact]
        public void CreateCustomer_GivingAsAParameterANull_ThrowArgumentNullException()
        {
            //arrange
            var customerService = new CustomerService();
            Action testCode = () => customerService.CreateCustomer(null);
            //act
            var ex = Record.Exception(testCode);
            //asert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void UpdateCustomer_GivingAsAParameterACorrectDto_CheckingByDiscountChanges_UpdatingOfCustomer()
        {
            //arrange
            var customerService = new CustomerService();
            var createCustomer = new CustomerDto()
            { 
                Fullname = "Patrick",
                Address = "BK",
                CustomerType = CustomerType.New
            };
            var updateCustomer = new UpdateCustomerDto() 
            { 
                CustomerType = CustomerType.LargePermanent
            };
            var Order = new OrderDto { Amount = 11000, CustomerId = 12, OrderDate = DateTime.Now };
            customerService.CreateCustomer(createCustomer);

            CountDiscount discount = customerService.CalculateDicsount;

            //act
            var discountBefore = discount(Order);
            customerService.UpdateCustomer(updateCustomer);
            var discountAfter = discount(Order);

            //asert

            Assert.NotEqual(discountBefore, discountAfter);
        }
        [Fact]
        public void UpdateCustomer_GivingANullAsAParameter_ThrowArgumentNullException()
        {
            //arrange
            var CustomerService = new CustomerService();
            Action testcode = () => CustomerService.UpdateCustomer(null);
            //act
            var ex = Record.Exception(testcode);
            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
        [Fact]
        public void CountADiscount_CountADiscountForDifferentTypesOfCustomers_GetADifferentValuesOfDiscount()
        {
            //arrange
            var customerService = new CustomerService();
            var OrderDto = new OrderDto()
            { 
                Amount = 11000, 
                CustomerId = 12, 
                OrderDate = DateTime.UtcNow
            };
            var Customer = new CustomerDto()
            {
                Address = "Bishkek",
                CustomerType = CustomerType.SmallPermanent,
                Fullname = "John Doe"
            };
            customerService.CreateCustomer(Customer);
            var updateCustomer =  new UpdateCustomerDto() { CustomerType = CustomerType.LargePermanent };
            CountDiscount discount = customerService.CalculateDicsount;
            //act
            var firstDiscount = discount(OrderDto);
            customerService.UpdateCustomer(updateCustomer);
            var secondDiscount = discount(OrderDto);
            //assert
            Assert.False(firstDiscount.Equals(secondDiscount));
            Assert.NotEqual(secondDiscount, firstDiscount);
        }
        [Fact]
        public void CountADiscount_SetAsAParameterNull_ThrowArgumentNullException()
        {
            //arrange
            var customerService = new CustomerService();
            CountDiscount discount = customerService.CalculateDicsount;
            Action test = () => discount(null);
            //act
            var ex = Record.Exception(test);
            //assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}