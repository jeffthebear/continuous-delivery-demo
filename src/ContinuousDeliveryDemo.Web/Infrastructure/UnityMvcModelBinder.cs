using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace ContinuousDeliveryDemo.Web.Infrastructure
{
    public class UnityMvcModelBinder : DefaultModelBinder
    {
        private readonly IUnityContainer _container;

        public UnityMvcModelBinder(IUnityContainer container)
        {
            this._container = container;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType == null)
            {
                return base.CreateModel(controllerContext, bindingContext, null);
            }

            return this._container.Resolve(modelType);
        }
    }
}