using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Settings;

namespace ContinuousDeliveryDemo.Test.WebTest.Fakes
{
    public class FakeRedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return "localhost";
        }
    }
}
