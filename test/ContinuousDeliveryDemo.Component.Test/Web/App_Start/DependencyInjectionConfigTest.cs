using System.Web.Mvc;
using ContinuousDeliveryDemo.Component.Test.Fakes;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Web.App_Start;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Component.Test.Web.App_Start
{
    [TestClass]
    public class DependencyInjectionConfigTest
    {
        [TestMethod]
        public void InitializeShouldSetDependencyResolverAndDefaultModelBinder()
        {
            // Arrange
            RedisConnection.RedisConnectionStringProviderOverride = new FakeRedisConnectionStringProvider();

            // Act
            DependencyInjectionConfig.Initialize();

            // Assert
            Assert.IsInstanceOfType(DependencyResolver.Current, typeof(UnityMvcDependencyResolver));
            Assert.IsInstanceOfType(ModelBinders.Binders.DefaultBinder, typeof(UnityMvcModelBinder));
        }
    }
}
