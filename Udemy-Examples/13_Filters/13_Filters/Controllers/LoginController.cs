using _13_Filters.Models;
using System.Web.Mvc;
using System.Linq;
using System;

namespace _13_Filters.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View(new SiteUser());
        }

        [HttpPost]
        public ActionResult SignIn(SiteUser model)
        {
            DatabaseContext db = new DatabaseContext();
            SiteUser user = db.SiteUsers.FirstOrDefault(x =>
                x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
            if (user == null)
            {
                ModelState.AddModelError("", "Hatalı kullanıcı adı yada şifre");
                return View(model);
            }
            else
            {
                Session["login"] = user;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Error()
        {
            if (TempData["error"] == null)
                return RedirectToAction("/Home/Index");

            Exception model = TempData["error"] as Exception;
            return View(model);
        }

    }
}