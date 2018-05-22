using _13_Filters.Models;
using System;
using System.Web.Mvc;

namespace _13_Filters.Filters
{
    // ResultFilter, bir view'ın oluşmadan önceki ve sonraki anlarında çalışan iki metod sağlar.

    public class ResFilter : FilterAttribute, IResultFilter
    {
        DatabaseContext db = new DatabaseContext();

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            db.Logs.Add(new Log()
            {
                KullaniciAdi = (filterContext.HttpContext.Session["login"] as SiteUser).KullaniciAdi,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Tarih = DateTime.Now,
                Bilgi = "OnResultExecuted"
            });
            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            db.Logs.Add(new Log()
            {
                KullaniciAdi = (filterContext.HttpContext.Session["login"] as SiteUser).KullaniciAdi,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Tarih = DateTime.Now,
                Bilgi = "OnResultExecuting"
            });
            db.SaveChanges();
        }
    }
}