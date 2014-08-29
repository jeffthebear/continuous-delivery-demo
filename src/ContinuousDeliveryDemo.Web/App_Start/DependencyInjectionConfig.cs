using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void SetResolver()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityMvcDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //container.RegisterInstance(typeof (ModelMetadataProvider), new CustomModelMetadataProvider());
            return container;
        }
    }
}