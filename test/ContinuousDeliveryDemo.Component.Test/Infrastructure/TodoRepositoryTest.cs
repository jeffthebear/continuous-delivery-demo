using System.Linq;
using System.Collections.Generic;
using ContinuousDeliveryDemo.Component.Test.Fakes;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Component.Test.Infrastructure
{
    /// <summary>
    /// Summary description for TodoRepositoryTest
    /// </summary>
    [TestClass]
    public class TodoRepositoryTest
    {
        private ITodoRepository _todoRepository;
        private IDatabase database;
        private const string TEST_KEY = "todo_component_test";
        private IEnumerable<string> DEFAULT_TODOS = new[] {"todo one", "todo two"};

        [TestInitialize]
        public void SetUp()
        {
            RedisConnection.RedisConnectionStringProviderOverride = new FakeRedisConnectionStringProvider();
            _todoRepository = new TodoRepository(TEST_KEY);
            database = RedisConnection.GetInstance().GetDatabase();
            database.KeyDelete(TEST_KEY, CommandFlags.FireAndForget);
            DEFAULT_TODOS.ToList().ForEach(todo => 
                database.ListRightPush(TEST_KEY, todo)
                );
        }

        [TestMethod]
        public void FindAllShouldReturnTwoTodos()
        {
            // Act
            var result = _todoRepository.FindAll();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(DEFAULT_TODOS.First(), result.First());
        }

        [TestMethod]
        public void CreateShouldAddNewTodo()
        {
            // Arrange
            var newValue = "todo three";

            // Act
            _todoRepository.Create("todo three");
            
            // Assert
            var resultList = database.ListRange(TEST_KEY);
            Assert.AreEqual(3, resultList.Count());
            Assert.AreEqual(resultList.Last(), newValue);
        }

        [TestMethod]
        public void DeleteShouldRemoveTodo()
        {
            // Act
            _todoRepository.Delete("todo two");
            
            // Assert
            var resultList = database.ListRange(TEST_KEY);
            Assert.AreEqual(1, resultList.Count());
            Assert.AreEqual(DEFAULT_TODOS.First(), (string) resultList.First());
        }
    }
}
