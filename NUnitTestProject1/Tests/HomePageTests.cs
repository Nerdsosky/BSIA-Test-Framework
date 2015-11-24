using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnitTestProject1.Pages;

namespace NUnitTestProject1.Tests
{
    [TestFixture]
    public class HomePageTests
    {
        private string applicationURL = "http://bsia.azurewebsites.net/";
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            driver.Navigate().GoToUrl(applicationURL);
        }

        [Test]
        public void Test__Homepage_Create_Button()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickLearnMoreCreateReports();
            Assert.AreEqual("Create - BSIA", driver.Title);
        }

        [Test]
        public void Test__Homepage_Edit_Button()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickLearnMoreEditReports();
            Assert.AreEqual("Edit - BSIA", driver.Title);
        }

        [Test]
        public void Test__Homepage_Reports_Button()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickLearnMoreReports();
            Assert.AreEqual("Reports - BSIA", driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}