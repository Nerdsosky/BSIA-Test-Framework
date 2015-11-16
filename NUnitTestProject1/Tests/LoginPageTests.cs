using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnitTestProject1.Pages;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    public class LoginPageTests
    {
        private string applicationURL = "http://localhost:49571/Account/Login";
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            driver.Navigate().GoToUrl(applicationURL);
        }

        [Test]
        public void Test_Login_Successfully()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginUser("wysoskyj@gmail.com", "Football2!");
            Assert.AreEqual(driver.FindElement(By.CssSelector("[href*='Account/Manage']")).Text, "Hello, wysoskyj@gmail.com !");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
