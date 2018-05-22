using System.Web.Mvc;

namespace _10_ActionResultTürleri.Controllers
{
    public class HomeController : Controller
    {
        // Tüm result türleri "ActionResult" dan türemiştir.
        // Tüm result türlerini döndürebilit. (Object gibi)
        public ActionResult Index()
        {
            return View();
        }

        // Farklı bir sayfaya yönlendirir
        public RedirectResult Index2()
        {
            return Redirect("/Home/Index");
        }
    }
}