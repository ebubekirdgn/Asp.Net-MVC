using System.Web.Mvc;

namespace _7_Bootstrap.Controllers
{
    public class HelperMethodsController : Controller
    {
        // GET: HelperMethods
        public ActionResult homepage()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }
    }
}