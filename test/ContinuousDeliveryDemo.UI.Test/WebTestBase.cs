using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ContinuousDeliveryDemo.UI.Test
{
    public abstract class WebTestBase
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 10));
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}
