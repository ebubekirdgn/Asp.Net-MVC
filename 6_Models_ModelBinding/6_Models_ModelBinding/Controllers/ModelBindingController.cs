using _6_Models_ModelBinding.Models;
using System.Web.Mvc;

namespace _6_Models_ModelBinding.Controllers
{
    public class ModelBindingController : Controller
    {
        [HttpGet]
        public ActionResult homepage()
        {
            // Controller dan view'e veri gönderme.
            Kisi kisi = new Kisi();
            kisi.Ad = "Furkan";
            kisi.Soyad = "Işıtan";
            kisi.Yas = 22;
            return View(kisi);  //! Nesne geri döndürülüyor
        }

        [HttpPost]
        public ActionResult homepage(Kisi kisi)
        {
            return View(kisi);  //! Nesne geri döndürülüyor
        }
    }
}