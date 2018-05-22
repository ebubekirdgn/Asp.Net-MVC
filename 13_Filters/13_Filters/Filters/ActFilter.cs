using _13_Filters.Models;
using System;
using System.Web.Mvc;

namespace _13_Filters.Filters
{
    // FilterAttribute => Class' ın attribute olmasını sağlar.
    // IActionFilter => İlgili metodu filtreler. Yani metodun çalışmadan önceki ve sonraki anlara hayat verir.
    public class ActFilter : FilterAttribute, IActionFilter
    {
        DatabaseContext db = new DatabaseContext();

        // Sonra
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            db.Logs.Add(new Log()
            {
                KullaniciAdi = (filterContext.HttpContext.Session["login"] as SiteUser).KullaniciAdi,
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Tarih = DateTime.Now,
                Bilgi = "OnActionExecuted"
            });
            db.SaveChanges();
        }

        // Çalışırken(Önce)
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.Logs.Add(new Log()
            {
                KullaniciAdi = (filterContext.HttpContext.Session["login"] as SiteUser).KullaniciAdi,
                ActionName = filterContext.ActionDescriptor.ActionName,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Tarih = DateTime.Now,
                Bilgi = "OnActionExecuting"
            });
            db.SaveChanges();
        }
    }
}