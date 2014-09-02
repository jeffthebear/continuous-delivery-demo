using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.Domain.Factories
{
    [TestClass]
    class HomeModelFactoryTest
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
