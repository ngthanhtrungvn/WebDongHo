﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuAnWebsite.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Admin/Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}