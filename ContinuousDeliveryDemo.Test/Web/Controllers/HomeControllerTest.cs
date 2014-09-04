using System;
using System.Linq;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using ContinuousDeliveryDemo.Test.Fakes;
using ContinuousDeliveryDemo.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Moq;

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
            var homeController = new HomeController(fakeTodoRepository);

            // Act
            var result = (ViewResult) homeController.Index();

            // Assert
            var homeModel = (HomeModel) result.Model;
            Assert.AreEqual(fakeTodoRepository.FindAll().First(), homeModel.Todos.First().Message);
        }

        [TestMethod]
        public void CreateShouldCreateTodoModelAndRedirectToRoot()
        {
            // Arrange
            const string message = "hello";
            var fakeTodoRepository = new FakeTodoRepository();
            var homeController = new HomeController(fakeTodoRepository);
            var createTodoModel = new CreateTodoModel(fakeTodoRepository);
            createTodoModel.Message = message;

            // Act
            var result = homeController.Create(createTodoModel);

            // Assert
            Assert.AreEqual(message, fakeTodoRepository.GetCreateInvokedMessage());
            Assert.AreEqual("/", ((RedirectResult) result).Url);
        }

        [TestMethod]
        public void CreateShouldCreateTodoModelAndRedirectToRootUsingMocks()
        {
            // Arrange
            var mockRepository = new Mock<ITodoRepository>();
            var homeController = new HomeController(mockRepository.Object);
            var mock = new Mock<CreateTodoModel>(mockRepository.Object);
            
            // Act
            var result = homeController.Create(mock.Object);

            // Assert
            mock.Verify(model => model.Save(), Times.Exactly(1));
            Assert.AreEqual("/", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void DeleteShouldDeleteTodoModelAndRedirectToRoot()
        {
            // Arrange
            const string message = "goodbye";
            var fakeTodoRepository = new FakeTodoRepository();
            var homeController = new HomeController(fakeTodoRepository);
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
