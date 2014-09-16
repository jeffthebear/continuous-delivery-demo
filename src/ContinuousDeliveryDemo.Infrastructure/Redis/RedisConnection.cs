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
        // This is for testing
        internal static IRedisConnectionStringProvider RedisConnectionStringProviderOverride { get; set; }

        private static readonly object _initializationLock = new object();
        private static ConnectionMultiplexer _redisConnectionMultiplexer;

        public static ConnectionMultiplexer GetInstance()
        {
            if (_redisConnectionMultiplexer != null)
                return _redisConnectionMultiplexer;

            lock (_initializationLock)
            {
                var redisConnectionStringProvider = RedisConnectionStringProviderOverride ?? 
                    new RedisConnectionStringProvider();

                if (_redisConnectionMultiplexer == null)
                    _redisConnectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionStringProvider.GetConnectionString());

                return _redisConnectionMultiplexer;
            }
        }
    }
}
