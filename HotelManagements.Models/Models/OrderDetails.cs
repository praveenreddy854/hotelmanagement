
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models.Models
{
   
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }

        public int ItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool IsInKart { get; set; }


        public Order Orders { get; set; }
        public Items Items { get; set; }
        
    }
}
