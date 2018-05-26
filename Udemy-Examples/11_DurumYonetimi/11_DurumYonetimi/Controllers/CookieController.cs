using System;
using System.Web;
using System.Web.Mvc;

namespace _11_DurumYonetimi.Controllers
{
    public class CookieController : Controller
    {
        /* Bilgiler siteye giren biligisayarın harddiskinde belli bir yerde tutulur.
           Bu yer açık bir şekilde bilindiği için şifre vs. gibi değerler burada tutulmamalıdır.
           Faakt tarayıcı vs. kapansa bile aksi belirtilmedikçe değerler istemci tarafında yaşar.
           Değerleri string olarak tutar.*/

        // GET: Cookie
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("username", "furkanışıtan");
            cookie.Expires = DateTime.Now.AddDays(1); // cookie ye 1 günlük ömür verildi.(1 gün sonra otomatik silinir)
            HttpContext.Response.Cookies.Add(cookie); // Karşı makinaya(istemci) cookieyi ekleme yanıtı gönderir.
            return View();
        }

        public ActionResult Index2()
        {
            // İstemciye cookie'yi ver isteği gönderiliyor
            if (HttpContext.Request.Cookies["username"] != null)
                ViewBag.UserName = HttpContext.Request.Cookies["username"].Value;
            else
                ViewBag.UserName = "Cookie tanımlanmamıştır.";
            return View();
        }

        public ActionResult Index3()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                if (HttpContext.Request.Cookies["username"] != null)
                {
                    //HttpContext.Request.Cookies.Remove("username");  // cookie' yi silme isteği
                    // Genelde yukarıdaki istek ile cookie silinemeyebilir.
                    // Aşağıdaki kullanım daha doğru sonuç verecektir.
                    HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(2);  // 2 saniye sonra 
                }
            }
            return View();
        }
    }
}