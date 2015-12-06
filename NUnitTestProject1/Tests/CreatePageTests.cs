using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnitTestProject1.Pages;
using System.Collections.Generic;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    public class CreatePageTests
    {
        private string applicationURL = "http://bsia.azurewebsites.net/create";
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            driver.Navigate().GoToUrl(applicationURL);
        }

        [Test]
        public void Test_Create_Inspection()
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.LoginUser("wysoskyj", "Football2!");
            driver.Navigate().GoToUrl(applicationURL);

            CreatePage createPage = new CreatePage(driver);

            createPage.SelectBus("103");
            createPage.SelectSeason("Fall");
            createPage.ClickGetBusInfo();


            for (int i = 1; i < 8; i++)
            {
                createPage.FillOutInspection(i);
            }


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
