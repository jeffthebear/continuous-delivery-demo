﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Web.Infrastructure
{
    public class UnityMvcDependencyResolver : IDependencyResolver
    {
        private const string HttpContextKey = "perRequestContainer";
        private readonly IUnityContainer _container;

        protected IUnityContainer ChildContainer
        {
            get
            {
                IUnityContainer unityContainer = HttpContext.Current.Items[(object)"perRequestContainer"] as IUnityContainer;
                if (unityContainer == null)
                    HttpContext.Current.Items[(object)"perRequestContainer"] = (object)(unityContainer = this._container.CreateChildContainer());
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

        public static void DisposeOfChildContainer()
        {
            IUnityContainer unityContainer = HttpContext.Current.Items[(object)"perRequestContainer"] as IUnityContainer;
            if (unityContainer == null)
                return;
            unityContainer.Dispose();
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
    }
}