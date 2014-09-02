using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Web.Infrastructure
{
    public class UnityMvcDependencyResolver : IDependencyResolver
    {
        private const string REQUEST_STORE_KEY = "perRequestContainer";
        private readonly IUnityContainer _container;

        protected IUnityContainer ChildContainer
        {
            get
            {
                IUnityContainer unityContainer = RequestStore()[(object)REQUEST_STORE_KEY] as IUnityContainer;
                if (unityContainer == null)
                    RequestStore()[(object)REQUEST_STORE_KEY] = (object)(unityContainer = this._container.CreateChildContainer());
                return unityContainer;
            }
        }

        public UnityMvcDependencyResolver(IUnityContainer container)
        {
            this._container = container;
        }

        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
                return UnityContainerExtensions.Resolve(this.ChildContainer, serviceType, new ResolverOverride[0]);
            if (!this.IsRegistered(serviceType))
                return (object)null;
            else
                return UnityContainerExtensions.Resolve(this.ChildContainer, serviceType, new ResolverOverride[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.IsRegistered(serviceType))
                yield return UnityContainerExtensions.Resolve(this.ChildContainer, serviceType, new ResolverOverride[0]);
            foreach (object obj in this.ChildContainer.ResolveAll(serviceType, new ResolverOverride[0]))
                yield return obj;
        }

        private bool IsRegistered(Type typeToCheck)
        {
            bool flag = true;
            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                flag = UnityContainerExtensions.IsRegistered(this.ChildContainer, typeToCheck);
                if (!flag && typeToCheck.IsGenericType)
                    flag = UnityContainerExtensions.IsRegistered(this.ChildContainer, typeToCheck.GetGenericTypeDefinition());
            }
            return flag;
        }

        private static Dictionary<object, object> _backupStore = new Dictionary<object, object>();
        private static IDictionary RequestStore()
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Items;
            }
            return _backupStore;
        }
    }
}