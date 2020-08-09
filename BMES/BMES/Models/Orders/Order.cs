using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;
using BMES.Models.Customer;
using BMES.Models.Address;

namespace BMES.Models.Orders
{
    public class Order:BaseObject
    {
        public decimal OrderTotal { get; set; }

        public decimal OrderItemTotal { get; set; }

        public decimal ShippingCharge { get; set; }

        public long CustomerId { get; set; }

        public CustomerModel Customer { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public long AddressId { get; set; }

        public AddressModel DeliveryAddress { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
