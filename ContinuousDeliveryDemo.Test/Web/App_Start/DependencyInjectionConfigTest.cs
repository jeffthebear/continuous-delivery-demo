using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Web.App_Start;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ContinuousDeliveryDemo.Test.Web.App_Start
{
    [TestClass]
    public class DependencyInjectionConfigTest
    {
        [TestMethod]
        public void InitializeShouldSetDependencyResolverAndModelBinders()
        {
            DependencyInjectionConfig.Initialize();

            Assert.IsInstanceOfType(DependencyResolver.Current, typeof(UnityMvcDependencyResolver));
            Assert.IsInstanceOfType(ModelBinders.Binders.DefaultBinder, typeof(UnityMvcModelBinder));
        }
    }
}
