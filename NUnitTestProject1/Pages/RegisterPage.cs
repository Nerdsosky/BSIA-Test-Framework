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
    public class RegisterPage
    {
        private IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By usernameTextbox = By.Id("MainContent_UserName");
        By passwordTextbox = By.Id("MainContent_Password");
        By confirmPasswordTextBox = By.Id("MainContent_ConfirmPassword");
        By registerButton = By.CssSelector("[value='Register']");

        public RegisterPage EnterUsername(String username)
        {
            driver.FindElement(usernameTextbox).SendKeys(username);
            return this;
        }

        public RegisterPage EnterPassword(String password)
        {
            driver.FindElement(passwordTextbox).SendKeys(password);
            return this;
        }

        public RegisterPage ConfirmPassword(String password)
        {
            driver.FindElement(confirmPasswordTextBox).SendKeys(password);
            return this;
        }

        public HomePage RegisterUser(String username, String password, String confirmPassword)
        {
            EnterUsername(username);
            EnterPassword(password);
            ConfirmPassword(confirmPassword);
            driver.FindElement(registerButton).Click();
            return new HomePage(driver);
        }

        public String GetErrorMessage()
        {
            return "Need to implement";
        }
    }
}
