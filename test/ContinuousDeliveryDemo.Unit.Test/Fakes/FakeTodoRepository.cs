using System.Collections.Generic;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Unit.Test.Fakes
{
    public class FakeTodoRepository : ITodoRepository
    {
        private string _createInvokedMessage;
        private string _deleteInvokedMessage;

        public IEnumerable<string> FindAll()
        {
            return new [] { "1", "2" };
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
