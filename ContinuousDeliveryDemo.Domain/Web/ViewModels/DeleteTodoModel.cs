﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;

namespace ContinuousDeliveryDemo.Domain.Web.ViewModels
{
    public class DeleteTodoModel
    {
        private ITodoRepository _todoRepository;
        public DeleteTodoModel()
        {
            _todoRepository = new TodoRepository();
        }

        public DeleteTodoModel(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public string Message { get; set; }
        public void Delete()
        {
            _todoRepository.Delete(Message);
        }
    }
}
