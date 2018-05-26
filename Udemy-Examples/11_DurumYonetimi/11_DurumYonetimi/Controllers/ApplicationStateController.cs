using System.Web.Mvc;

namespace _11_DurumYonetimi.Controllers
{
    public class ApplicationStateController : Controller
    {
        // ApplicationState global hafızadır, her kullanıcı için tektir.(ayrı ayrı bölüm oluşmaz)

        // GET: ApplicationState
        public ActionResult Index()
        {
            HttpContext.Application["sayac"] = 1;
            // HttpContext.Application.Add("sayac", 1);

            return RedirectToAction("Index2");
        }

        public ActionResult Index2()
        {
            if (HttpContext.Application["sayac"] != null)
                ViewBag.Sayac = HttpContext.Application["sayac"].ToString();
            else
                ViewBag.Sayac = "Sayaç yok.";
            return View();
        }

        public ActionResult Index3()
        {
            if (HttpContext.Application["sayac"] != null)
            {
                int sayac = (int)HttpContext.Application["sayac"];
                sayac++;
                HttpContext.Application["sayac"] = sayac;
            }
            else
                return RedirectToAction("Index");
            return RedirectToAction("Index2");
        }

        public ActionResult Index4()
        {
            // HttpContext.Application.Clear();
            // HttpContext.Application.RemoveAll();

            if (HttpContext.Application["sayac"] != null)
                HttpContext.Application.Remove("sayac");

            return RedirectToAction("Index2");
        }
    }
}