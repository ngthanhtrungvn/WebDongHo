using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DuAnWebsite.Models;

namespace DuAnWebsite.Controllers
{
    public class HomeController : Controller
    {
        QL_SHOPDONGHOOEntities db = new QL_SHOPDONGHOOEntities();
        public ActionResult Index()
        {
            var lst = db.DONGHOes.ToList();
            return View(lst);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}