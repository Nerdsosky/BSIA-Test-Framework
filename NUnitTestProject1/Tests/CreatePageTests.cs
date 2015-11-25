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
        public void CheckGroupInputs([Values(1)] int groupNumber)
        {
            CreatePage createPage = new CreatePage(driver);

            createPage.SelectBus("1");
            createPage.SelectSeason("Fall");
            createPage.ClickGetBusInfo();



            IList<IWebElement> inputItems = createPage.GetGroupInputElements(groupNumber);
            Console.WriteLine("Got Input Items" + driver.Title);
            foreach (IWebElement item in inputItems)
            {
                Console.WriteLine("Inside Foreach" + driver.Title);
                switch (item.GetAttribute("type"))
                {
                    case "checkbox":
                        item.SendKeys("\n");
                        break;
                    case "text":
                        item.SendKeys("Testing");
                        Console.WriteLine("Typed in " + item.GetAttribute("id"));
                        break;
                }
            }


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
