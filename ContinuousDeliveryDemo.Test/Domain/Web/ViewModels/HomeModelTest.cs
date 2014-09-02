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
        public void GetCreateTodoModelWithContextShouldReturnCreateTodoModel()
        {
            var fakeTodoRepository = new FakeTodoRepository();
            var homeModel = new HomeModel(fakeTodoRepository);

            var result = homeModel.GetCreateTodoModelWithContext();

            Assert.IsInstanceOfType(result, typeof (CreateTodoModel));
        }

        [TestMethod]
        public void GetDeleteTodoModelWithContextShouldReturnDeleteTodoModel()
        {
            var message = "hello world";
            var fakeTodoRepository = new FakeTodoRepository();
            var homeModel = new HomeModel(fakeTodoRepository);

            var result = homeModel.GetDeleteTodoModelWithContext(message);

            Assert.IsInstanceOfType(result, typeof(DeleteTodoModel));
            Assert.AreEqual(message, result.Message);
        }
    }
}
