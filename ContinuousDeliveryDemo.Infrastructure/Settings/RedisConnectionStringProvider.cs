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
            if (IsAlternateConfigAvailable())
            {
                using (AppConfig.Change(GetAlternateConfigPath()))
                {
                    return ConfigurationManager.ConnectionStrings["redisConnection"].ConnectionString;
                }
            }
            throw new FileNotFoundException("Could not find configuration file.");
        }

        private string GetAlternateConfigPath()
        {
            return Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "app.config");
        }

        private bool IsAlternateConfigAvailable()
        {
            return File.Exists(GetAlternateConfigPath());
        }
    }
}
