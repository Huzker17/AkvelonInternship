using Delegate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate.Models
{
    public class Order
    {
        private int Id { get; set; }
        private DateTime OrderTime { get; set; }
        public double Amount { get; private set; }

        private int CustomerId { get; set; }

        public void Create(OrderDto orderDto)
        {
            Random random = new Random();
            if(orderDto == null)
                throw new ArgumentNullException(nameof(orderDto));
            this.OrderTime = orderDto.OrderDate;
            this.Amount = orderDto.Amount;
            this.CustomerId = orderDto.CustomerId;
            this.Id = random.Next(1, 1000);
        }
    }
}
