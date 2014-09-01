using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Settings;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Infrastructure.Redis
{
    public static class RedisConnection
    {
        internal static ConnectionString ConnectionString { get; set; }
        private static readonly ConnectionMultiplexer _redis;
        static RedisConnection()
        {
            ConnectionString = new ConnectionString();

            _redis =
                ConnectionMultiplexer.Connect(ConnectionString.GetRedisConnectionString());
        }

        public static ConnectionMultiplexer GetInstance()
        {
            return _redis;
        }
    }
}
