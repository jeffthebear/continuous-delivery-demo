using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Domain.Web.ViewModels
{
    public class HomeModel
    {
        private TodoRepository _todoRepository;
        private HomeModel()
        {
            _todoRepository = new TodoRepository();
        }

        public IEnumerable<TodoItem> Todos;

        public static HomeModel Create()
        {
            var result = new HomeModel();
            result.Todos = result._todoRepository.FindAll().Select(todo => new TodoItem { Message = todo});
            return result;
        }
    }
}
