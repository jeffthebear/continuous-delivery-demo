using System;
using System.Linq;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.Domain.Web.ViewModels
{
    [TestClass]
    public class HomeModelTest
    {
        [TestMethod]
        public void CreateShouldReturnTwoTodos()
        {
            // Arrange
            var fakeTodoRepository = new FakeTodoRepository();
            var homeModelFactory = new HomeModelFactory(fakeTodoRepository);

            // Act
            var result = homeModelFactory.Create();

            // Assert
            Assert.AreEqual("1", result.Todos.First().Message);
            Assert.AreEqual(2, result.Todos.Count());
        }
    }
}
