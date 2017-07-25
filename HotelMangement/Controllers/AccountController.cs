using HotelManagements.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Services.Services;
using HotelMangement.Services.Services;
using HotelMangement.ViewModel;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
namespace HotelMangement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICommonUserService _commonUserService;
        public AccountController(ICommonUserService commonUserService)
        {
            _commonUserService = commonUserService;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel userModel)
        {
            if(ModelState.IsValid)
            {
                var userData = _commonUserService.ValidateUser(userModel.Email, userModel.Password);

                var hotelPrincipal = new HotelPrincipalViewModel
                {
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Email = userData.Email,
                    Role = userData.Role

                };

                string hotelPricipalSerialized = JsonConvert.SerializeObject(hotelPrincipal);

                var ticket = new FormsAuthenticationTicket(1, FormsAuthentication.FormsCookieName, DateTime.Now, DateTime.Now.AddMinutes(20), userModel.RemeberMe, hotelPricipalSerialized);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName);

                Response.Cookies.Add(cookie);
                if(hotelPrincipal.Role == "Admin")
                {
                    return RedirectToAction("Home","Index",new { area="AdminArea"});
                }
                return RedirectToAction("Home", "Index", new { area = "CustomerArea" });

            }
            return View();
        }
    }
}