using HotelManagement.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models.ModelView
{
    public class ItemMenu
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
        public MenuDetails MenuDetails { get; set; }

    }
}
