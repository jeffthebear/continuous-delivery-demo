using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Test.Fakes
{
    public class FakeTodoRepository : ITodoRepository
    {
        private string _createInvokedMessage;
        private string _deleteInvokedMessage;

        public IEnumerable<string> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Create(string message)
        {
            _createInvokedMessage = message;
        }

        public string GetCreateInvokedMessage()
        {
            return _createInvokedMessage;
        }

        public void Delete(string message)
        {
            _deleteInvokedMessage = message;
        }

        public string GetDeleteInvokedMessage()
        {
            return _deleteInvokedMessage;
        }
    }
}
