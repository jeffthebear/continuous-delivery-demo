using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContinuousDeliveryDemo.Domain.Web.Factories;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using ContinuousDeliveryDemo.Web.Infrastructure;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityMvcDependencyResolver(container));
            ModelBinders.Binders.DefaultBinder = new UnityMvcModelBinder(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterInstance(typeof(ITodoRepository), new TodoRepository("todo", RedisConnection.GetInstance().GetDatabase()));
            container.RegisterType<IHomeModelFactory, HomeModelFactory>();
            return container;
        }
    }
}