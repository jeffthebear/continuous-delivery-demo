using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using ContinuousDeliveryDemo.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContinuousDeliveryDemo.Test.Web.App_Start
{
    [TestClass]
    public class RouteConfigTest
    {
        [TestMethod]
        public void RegisterRoutesShouldAddToRouteCollection()
        {
            // Arrange
            var routeCollection = new RouteCollection();
            
            // Act
            RouteConfig.RegisterRoutes(routeCollection);

            // Assert
            Assert.IsTrue(routeCollection.Count() > 0);
        }
    }
}
