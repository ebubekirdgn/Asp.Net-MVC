using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _19_Area.Areas.Admin.Controllers
{
    public class Home1Controller : Controller
    {
        // GET: Admin/Home1
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home2", new { area = "Customer" });
        }
        // Farklı bir area'ya yönlendirme
    }
}