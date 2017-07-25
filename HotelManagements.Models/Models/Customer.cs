using HotelManagements.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Models
{
    public class Customer : CommonUser
    {
        public int CustomerId { get; set; }
        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        
    }
}