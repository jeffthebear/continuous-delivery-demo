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
        private CreateTodoModel _createTodoModel;
        private DeleteTodoModel _deleteTodoModel;
        
        internal HomeModel(ITodoRepository todoRepository)
        {
            _createTodoModel = new CreateTodoModel(todoRepository);
            _deleteTodoModel = new DeleteTodoModel(todoRepository);
        }

        public CreateTodoModel GetCreateTodoModelWithContext()
        {
            return _createTodoModel;
        }

        public DeleteTodoModel GetDeleteTodoModelWithContext(string message)
        {
            _deleteTodoModel.Message = message;
            return _deleteTodoModel;
        }

        public IEnumerable<TodoItem> Todos { get; internal set; }
    }
}
