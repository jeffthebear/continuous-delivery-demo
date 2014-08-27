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
        private static ConnectionString _connectionString;
        private static ConnectionMultiplexer _redis;
        static RedisConnection()
        {
            //_redis = ConnectionMultiplexer.Connect("localhost");
            _connectionString = new ConnectionString();

            _redis =
                ConnectionMultiplexer.Connect(_connectionString.GetRedisConnectionString());
        }

        public static ConnectionMultiplexer GetInstance()
        {
            return _redis;
        }
    }
}
