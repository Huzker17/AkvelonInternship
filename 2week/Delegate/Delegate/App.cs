using Delegate.Dto;
using Delegate.Interfaces;
using Delegate.Models;


namespace Delegate
{
    public class App
    {
        private readonly ICustomerService customerService;
        private readonly IOrderService orderService;

        public App(ICustomerService customerService, IOrderService orderService)
        {
            this.customerService = customerService;
            this.orderService = orderService;
        }


        /// <summary>
        /// Creation of a new Customer
        /// </summary>
        /// <param name="customer">Take as a param Dto with necessary fields to create a Customer</param>
        public int CreateCustomer(CustomerDto customer)
        {
            return customerService.CreateCustomer(customer);
        }
        /// <summary>
        /// Method for Updating type of Customer
        /// </summary>
        /// <param name="updateCustomerDto">Just a dto, which Contains only udpated Type</param>
        public void UpdateCustomerType(UpdateCustomerDto updateCustomerDto)
        {
            //Create this method for not create a lot of Customers for checking 
            //all options of Discount
            customerService.UpdateCustomer(updateCustomerDto);
        }
        /// <summary>
        /// Calculate the discount for certain Customer
        /// </summary>
        /// <param name="order">The certain order for count discount for Customer</param>
        public double CalculateDiscount(OrderDto order)
        {
            return customerService.CalculateDicsount(order);
        }
        /// <summary>
        /// Creation of Order
        /// </summary>
        /// <param name="orderDto">Dto for necessary fields to create</param>
        public void CreateOrder(OrderDto orderDto)
        {
            orderService.CreateOrder(orderDto);
        }
    }
}
