﻿using System;
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
        By contactLink = By.LinkText("Contact");
        By registerLink = By.LinkText("Register");
        By loginLink = By.LinkText("Log in");
    }
}
