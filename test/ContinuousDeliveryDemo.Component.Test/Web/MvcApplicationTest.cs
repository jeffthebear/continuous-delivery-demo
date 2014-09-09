using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Component.Test.Fakes;
using ContinuousDeliveryDemo.Component.Test.Helpers;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Web;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Component.Test.Web
{
    [TestClass]
    public class MvcApplicationTest
    {
        [TestMethod]
        public void Application_StartShouldInitialize()
        {
            // Arrange
            RedisConnection.RedisConnectionStringProviderOverride = new FakeRedisConnectionStringProvider();
            dynamic mvcApplicationWrapper = new AccessPrivateWrapper(new MvcApplication());

            // Act
            mvcApplicationWrapper.Application_Start();

            // Assert
            Assert.IsInstanceOfType(DependencyResolver.Current, typeof(UnityMvcDependencyResolver));
            Assert.IsInstanceOfType(ModelBinders.Binders.DefaultBinder, typeof(UnityMvcModelBinder));
        }
    }
}
