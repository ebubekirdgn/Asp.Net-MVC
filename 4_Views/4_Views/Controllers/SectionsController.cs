using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_Views.Controllers
{
    public class SectionsController : Controller
    {
        // Ana Sayfa
        public ActionResult homePage()
        {
            return View();
        }

        // Hakkında
        public ActionResult about()
        {
            return View();
        }

        // İletişim
        public ActionResult contact()
        {
            return View();
        }

        // Blog
        public ActionResult blog()
        {
            return View();
        }
    }
}