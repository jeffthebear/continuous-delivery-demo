using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Domain.Web.ViewModels;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Domain.Web.Factories
{
    public class HomeModelFactory
    {
        private readonly ITodoRepository _todoRepository;

        public HomeModelFactory(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public HomeModel Create()
        {
            var result = new HomeModel(_todoRepository);
            result.Todos = _todoRepository.FindAll().Select(todo => new TodoItem { Message = todo });
            return result;
        }
    }
}
