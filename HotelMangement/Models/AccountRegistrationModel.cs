using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HotelMangement.Models
{
    public class AccountRegistrationModel
    {
        [Required(ErrorMessage = "Required FirstName")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Required Last Name ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Userid { get; set; }

        [Required(ErrorMessage = "Required Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [RegularExpression(pattern: @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",ErrorMessage ="Password must contain atleast 8 characters including one alphabet and one numeric")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "password does not match")]
        public string ConformPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number ")]
        public int  PhoneNumber { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "address")]
        public string Address { get; set; }

    }
}