using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProject1.Pages
{
    public class NavigationBar
    {
        private IWebDriver driver;

        public NavigationBar(IWebDriver driver)
        {
            this.driver = driver;
        }

        By homeLink = By.LinkText("BSIA Home");
        By createLink = By.LinkText("Create");
        By editLink = By.LinkText("Edit");
        By reportsLink = By.LinkText("Reports");
        By registerLink = By.LinkText("Register");
        By loginLink = By.LinkText("Log in");

        public void ClickHomeLink()
        {
            driver.FindElement(homeLink).Click();
        }

        public void ClickCreateLink()
        {
            driver.FindElement(createLink).Click();
        }

        public void ClickEditLink()
        {
            driver.FindElement(editLink).Click();
        }

        public void ClickReportsLink()
        {
            driver.FindElement(reportsLink).Click();
        }

        public void ClickRegisterLink()
        {
            driver.FindElement(registerLink).Click();
        }

        public void ClickLoginLink()
        {
            driver.FindElement(loginLink).Click();
        }
    }
}
