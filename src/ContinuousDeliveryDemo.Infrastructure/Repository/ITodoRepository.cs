using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousDeliveryDemo.Infrastructure.Repository
{
    public interface ITodoRepository
    {
        IEnumerable<string> FindAll();
        void Create(string message);
        void Delete(string message);
    }
}
