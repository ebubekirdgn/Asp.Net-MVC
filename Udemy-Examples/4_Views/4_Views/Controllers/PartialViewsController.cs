using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4_Views.Controllers
{
    public class PartialViewsController : Controller
    {
        public ActionResult homePage()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }
    }
}