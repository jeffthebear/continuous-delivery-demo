using ContinuousDeliveryDemo.Infrastructure.Settings;

namespace ContinuousDeliveryDemo.UI.Test.Fakes
{
    public class FakeRedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return "localhost";
        }
    }
}
