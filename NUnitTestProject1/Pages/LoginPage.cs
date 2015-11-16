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
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By emailInput = By.Id("MainContent_Email");
        By passwordInput = By.Id("MainContent_Password");
        By submitButton = By.Name("ctl00$MainContent$ctl05");
        By rememberMe = By.Id("MainContent_RememberMe");
        By registerMeLink = By.Id("MainContent_RegisterHyperLink");

        public LoginPage EnterEmail(string email)
        {
            driver.FindElement(emailInput).SendKeys(email);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            driver.FindElement(passwordInput).SendKeys(password);
            return this;
        }

        public LoginPage ClickRememberMe()
        {
            driver.FindElement(rememberMe).Click();
            return this;
        }

        public HomePage SubmitLogin()
        {
            driver.FindElement(submitButton).Click();
            return new HomePage(driver);
        }

        public LoginPage SubmitLoginExpectingError()
        {
            driver.FindElement(submitButton).Click();
            return this;
        }

        public HomePage LoginUser(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            return SubmitLogin();
        }

        public RegisterPage ClickRegisterMeLink()
        {
            driver.FindElement(registerMeLink).Click();
            return new RegisterPage(driver);
        }
    }
}
