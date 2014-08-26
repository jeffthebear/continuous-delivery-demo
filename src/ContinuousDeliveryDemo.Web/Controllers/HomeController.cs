using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;

namespace ContinuousDeliveryDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View(HomeModel.Create());
        }

        [HttpPost]
        public ActionResult Create(CreateTodoModel createTodoModel)
        {
            createTodoModel.Save();
            return Redirect("/");
        }

        public ActionResult Delete(DeleteTodoModel deleteTodoModel)
        {
            deleteTodoModel.Delete();
            return Redirect("/");
        }
	}
}