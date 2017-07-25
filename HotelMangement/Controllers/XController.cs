using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangement.Controllers
{
    public class XController : Controller
    {
        // GET: X
        public ActionResult Index()
        {
            return Content("abc");
        }
    }
}