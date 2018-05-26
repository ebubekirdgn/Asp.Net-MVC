using _13_Filters.Filters;
using System.Web.Mvc;

namespace _13_Filters.Controllers
{
    // Attribute'ları tek tek metodlara tanımlamak yerine ilgili class'a tanımlanabilir.
    // Böylece class'taki tüm metodlara attribute'lar uygulanmış olur.
    [ActFilter, ResFilter, AuthFilter, ExcFilter]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            // Hata oluşması için
            object n = 0;
            int r = 10 / (int)n;

            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }
    }
}