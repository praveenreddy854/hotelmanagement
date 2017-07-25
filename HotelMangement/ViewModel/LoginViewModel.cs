using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMangement.ViewModel
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}