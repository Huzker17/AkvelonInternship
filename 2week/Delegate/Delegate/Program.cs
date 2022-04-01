// See https://aka.ms/new-console-template for more information
using Delegate;
using Delegate.Dto;
using Delegate.Services;
//Delegate is in CustomerService

CustomerService ServiceCustomer = new CustomerService();
OrderService OrderService = new OrderService();
App app = new App(ServiceCustomer, OrderService);
CountDiscount discount = app.CalculateDiscount;
CustomerDto customerDto = new CustomerDto()
{
    Fullname = "John Doe",
    Address = "Russia",
    CustomerType = CustomerType.New
};
int customerId = app.CreateCustomer(customerDto);

OrderDto orderDto = new OrderDto()
{
    Amount = 9000,
    OrderDate = DateTime.Now,
    CustomerId = customerId
};
app.CreateOrder(orderDto);
var disc = discount(orderDto);
UpdateCustomerDto UpdateCustomerDto = new UpdateCustomerDto()
{
    CustomerType = CustomerType.SmallPermanent,
};
app.UpdateCustomerType(UpdateCustomerDto);
var disc1 = discount(orderDto);
UpdateCustomerDto UpdateCustomerDto2 = new UpdateCustomerDto()
{
    CustomerType = CustomerType.LargePermanent,
};
app.UpdateCustomerType(UpdateCustomerDto2);
var disc2 = discount(orderDto);
OrderDto orderDto2 = new OrderDto()
{
    Amount = 11000,
    OrderDate = DateTime.Now,
    CustomerId = customerId
};
app.CreateOrder(orderDto2);
var disc3 = discount(orderDto2);
Console.WriteLine("Hello, World!");
