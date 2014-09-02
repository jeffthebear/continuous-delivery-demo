using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Test.Stubs;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Test.Web.Infrastructure
{
    [TestClass]
    public class UnityMvcDependencyResolverTest
    {
        [TestMethod]
        public void GetServiceShouldReturnRegisteredInstance()
        {
            var unityMvcDependencyResolver = new UnityMvcDependencyResolver(BuildUnityContainer());

            Assert.IsInstanceOfType(unityMvcDependencyResolver.GetService(typeof(IResolvable)), typeof(ConcreteResolvable));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterInstance(typeof(IResolvable), new ConcreteResolvable());
            return container;
        }
    }
}
