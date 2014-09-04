using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousDeliveryDemo.Infrastructure.Settings
{
    public interface IRedisConnectionStringProvider
    {
        string GetConnectionString();
    }
}
