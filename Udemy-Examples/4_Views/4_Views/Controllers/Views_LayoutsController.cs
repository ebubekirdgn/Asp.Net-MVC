using System.Web.Mvc;

namespace _4_Views.Controllers
{
    public class Views_LayoutsController : Controller
    {
        // Ana Sayfa
        public ActionResult homePage()
        {
            return View();
        }

        // Hakkında
        public ActionResult about()
        {
            return View();
        }

        // İletişim
        public ActionResult contact()
        {
            return View();
        }
    }
}