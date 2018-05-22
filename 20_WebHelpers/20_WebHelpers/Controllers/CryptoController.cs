using System.Web.Helpers;
using System.Web.Mvc;

namespace _20_WebHelpers.Controllers
{
    public class CryptoController : Controller
    {

        private string sifresiz = "Furkan Işıtan";
        private string sifreli = "";

        public ActionResult Index()
        {
            string salt = Crypto.GenerateSalt();    // Anahtar üretir.

            string hash = Crypto.Hash(sifresiz);  // default(SHA256)
            string sh1 = Crypto.SHA1(sifresiz);
            string sh256 = Crypto.SHA256(sifresiz);

            string sonuc = Crypto.HashPassword(sifresiz);  // Çok daha karmaşık şifreler
            bool dogru = Crypto.VerifyHashedPassword(sifreli, sifresiz);
            return View();
        }
    }
}