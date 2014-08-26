using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Infrastructure.Redis
{
    public static class RedisConnection
    {
        private static ConnectionMultiplexer _redis;
        static RedisConnection()
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
        }

        public static ConnectionMultiplexer GetInstance()
        {
            return _redis;
        }
    }
}
