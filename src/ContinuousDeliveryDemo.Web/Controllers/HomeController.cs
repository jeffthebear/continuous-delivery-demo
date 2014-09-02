using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoRepository _todoRepository;

        public HomeController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ActionResult Index()
        {
            var homeModelFactory = new HomeModelFactory(_todoRepository);
            return View(homeModelFactory.Create());
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