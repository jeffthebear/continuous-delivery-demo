using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;

namespace ContinuousDeliveryDemo.Domain.Web.Factories
{
    public interface IHomeModelFactory
    {
        HomeModel Create();
    }
}
