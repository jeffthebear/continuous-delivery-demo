using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Infrastructure.Repository
{
    public class TodoRepository
    {
        public IEnumerable<string> FindAll()
        {
            IDatabase db = RedisConnection.GetInstance().GetDatabase();
            return db.ListRange("todo").Select(t => (string) t);
        }

        public void Create(string message)
        {
            IDatabase db = RedisConnection.GetInstance().GetDatabase();
            db.ListRightPush("todo", message);
        }

        public void Delete(string message)
        {
            IDatabase db = RedisConnection.GetInstance().GetDatabase();
            db.ListRemove("todo", message);
        }
    }
}
