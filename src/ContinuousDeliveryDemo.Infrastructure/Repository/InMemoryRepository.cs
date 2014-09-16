using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousDeliveryDemo.Infrastructure.Repository
{
    public class InMemoryRepository : ITodoRepository
    {
        private readonly HashSet<string> _datastore = new HashSet<string>();

        public IEnumerable<string> FindAll()
        {
            return _datastore.ToArray();
        }

        public void Create(string message)
        {
            lock (_datastore)
            {
                _datastore.Add(message);
            }
        }

        public void Delete(string message)
        {
            lock (_datastore)
            {
                _datastore.Remove(message);
            }   
        }
    }
}
