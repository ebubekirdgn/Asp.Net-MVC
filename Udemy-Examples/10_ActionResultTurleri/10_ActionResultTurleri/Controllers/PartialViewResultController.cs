using System.Collections.Generic;
using System.Web.Mvc;

namespace _10_ActionResultTurleri.Controllers
{
    public class PartialViewResultController : Controller
    {
        // GET: PartialViewResult
        public ActionResult AnaSayfa()
        {
            return View();
        }

        public PartialViewResult GetirKategoriPartial()
        {
            return PartialView("_KategorilerPartial");
        }

        public PartialViewResult GetirKategoriPartial2()
        {
            List<string> kategoriler = new List<string>()
            {
                "Teknoloji",
                "Araçlar",
                "Temizlik",
                "Teknoloji",
                "Gıda",
                "Giyim"
            };

            return PartialView("_KategorilerPartial2", kategoriler);
        }
    }
}