using _8_EntityFrameworkCodeFirst.Models.Managers;
using _8_EntityFrameworkCodeFirst.ViewModels.Home;
using System.Linq;
using System.Web.Mvc;

namespace _8_EntityFrameworkCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            DatabaseContext db = new DatabaseContext();

            HomePageViewModel viewModel = new HomePageViewModel();
            viewModel.Kisiler = db.Kisiler.ToList();
            viewModel.Adresler = db.Adresler.ToList();

            return View(viewModel);
        }
    }
}