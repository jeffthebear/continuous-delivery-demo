using ContinuousDeliveryDemo.Infrastructure.Settings;

namespace ContinuousDeliveryDemo.Unit.Test.Fakes
{
    public class FakeRedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        public string GetConnectionString()
        {
            return "localhost";
        }
    }
}
