using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace _9_AutoGeneretedController_Views.Controllers
{
    public class AdreslerController : Controller
    {
        private TestEFDBEntities db = new TestEFDBEntities();

        // GET: Adresler
        public ActionResult Index()
        {
            var adresler = db.Adresler.Include(a => a.Kisiler);
            return View(adresler.ToList());
        }

        // GET: Adresler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            return View(adresler);
        }

        // GET: Adresler/Create
        public ActionResult Create()
        {
            ViewBag.Kisi_Id = new SelectList(db.Kisiler, "Id", "Ad");
            return View();
        }

        // POST: Adresler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AdresTanim,Kisi_Id")] Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                db.Adresler.Add(adresler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kisi_Id = new SelectList(db.Kisiler, "Id", "Ad", adresler.Kisi_Id);
            return View(adresler);
        }

        // GET: Adresler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kisi_Id = new SelectList(db.Kisiler, "Id", "Ad", adresler.Kisi_Id);
            return View(adresler);
        }

        // POST: Adresler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AdresTanim,Kisi_Id")] Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kisi_Id = new SelectList(db.Kisiler, "Id", "Ad", adresler.Kisi_Id);
            return View(adresler);
        }

        // GET: Adresler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresler adresler = db.Adresler.Find(id);
            if (adresler == null)
            {
                return HttpNotFound();
            }
            return View(adresler);
        }

        // POST: Adresler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresler adresler = db.Adresler.Find(id);
            db.Adresler.Remove(adresler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
