using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            //ViewData["text1"] = "Murat Başeren";
            //ViewData["check1"] = true;

            //ViewBag.text1 = "Murat Başeren";
            //ViewBag.check1 = true;

            TempData["text1"] = "Murat Başeren";
            TempData["check1"] = true;

            return View();
        }

        public ActionResult about()
        {
            ViewBag.text1 = "Murat Başeren";
            ViewBag.check1 = true;
            ViewBag.list1 =
                new SelectListItem[]
                {
                    new SelectListItem() { Text = "Kadir" },
                    new SelectListItem() { Text = "Murat" },
                    new SelectListItem() { Text = "Başeren" }
                };

            TempData["t1"] = ViewBag.text1;
            TempData["c1"] = ViewBag.check1;

            return View();
        }

        public ActionResult contact()
        {
            ViewBag.text1 = TempData["t1"];
            ViewBag.check1 = TempData["c1"];

            return View();
        }


        public ActionResult blog()
        {
            ViewBag.text1 = TempData["t1"];
            ViewBag.check1 = TempData["c1"];

            return View();
        }
    }
}