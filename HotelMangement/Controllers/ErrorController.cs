﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(Exception ex)
        {
            return View(ex);
        }
    }
}