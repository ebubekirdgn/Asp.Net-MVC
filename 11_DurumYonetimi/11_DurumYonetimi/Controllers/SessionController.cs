using System.Web.Mvc;

namespace _11_DurumYonetimi.Controllers
{
    public class SessionController : Controller
    {
        // Session, sunucu tarafında her bir kullanıcı için oluşturulan hafıza bölgesidir.

        // GET: Session
        public ActionResult Index()
        {
            return View();
        }

        // Session ile oluşturulan değişken(nesne), kullanıcı tarayıcıyı kapatmadığı veya
        //  belli bir süre(20dk) işlem yapılmadığı sürece yaşamaya devam eder.

        // İşlem yapmama süresi Web.config dosyasında, <system.web>...</system.web> içinde
        // <sessionState timeout="30"></sessionState>(30dk) ile belirtilebilir.
        [HttpPost]
        public ActionResult Index(string text)
        {
            // Session'a deger atama..
            Session["deger"] = text;
            //Session.Add("deger", text);

            return RedirectToAction("Index2");
        }

        public ActionResult Index2()
        {
            if (Session["deger"] != null)
                ViewBag.Deger = Session["deger"].ToString();
            else
                ViewBag.Deger = "Session verisi yoktur.";

            return View();
        }

        public ActionResult Index3()
        {
            // Session.Clear() // => Tüm session verisini temizler
            if (Session["deger"] != null)
                Session.Remove("deger");
            return RedirectToAction("Index2");
        }
    }
}