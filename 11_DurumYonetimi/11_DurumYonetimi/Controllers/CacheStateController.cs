using System;
using System.Web.Mvc;

namespace _11_DurumYonetimi.Controllers
{
    public class CacheStateController : Controller
    {
        /* ApplicationState' e benzer. Globaldir, tüm kullanıcılar için aynıdır.
           Fakat ApplicationState uygulamanın ömrü boyunca yaşarken, CacheState' in belirli bir ömrü vardır.
           Geliştirici tarafından belirtilen tarihte, bir işlemden belli bir süre sonra veya 
          işletim sistemi tarafından (düşük öncelikli cache'lerden başlanarak) öldürülebilir.*/



        // GET: CacheState
        public ActionResult Index()
        {
            /* Bu şekilde oluşturulduğunda, eğer default süre varsa o süre sonunda silinir,
              aksi halde daima yaşar(işletim sistemi gerek duyarsa silebilir.)
              Genelde bu şekilde kullanılmaz.*/
            // HttpContext.Cache["isim1"] = "furkan ışıtan";


            /* 
             * 1 => name
             * 2 => value
             * 3 => bağımlılıklar (cache oluşturulması bir dosyaya vs. ye bağlı old. durumlar)
             * 4 => ölüm tarihi
             * 5 => ölümün ötelenme süresi (son erişimden itibaren öteler)
             ölüm tarihi ve ötelenme süresinin ikisi birden verilemez(NoAbsoluteExpiration/NoSlidingExpiration)
             * 6 => cache' in önceliği
             * 7 => cache öldüğünde çalıştırılacak fonksiyon
             */
            HttpContext.Cache.Add("isim", "furkan ışıtan", null, System.Web.Caching.Cache.NoAbsoluteExpiration,
                new TimeSpan(0, 0, 10), System.Web.Caching.CacheItemPriority.Normal, CacheItemExpired);



            return View();
        }

        // Bu metodun dönüş tipi ve parametre tipleri System.Web.Caching.CacheItemRemovedCallback
        // delegate'i gibi olmalıdır.
        private void CacheItemExpired(string key, object value, System.Web.Caching.CacheItemRemovedReason reason)
        {
            System.IO.File.WriteAllText(Server.MapPath("~/cache-exprired-note.txt"),
                $"'{key}' cache item '{value.ToString()}' value are expired. Reason: '{reason.ToString()}'");
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            HttpContext.Cache.Remove("isim"); // Silme işlemi
            return View();
        }
    }
}