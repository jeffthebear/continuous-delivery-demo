using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.Infrastructure.Settings;
using ContinuousDeliveryDemo.Test.WebTest.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.Test.WebTest
{
    [TestClass]
    public class IndexPageTest : WebTestBase
    {
        private List<string> DEFAULT_TODOS = new List<string> { "web_test_todo 1", "web_test_todo 2" };
        private const string TODO_KEY = "todo";
        private const string NEW_TODO_VALUE = "web_test_todo 3";

        [TestMethod]
        public void GetIndexShouldShowListOfTodos()
        {
            // Arrange
            SetupData();

            // Act
            GotoIndexPage();

            // Assert
            Assert.IsTrue(driver.PageSource.Contains(DEFAULT_TODOS.First()));
            Assert.IsTrue(driver.PageSource.Contains(DEFAULT_TODOS.Last()));

            // Clean up
            TearDownData();
        }

        [TestMethod]
        public void CreateTodoShouldAddATodo()
        {
            // Arrange
            SetupData();

            // Act
            GotoIndexPage();
            driver.FindElement(By.Id("Message")).SendKeys(NEW_TODO_VALUE);
            driver.FindElement(By.Id("create-todo-submit")).Click();

            // Assert
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            Assert.IsTrue(driver.PageSource.Contains(NEW_TODO_VALUE));

            // Clean up
            TearDownData();
        }

        [TestMethod]
        public void DeleteTodoShouldRemoveATodo()
        {
            // Arrange
            SetupData();
            var firstTestTodo = DEFAULT_TODOS.First();

            // Act
            GotoIndexPage();
            var deleteFormElements = driver.FindElements(By.CssSelector("form[action='/home/delete']"));
            var deleteFormElementsWithFirstTestTodo = deleteFormElements.Where(
                form => form.FindElements(By.CssSelector("input[value='" + firstTestTodo + "']")).Any());
            deleteFormElementsWithFirstTestTodo.ToList().ForEach(
                form => form.FindElement(By.CssSelector("[type='submit']")).Click());
           
            //// Assert
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            Assert.IsFalse(driver.PageSource.Contains(firstTestTodo));

            // Clean up
            TearDownData();
        }

        private void GotoIndexPage()
        {
            driver.Navigate().GoToUrl(@"http://continuousdeliverydemo-dev/");
        }

        private void SetupData()
        {
            RedisConnection.RedisConnectionStringProviderOverride = new FakeRedisConnectionStringProvider();
            IDatabase db = RedisConnection.GetInstance().GetDatabase();
            DEFAULT_TODOS.ForEach(todo => db.ListRemove(TODO_KEY, todo));
            db.ListRemove(TODO_KEY, NEW_TODO_VALUE);
            DEFAULT_TODOS.ForEach(todo => db.ListRightPush(TODO_KEY, todo));
        }

        private void TearDownData()
        {
            RedisConnection.RedisConnectionStringProviderOverride = new FakeRedisConnectionStringProvider();
            IDatabase db = RedisConnection.GetInstance().GetDatabase();
            DEFAULT_TODOS.ForEach(todo => db.ListRemove(TODO_KEY, todo));
            db.ListRemove(TODO_KEY, NEW_TODO_VALUE);
        }
    }
}
