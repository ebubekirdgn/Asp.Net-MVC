using System.Web.Mvc;

namespace _10_ActionResultTurleri.Controllers
{
    public class JavaScriptResultController : Controller
    {
        // GET: JavaScriptResult
        public ActionResult Index()
        {
            return View();
        }

        public JavaScriptResult BaslangicMesaji()
        {
            string js = "alert('Merhaba Dünya');";
            return JavaScript(js);
        }

        public JavaScriptResult jsButtonClick()
        {
            string js = "function button_click() { alert('Merhaba JsResult'); }";

            return JavaScript(js);
        }

    }
}