using ContinuousDeliveryDemo.Infrastructure.Settings;

namespace ContinuousDeliveryDemo.Component.Test.Fakes
{
    public class FakeRedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return "localhost";
        }
    }
}
