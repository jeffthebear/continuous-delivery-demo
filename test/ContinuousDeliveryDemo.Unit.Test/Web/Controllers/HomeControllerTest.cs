using System.Linq;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Unit.Test.Fakes;
using ContinuousDeliveryDemo.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

namespace ContinuousDeliveryDemo.Unit.Test.Web.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexShouldReturnTwoTodos()
        {
            // Arrange
            var todos = new[]
                {
                    new TodoItem() {Message = "first todo"},
                    new TodoItem() {Message = "second todo"},
                };
            var fakeTodoRepository = new FakeTodoRepository();
            var mockHomeModelFactory = new Mock<IHomeModelFactory>();
            mockHomeModelFactory
                .Setup(factory => factory.Create())
                .Returns(new HomeModel(fakeTodoRepository)
                    {
                        Todos = todos
                    });
            var homeController = new HomeController(mockHomeModelFactory.Object);

            // Act
            var result = (ViewResult)homeController.Index();

            // Assert
            var homeModel = (HomeModel)result.Model;
            Assert.AreEqual(todos.First().Message, homeModel.Todos.First().Message);
            Assert.AreEqual(todos[1].Message, homeModel.Todos.ToList()[1].Message);
        }

        [TestMethod]
        public void CreateShouldCreateTodoModelAndRedirectToRoot()
        {
            // Arrange
            const string message = "hello";
            var fakeTodoRepository = new FakeTodoRepository();
            var mockHomeModelFactory = new Mock<IHomeModelFactory>();
            var homeController = new HomeController(mockHomeModelFactory.Object);
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
            var fakeTodoRepository = new FakeTodoRepository();
            var mockHomeModelFactory = new Mock<IHomeModelFactory>();
            var homeController = new HomeController(mockHomeModelFactory.Object);
            var deleteTodoModel = new DeleteTodoModel(fakeTodoRepository);
            deleteTodoModel.Message = message;

            // Act
            var result = homeController.Delete(deleteTodoModel);

            // Assert
            Assert.AreEqual(message, fakeTodoRepository.GetDeleteInvokedMessage());
            Assert.AreEqual("/", ((RedirectResult)result).Url);
        }
    }
}
