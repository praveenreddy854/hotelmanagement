using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual  ICollection<OrderDetails> OrderDetails { get; set; }
    }
}