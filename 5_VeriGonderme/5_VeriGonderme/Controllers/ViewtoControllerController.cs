using System.Web.Mvc;

namespace _5_VeriGonderme.Controllers
{
    public class ViewtoControllerController : Controller
    {
        [HttpGet]
        public ActionResult homePage()
        {
            return View();
        }

        // Parametre isimleri nesne name'leri ile aynı olmalıdır.
        [HttpPost]
        public ActionResult homePage(string text1, bool check1, string list1)
        {
            var t1 = Request.Form["text1"];
            var l1 = Request.Form["list1"];
            var c1 = Request.Form["check1"];  // Seçili ise "true,false", değilse "false,true" döner.
            var c2 = Request.Form.GetValues("check1")[0]; // Baştaki value yi döner.

            return View();
        }
    }
}