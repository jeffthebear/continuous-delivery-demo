using ContinuousDeliveryDemo.Domain.Infrastructure;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.Domain.Infrastructure
{
    [TestClass]
    public class DefaultDependencyInjectionContainerTest
    {
        [TestMethod]
        public void ResolveForITodoRepositoryShouldReturnConcreteTodoRepository()
        {
            // Act
            var result = DefaultDependencyInjectionContainer.Resolve<ITodoRepository>();

            // Assert
            Assert.IsInstanceOfType(result, typeof(TodoRepository));
        }
    }
}
