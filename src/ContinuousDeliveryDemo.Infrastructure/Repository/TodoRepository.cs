using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly string _todoKey;
        private readonly IDatabase _database;
        public TodoRepository(string key, IDatabase database)
        {
            _todoKey = key;
            _database = database;
        }

        public IEnumerable<string> FindAll()
        {
            return _database.SetMembers(_todoKey).Select(t => (string)t);
        }

        public void Create(string message)
        {
            _database.SetAdd(_todoKey, message);
        }

        public void Delete(string message)
        {
            _database.SetRemove(_todoKey, message);
        }
    }
}
