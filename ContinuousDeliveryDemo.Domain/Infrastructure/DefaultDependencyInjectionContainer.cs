using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Domain.Infrastructure
{
    public class DefaultDependencyInjectionContainer
    {
        private static IUnityContainer _container;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public static T Resolve<T>()
        {
            EnsureContainerIsInitialized();
            return _container.Resolve<T>();
        }
        private static void EnsureContainerIsInitialized()
        {
            LazyInitializer.EnsureInitialized(ref _container, ref _isInitialized, ref _initializerLock,
                () =>
                {
                    var container = new UnityContainer();
                    container.RegisterType<ITodoRepository, TodoRepository>();
                    return container;
                });
        }
    }
}
