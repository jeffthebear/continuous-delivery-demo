using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using ContinuousDeliveryDemo.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.Domain.Web.ViewModels
{
    [TestClass]
    public class CreateTodoModelTest
    {
        [TestMethod]
        public void SaveShouldInvokeWithCorrectMessage()
        {
            // Arrange
            const string message = "hello";
            var fakeTodoRepository = new FakeTodoRepository();
            var createTodoModel = new CreateTodoModel(fakeTodoRepository);
            createTodoModel.Message = message;
            
            // Act
            createTodoModel.Save();

            // Assert
            Assert.AreEqual(message, fakeTodoRepository.GetCreateInvokedMessage());
        }
    }
}
