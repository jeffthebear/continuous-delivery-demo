using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ContinuousDeliveryDemo.Infrastructure.Settings
{
    internal class RedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var alternateConfig = new AlternateConfig();
            if (alternateConfig.IsAlternateConfigAvailable())
            {
                using (AppConfig.Change(alternateConfig.GetAlternateConfigPath()))
                {
                    return ConfigurationManager.ConnectionStrings["redisConnection"].ConnectionString;
                }
            }
            throw new FileNotFoundException("Could not find configuration file.");
        }
    }
}
