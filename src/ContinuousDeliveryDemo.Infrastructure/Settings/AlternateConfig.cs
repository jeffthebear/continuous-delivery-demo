using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ContinuousDeliveryDemo.Infrastructure.Settings
{
    public class AlternateConfig
    {
        public string GetAlternateConfigPath()
        {
            return Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", "app.config");
        }

        public bool IsAlternateConfigAvailable()
        {
            return File.Exists(GetAlternateConfigPath());
        }
    }
}
