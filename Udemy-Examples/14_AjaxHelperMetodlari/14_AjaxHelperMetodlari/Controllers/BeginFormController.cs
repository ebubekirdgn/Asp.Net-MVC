using _14_AjaxHelperMetodlari.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _14_AjaxHelperMetodlari.Controllers
{
    public class BeginFormController : Controller
    {

        public ActionResult Index()
        {
            List<TodoItem> list = null;
            if (Session["todolist"] != null)
                list = Session["todolist"] as List<TodoItem>;
            else
                list = new List<TodoItem>();

            ViewBag.List = list;
            return View();
        }

        [HttpPost]
        public PartialViewResult Index(TodoItem model)
        {
            List<TodoItem> list = null;
            if (Session["todolist"] != null)
                list = Session["todolist"] as List<TodoItem>;
            else
                list = new List<TodoItem>();

            model.Id = Guid.NewGuid();
            list.Add(model);
            Session["todolist"] = list;
            System.Threading.Thread.Sleep(3000);
            return PartialView("_TodoItemPartialView",model);
        }
    }
}