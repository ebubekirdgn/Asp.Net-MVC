using _8_EntityFrameworkCodeFirst.Models.Managers;
using System;
using System.Linq;
using System.Web.Mvc;

namespace _8_EntityFrameworkCodeFirst.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Kisiler kisi)
        {
            DatabaseContext db = new DatabaseContext();
            db.Kisiler.Add(kisi);

            try
            {
                int sonuc = db.SaveChanges();  // Etkilenen kayıt sayısını döner.

                if (sonuc > 0)
                {
                    ViewBag.Result = "Kişi Eklendi";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Kişi Eklenemedi";
                    ViewBag.Status = "danger";
                }
            }
            catch (Exception) { }

            return View();
        }


        public ActionResult Duzenle(int? id)
        {
            Kisiler kisi = null;
            if (id != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(kisi);
        }

        [HttpPost]
        public ActionResult Duzenle(Kisiler model, int? id)
        {
            DatabaseContext db = new DatabaseContext();
            Kisiler kisi = db.Kisiler.Where(x => x.Id == id).FirstOrDefault();
            if (kisi != null)
            {
                kisi.Ad = model.Ad;
                kisi.Soyad = model.Soyad;
                kisi.Yas = model.Yas;

                try
                {
                    int sonuc = db.SaveChanges();

                    if (sonuc > 0)
                    {
                        ViewBag.Result = "Kişi Güncellendi";
                        ViewBag.Status = "success";
                    }
                    else
                    {
                        ViewBag.Result = "Güncelleme Başarısız";
                        ViewBag.Status = "danger";
                    }
                }
                catch (Exception) { }
            }
            return View();
        }

        public ActionResult Sil(int? id)
        {
            Kisiler kisi = null;
            if (id != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.Id == id).FirstOrDefault();
            }

            return View(kisi);
        }

        // ActionName("Sil") => Post işleminde bu metod 'Sil' adı ile de çağrılabilir.
        [HttpPost, ActionName("Sil")]
        public ActionResult SilPost(int? id)
        {
            Kisiler kisi = null;
            if (id != null)
            {
                DatabaseContext db = new DatabaseContext();
                kisi = db.Kisiler.Where(x => x.Id == id).FirstOrDefault();
                db.Kisiler.Remove(kisi);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    ViewBag.Result = "Kişi üzerine kayıtlı adres(ler) mevcut. Önce onları siliniz...";
                    ViewBag.Status = "danger";
                    return View();
                }
                
            }
            return RedirectToAction("homepage", "Home");  // Home controller'ın homepage aciton'ını çağırır.
        }
    }
}