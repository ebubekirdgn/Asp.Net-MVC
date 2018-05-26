using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _15_JQueryileAjaxIslemleri.Controllers
{
    public class HomeController : Controller
    {
        List<string> liste = new List<string>() { "Ali", "Ahmet", "Mehmet" };

        // get kullanımı
        public ActionResult Index()
        {
            return View();
        }

        // load kullanımı
        public ActionResult Index2()
        {
            return View();
        }

        // ajax kullanımı
        public ActionResult Index3()
        {
            return View();
        }

        // ajax ile json verisi
        public ActionResult Index4()
        {
            return View();
        }

        public PartialViewResult VerileriGetir(string veri = null)
        {
            if (!String.IsNullOrEmpty(veri))
                liste.Add(veri);
            System.Threading.Thread.Sleep(1000);
            return PartialView("_DataItemPartial", liste);
        }

        public JsonResult VerileriGetir2(string veri = null)
        {
            if (!String.IsNullOrEmpty(veri))
                liste.Add(veri);
            System.Threading.Thread.Sleep(1000);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }
    }
}