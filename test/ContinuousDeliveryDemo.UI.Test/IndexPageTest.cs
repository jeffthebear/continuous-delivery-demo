using System;
using System.Collections.Generic;
using System.Linq;
using ContinuousDeliveryDemo.Infrastructure.Redis;
using ContinuousDeliveryDemo.UI.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StackExchange.Redis;

namespace ContinuousDeliveryDemo.UI.Test
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
            AssertFirstDefaultTodoIsOnThePage();
            AssertSecondDefaultTodoIsOnThePage();

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
            FillOutAndSubmitTodo(NEW_TODO_VALUE);
            WaitForPageToLoad();

            // Assert
            AssertFirstDefaultTodoIsOnThePage();
            AssertSecondDefaultTodoIsOnThePage();
            AssertTodoIsOnThePage(NEW_TODO_VALUE);

            // Clean up
            TearDownData();
        }

        [TestMethod]
        public void DeleteTodoShouldRemoveATodo()
        {
            // Arrange
            SetupData();
            var firstDefaultTodo = GetFirstDefaultTodo();

            // Act
            GotoIndexPage();
            ClickDeleteButtonOnTodo(firstDefaultTodo);
            WaitForPageToLoad();

            //// Assert
            AssertTodoIsNotOnThePage(firstDefaultTodo);
            AssertSecondDefaultTodoIsOnThePage();

            // Clean up
            TearDownData();
        }

        private void GotoIndexPage()
        {
            driver.Navigate().GoToUrl(@"http://continuousdeliverydemo-dev/");
        }

        private void FillOutAndSubmitTodo(string todoText)
        {
            driver.FindElement(By.Id("Message")).SendKeys(todoText);
            driver.FindElement(By.Id("create-todo-submit")).Click();
        }

        private void ClickDeleteButtonOnTodo(string todoText)
        {
            var deleteFormElements = driver.FindElements(By.CssSelector("form[action='/home/delete']"));
            var deleteFormElementsWithFirstTestTodo = deleteFormElements.Where(
                form => form.FindElements(By.CssSelector("input[value='" + todoText + "']")).Any());
            deleteFormElementsWithFirstTestTodo.ToList().ForEach(
                form => form.FindElement(By.CssSelector("[type='submit']")).Click());
        }

        private void AssertFirstDefaultTodoIsOnThePage()
        {
            AssertTodoIsOnThePage(DEFAULT_TODOS.First());
        }

        private void AssertSecondDefaultTodoIsOnThePage()
        {
            AssertTodoIsOnThePage(DEFAULT_TODOS[1]);
        }

        private void AssertTodoIsOnThePage(string todoText)
        {
            Assert.IsTrue(driver.PageSource.Contains(todoText));
        }

        private void AssertTodoIsNotOnThePage(string todoText)
        {
            Assert.IsFalse(driver.PageSource.Contains(todoText));
        }

        private void WaitForPageToLoad()
        {
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        private string GetFirstDefaultTodo()
        {
            return DEFAULT_TODOS.First();
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
