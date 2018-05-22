using System.Web.Mvc;

namespace _13_Filters.Filters
{
    // Action çalışmadan önce OnAuthorization metodu çalışarak yetki kontrolü yapar.
    public class AuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["login"] == null)
            {
                // View çalışmadan başka bir View'e yönlendirme
                filterContext.Result = new RedirectResult("/Login/SignIn");  
            }
        }
    }
}