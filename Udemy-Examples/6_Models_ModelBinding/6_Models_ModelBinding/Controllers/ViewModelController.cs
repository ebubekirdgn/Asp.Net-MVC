using _6_Models_ModelBinding.Models;
using _6_Models_ModelBinding.ViewModels;
using System.Web.Mvc;

namespace _6_Models_ModelBinding.Controllers
{
    public class ViewModelController : Controller
    {
        private object homepageViewModels;

        // Controllerdan view'e 2 model nesnesi gönderiliyor.
        [HttpGet]
        public ActionResult homepage()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "Furkan";
            kisi.Soyad = "Işıtan";
            kisi.Yas = 22;

            Adres adres = new Adres();
            adres.Sehir = "Samsun";
            adres.Ilce = "Çarşamba";

            homepageViewModel homepageVM = new homepageViewModel();
            homepageVM.KisiNesne = kisi;
            homepageVM.AdresNesne = adres;
            return View(homepageVM);
        }

        [HttpPost]
        public ActionResult homepage(homepageViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}