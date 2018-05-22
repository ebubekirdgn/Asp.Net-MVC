using System.Web.Mvc;

namespace _5_VeriGonderme.Controllers
{
    public class ControllertoViewController : Controller
    {
        public ActionResult homePage()
        {
            // ViewData ve ViewBag ile oluşturulan veriler ilgili kontrolden başka bir kontrole gidildiğinde
            // silinir, erişilemez.

            ViewData["key1"] = "value1";
            ViewData["check1"] = true;

            ViewBag.key2 = "value2";
            ViewBag.check2 = true;
            ViewBag.list1 = new SelectListItem[] {
                new SelectListItem() { Text = "Furkan"},
                new SelectListItem() { Text = "Işıtan"}
            };

            // TempData ile oluşturulan verilerde ise başka bir kontrole gidilse bile verilere erişilebilir,
            // ancak ikinci bir kontrole gidildiğinde TempData da silinir.

            TempData["key3"] = "value3";
            TempData["check3"] = true;

            // ViewData ve ViewBag sadece kendi sayfasındaki verileri tutar,
            // TempData ise bir önceki sayfanın verilerini de tutabilir.

            return View();
        }
    }
}