using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Test.ComponentTest.Fakes;
using ContinuousDeliveryDemo.Web.App_Start;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.ComponentTest.Web.App_Start
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
