using System;
using System.Linq;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Test.Fakes;
using ContinuousDeliveryDemo.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ContinuousDeliveryDemo.Test.Web.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexShouldReturnTwoTodos()
        {
            // Arrange
            var fakeTodoRepository = new FakeTodoRepository();
            HomeModel.TodoRepositoryOverride = fakeTodoRepository;

            // Act
            var result = HomeModel.Create();

            // Assert
            Assert.AreEqual("1", result.Todos.First().Message);
            Assert.AreEqual(2, result.Todos.Count());
        }

        [TestMethod]
        public void CreateShouldCreateTodoModelAndRedirectToRoot()
        {
            // Arrange
            const string message = "hello";
            var homeController = new HomeController();
            var fakeTodoRepository = new FakeTodoRepository();
            var createTodoModel = new CreateTodoModel(fakeTodoRepository);
            createTodoModel.Message = message;

            // Act
            var result = homeController.Create(createTodoModel);

            // Assert
            Assert.AreEqual(message, fakeTodoRepository.GetCreateInvokedMessage());
            Assert.AreEqual("/", ((RedirectResult) result).Url);
        }

        [TestMethod]
        public void DeleteShouldDeleteTodoModelAndRedirectToRoot()
        {
            // Arrange
            const string message = "goodbye";
            var homeController = new HomeController();
            var fakeTodoRepository = new FakeTodoRepository();
            var deleteTodoModel = new DeleteTodoModel(fakeTodoRepository);
            deleteTodoModel.Message = message;

            // Act
            var result = homeController.Delete(deleteTodoModel);

            // Assert
            Assert.AreEqual("/", ((RedirectResult)result).Url);
        }
    }
}
