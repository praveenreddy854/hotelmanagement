using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Models
{
    public class ShippingAddress
    {
        [Key]
        public int AddressId {get;set;}
        public int CustomerId{get;set;}

        [Required]
        public string Street{get;set;}

        [Required]
        public string City{get;set;}

        [Required]
        public string State{get;set;}

        [Required]
        public string Zip{get;set;}
        
        public Customer Customer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}