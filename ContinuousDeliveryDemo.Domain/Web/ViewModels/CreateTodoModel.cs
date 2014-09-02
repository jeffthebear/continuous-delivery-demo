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
        private readonly ITodoRepository _todoRepository;

        public CreateTodoModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public string Message { get; set; }

        public virtual void Save()
        {
            _todoRepository.Create(Message);
        }
    }
}
