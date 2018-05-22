using _8_EntityFrameworkCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace _8_EntityFrameworkCodeFirst.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres
        public ActionResult Yeni()
        {
            DatabaseContext db = new DatabaseContext();

            List<SelectListItem> list = (from kisi in db.Kisiler.ToList()
                                         select new SelectListItem()
                                         {
                                             Text = kisi.Ad + " " + kisi.Soyad,
                                             Value = kisi.Id.ToString()
                                         }).ToList();
            ViewBag.Kisiler = list;
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Adresler adres)
        {
            DatabaseContext db = new DatabaseContext();

            // Kisiler tablosunda id si adreste tanımlanan id ye eşit olan ilk kayıtı döner.(yoksa null döner)
            Kisiler kisi = db.Kisiler.Where(x => x.Id == adres.Kisi.Id).FirstOrDefault();
            if (kisi != null)
            {
                try
                {
                    adres.Kisi = kisi;
                    db.Adresler.Add(adres);
                    int sonuc = db.SaveChanges();  // Etkilenen kayıt sayısını döner.

                    if (sonuc > 0)
                    {
                        ViewBag.Result = "Adres Eklendi";
                        ViewBag.Status = "success";
                    }
                    else
                    {
                        ViewBag.Result = "Adres Eklenemedi";
                        ViewBag.Status = "danger";
                    }
                }
                catch (Exception) { }
            }

            return Yeni();
        }

        public ActionResult Duzenle(int? id)
        {
            DatabaseContext db = new DatabaseContext();

            Adresler adres = null;
            if (id != null)
            {
                adres = db.Adresler.Where(x => x.Id == id).FirstOrDefault();
            }

            List<SelectListItem> list = (from kisi in db.Kisiler.ToList()
                                         select new SelectListItem()
                                         {
                                             Text = kisi.Ad + " " + kisi.Soyad,
                                             Value = kisi.Id.ToString()
                                         }).ToList();
            ViewBag.Kisiler = list;
            return View(adres);
        }

        [HttpPost]
        public ActionResult Duzenle(Adresler model, int? id)
        {
            DatabaseContext db = new DatabaseContext();

            Adresler adres = db.Adresler.Where(x => x.Id == id).FirstOrDefault();
            Kisiler kisi = db.Kisiler.Where(x => x.Id == model.Kisi.Id).FirstOrDefault();

            if (kisi != null)
            {
                try
                {
                    adres.Kisi = kisi;
                    adres.AdresTanim = model.AdresTanim;
                    int sonuc = db.SaveChanges();

                    if (sonuc > 0)
                    {
                        ViewBag.Result = "Adres Güncellendi";
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

            return Duzenle(id);
        }

        public ActionResult Sil(int? id)
        {
            Adresler adres = null;
            if (id != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(x => x.Id == id).FirstOrDefault();
            }
            return View(adres);
        }

        // ActionName("Sil") => Post işleminde bu metod 'Sil' adı ile de çağrılabilir.
        [HttpPost, ActionName("Sil")]
        public ActionResult SilPost(int? id)
        {
            Adresler adres = null;
            if (id != null)
            {
                DatabaseContext db = new DatabaseContext();
                adres = db.Adresler.Where(x => x.Id == id).FirstOrDefault();
                db.Adresler.Remove(adres);
                db.SaveChanges();
            }
            return RedirectToAction("homepage", "Home");  // Home controller'ın homepage aciton'ını çağırır.
        }
    }
}