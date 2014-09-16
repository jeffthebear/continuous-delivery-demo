using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContinuousDeliveryDemo.Component.Test.Infrastructure
{
    [TestClass]
    public class InMemoryRepositoryTest
    {
        private ITodoRepository _todoRepository;
        private IEnumerable<string> DEFAULT_TODOS = new[] { "todo one", "todo two" };

        [TestInitialize]
        public void SetUp()
        {
            _todoRepository = new InMemoryRepository();
            DEFAULT_TODOS.ToList().ForEach(todo =>
                _todoRepository.Create(todo)
                );
        }

        [TestMethod]
        public void FindAllShouldReturnTwoTodos()
        {
            // Act
            var result = _todoRepository.FindAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains(DEFAULT_TODOS.First()));
            Assert.IsTrue(result.Contains(DEFAULT_TODOS.Last()));
        }

        [TestMethod]
        public void CreateShouldAddNewTodo()
        {
            // Arrange
            var newValue = "todo three";

            // Act
            _todoRepository.Create("todo three");

            // Assert
            var resultSet = _todoRepository.FindAll();
            Assert.AreEqual(3, resultSet.Count());
            Assert.IsTrue(resultSet.ToList().Contains(newValue));
        }

        [TestMethod]
        public void DeleteShouldRemoveTodo()
        {
            // Act
            _todoRepository.Delete("todo two");

            // Assert
            var resultSet = _todoRepository.FindAll();
            Assert.AreEqual(1, resultSet.Count());
            Assert.IsFalse(resultSet.ToList().Contains("todo two"));
        }
    }
}
