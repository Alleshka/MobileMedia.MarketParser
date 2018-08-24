using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileMedia.MarketParser.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ViewResult Task1()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Task2()
        {
            return View();
        }

        public ActionResult AppInfoViewer(String app)
        {
            return PartialView(app);
        }
    }
}
