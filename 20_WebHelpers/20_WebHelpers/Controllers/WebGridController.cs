using _20_WebHelpers.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _20_WebHelpers.Controllers
{
    public class WebGridController : Controller
    {
        // GET: WebGrid
        public ActionResult Index()
        {
            Kitap.GenerateFakeData(50);
            return View(Kitap.Kitaplar);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            List<Kitap> filtrelenmis = Kitap.Kitaplar.Where(x =>
            x.Adi.ToLower().Contains(search) ||
            x.Yazar.ToLower().Contains(search) ||
            x.YayinTarihi.ToString().ToLower().Contains(search) ||
            x.Fiyat.ToString().ToLower().Contains(search))
            .ToList();

            return View(filtrelenmis);
        }
    }
}