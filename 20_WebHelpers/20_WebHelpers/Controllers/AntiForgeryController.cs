using _20_WebHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20_WebHelpers.Controllers
{
    public class AntiForgeryController : Controller
    {
        public ActionResult Test()
        {
            return View(Veritabani.Veriler);
        }

        // ValidateAntiForgeryToken => Sayfanın token eşleşmesini doğrulamadan post işlemini çalıştırmaz.
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Test(int id)
        {
            Veritabani.Veriler.RemoveAt(id);
            return RedirectToAction("Test");
        }
        // ValidateAntiForgeryToken yöntemi kullanıldığında FakeTest() action'ı çalışmayacak.
        // Post işlemi yapmak için Test() sayfasından post gönderilmesi gerekecek.

        public ActionResult FakeTest()
        {
            return View();
        }

    }
}