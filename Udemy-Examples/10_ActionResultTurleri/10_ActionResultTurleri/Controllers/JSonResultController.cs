using _10_ActionResultTürleri.Models;
using System.Web.Mvc;

namespace _10_ActionResultTürleri.Controllers
{
    public class JSonResultController : Controller
    {
        // JsonResult:
        // Sayfaya veri göndermek için kullanılır. (XML den daha az yer kaplar.)
        // Genelde asenkron(sayfa yenilenmeden) olarak javascript işlemlerinde kullanılır
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult Index_JSon()
        {
            Urun urun = new Urun() { Id = 5, Ad = "Domates", Fiyat = 20000, Aciklama = "Test Ürünü" };

            // Json() => Nesneyi JSon türüne çevirir.
            // JsonRequestBehavior.AllowGet => Get işlemine izin verildiğini belirten parametre

            return Json(urun, JsonRequestBehavior.AllowGet);
        }
        // Dönecek olan JSon nesnesi: { Id : 5, Ad : "Domates", Fiyat : 20000, Aciklama : "Test Ürünü" }

        /*
         Get metodunda JsonRequestBehavior.AllowGet parametresi verilmese bile (get işlemine izin verilmemesini sağlar)
         Index3 de ajax metodunun tipi POST yapılarak da verilere erişilebilir.
         Bunu engellemek için aynı metodun post metodu da yazılmalıdır.
        */
        [HttpPost]
        public JsonResult Index_JSon(int? id)
        {
            return Json(null);
        }
        
    }
}