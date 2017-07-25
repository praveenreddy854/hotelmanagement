using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.Models
{
    public enum OrderStatus
    {
        New,
        Placed,
        Removed
        
    }
    public class Order
    {
        public int OrderId { get; set; }

        public decimal OrderTotal { get; set; }

        public int AddressId { get; set; }
        public int CustomerId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        
        public virtual ShippingAddress ShippingAddress { get; set; }
        public virtual Customer Customer { get; set; }
        public  ICollection<OrderDetails> OrderDetails { get; set; }

    }
}