using System.Collections.Generic;
using System.Web.Mvc;

namespace _14_AjaxHelperMetodlari.Controllers
{
    public class ActionLinkController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> veriler = new List<string>() { "samsun", "ankara", "istanbul", "bursa", "trabzon", "izmir" };
            Session["listem"] = veriler;
            return View();
        }

        public PartialViewResult LoadData()
        {
            List<string> veriler = Session["listem"] as List<string>;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView", veriler);
        }

        public PartialViewResult RemoveData(int id)
        {
            List<string> veriler = Session["listem"] as List<string>;
            veriler.RemoveAt(id);
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView", veriler);
        }
    }
}