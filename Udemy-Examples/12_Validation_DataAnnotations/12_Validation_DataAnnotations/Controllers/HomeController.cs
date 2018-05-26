using AspNetMvcValidations.Models;
using System.Web.Mvc;

namespace _12_Validation_DataAnnotations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new Kullanici());
        }

        [HttpPost]
        public ActionResult Index(Kullanici model)
        {
            // ModelState.IsValid => Modelde hata olup olmadığını tutar.
            // Güvenlik için, modelle ilgili işlemler yapılırken önce bu değerin 'true' olması kontrol edilmeidir.

            if (model.KullaniciAdi == "furkan")
            {
                // Veritabanından 'kullanıcı adı kullanılıyor mu' kontrolü yapıldığı varsayılsın.
                // İlk parametre ilgili propertynin adı. Boş geçilirse ValidationSummary çalışır.
                // İlk parametre hiç bir yerde tanımlanmamış bir property ismi ise modelState de 
                // bu hata mesajı durur ama ekranda görünmez.
                ModelState.AddModelError("", "Bu kullanıcı adı kullanılıyor.");  // Hata ekleme
            }
            
            return View(model);
        }
    }
}