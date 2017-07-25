using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagement.Models.Models
{
    
    public enum MenuDetails
    {
        BreakFast,
        Lunch ,
        Snacks
    }

    public enum Timings
    {
        _9amTo10pm,
        _11amTo10pm,
        _4pmTo7pm

    }
    public class Menu
    {
        public int MenuId { get; set; }

        [Required]
        [Display(Name ="Food Type")]
        public MenuDetails MenuDetails { get; set; }

        [Required]
        public Timings Timings { get; set; }

        public virtual ICollection<Items> Item { get; set; }
    }
}