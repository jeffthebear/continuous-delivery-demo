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
        private ITodoRepository _todoRepository;
        private HomeModel()
        {
            _todoRepository = new TodoRepository();
        }

        internal HomeModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public IEnumerable<TodoItem> Todos { get; set; }

        public static HomeModel Create()
        {
            var result = new HomeModel();
            result.Todos = result._todoRepository.FindAll().Select(todo => new TodoItem { Message = todo});
            return result;
        }
    }
}
