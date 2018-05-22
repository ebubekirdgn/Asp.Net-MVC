using _7_Bootstrap.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _7_Bootstrap.Controllers
{
    public class CustomHtlmHelperMethodsController : Controller
    {
        // GET: CustomHtlmHelperMethods
        public ActionResult homepage()
        {
            return View();
        }

        public ActionResult homepage2()
        {
            List<_Message> messages = new List<_Message>();
            messages.Add(new _Message() { Level = 1, Text = "Adipiscing elit fusce." });
            messages.Add(new _Message() { Level = 2, Text = "Sit amet, consectetur." });
            messages.Add(new _Message() { Level = 3, Text = "Vel sapien elit." });
            messages.Add(new _Message() { Level = 4, Text = "In malesuada semper." });

            return View(messages);
        }
    }
}