using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;

namespace ContinuousDeliveryDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeModelFactory _homeModelFactory;

        public HomeController(IHomeModelFactory homeModelFactory)
        {
            _homeModelFactory = homeModelFactory;
        }

        public ActionResult Index()
        {
            return View(_homeModelFactory.Create());
        }

        [HttpPost]
        public ActionResult Create(CreateTodoModel createTodoModel)
        {
            createTodoModel.Save();
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult Delete(DeleteTodoModel deleteTodoModel)
        {
            deleteTodoModel.Delete();
            return Redirect("/");
        }
	}
}