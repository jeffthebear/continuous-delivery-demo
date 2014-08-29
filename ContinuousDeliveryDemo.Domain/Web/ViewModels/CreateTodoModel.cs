using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Domain.Web.ViewModels
{
    public class CreateTodoModel
    {
        private ITodoRepository _todoRepository;
        public CreateTodoModel()
        {
            _todoRepository = new TodoRepository();
        }

        public CreateTodoModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public string Message { get; set; }

        public void Save()
        {
            _todoRepository.Create(Message);
        }
    }
}
