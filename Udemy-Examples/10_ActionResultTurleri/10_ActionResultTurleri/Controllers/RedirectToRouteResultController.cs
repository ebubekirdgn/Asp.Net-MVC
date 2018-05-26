using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _10_ActionResultTürleri.Controllers
{
    public class RedirectToRouteResultController : Controller
    {
        static List<string> list = new List<string>();

        // GET: RedirectToRouteResult
        public ActionResult Index()
        {
            ViewBag.Liste = list;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string ad, string soyad)
        {
            list.Add(ad + " " + soyad);

            // Bir url oluşturup, oluşturulan url' e yönlendirir.
            return new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(
                    new
                    {
                        action = "Index",
                        controller = "RedirectToRouteResult",
                        kod = Guid.NewGuid().ToString()
                    }));
        }
    }
}