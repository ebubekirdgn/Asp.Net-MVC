using _13_Filters.Models;
using System;
using System.Web.Mvc;

namespace _13_Filters.Filters
{
    public class ExcFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            DatabaseContext db = new DatabaseContext();
            string username = String.Empty;
            if (filterContext.HttpContext.Session["login"] != null)
                username = (filterContext.HttpContext.Session["login"] as SiteUser).KullaniciAdi;
            db.Logs.Add(new Log()
            {
                KullaniciAdi = username,
                ActionName = filterContext.RouteData.Values["action"].ToString(),
                ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                Tarih = DateTime.Now,
                Bilgi = "Error : " + filterContext.Exception.Message
            });
            db.SaveChanges();


            filterContext.ExceptionHandled = true;  // Oluşan hatayı bizim yöneteceğimizi belirtir.
            filterContext.Controller.TempData["error"] = filterContext.Exception;
            filterContext.Result = new RedirectResult("/Login/Error");
        }
    }
}