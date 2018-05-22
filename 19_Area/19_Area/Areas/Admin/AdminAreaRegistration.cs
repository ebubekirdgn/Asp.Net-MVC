using System.Web.Mvc;

namespace _19_Area.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        // Area adı
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        // Admin areası altındaki actionlar çalışırken url in başına Admin gelme zorunluluğu tanımlaması
        // yapılır. (Zorunlu değildir, değiştirilebilir.)
        // Örn: domain/Admin/Home/Index
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}