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
        public void Test_Login_Successfully(
            [Values("wysoskyj@gmail.com")] string email,
            [Values("Football2!")] string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LoginUser(email, password);
            Assert.AreEqual( "Hello, " + email + " !", driver.FindElement(By.CssSelector("[href*='Account/Manage']")).Text);
            Assert.AreEqual("Home Page - BSIA", driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
